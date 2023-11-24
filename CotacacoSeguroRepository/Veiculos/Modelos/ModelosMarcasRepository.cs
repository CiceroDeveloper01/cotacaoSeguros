using CotacacoSeguroDomain.Seguros.Cotacoes.Entidades;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroDomain.Veiculos.Modelos.Entidades;
using CotacacoSeguroDomain.Veiculos.Modelos.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.Versoes.Entidades;
using CotacacoSeguroRepository.Veiculos.Marcas;
using CotacacoSeguroShared.Attributes;
using CotacacoSeguroShared.PaginacaoBuscao;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Net.Quic;

namespace CotacacoSeguroRepository.Veiculos.Modelos;

public class ModelosMarcasRepository : IModelosMarcasRepository
{
    private readonly SqlConnection _sqlConnection;
    private string _tableModelosMarcas;
    private string _tableVersoesModelos;
    private string _tableCotacoes;
    private string _tableMarcas;
    private readonly ILogger<ModelosMarcasRepository> _logger;

    public ModelosMarcasRepository(SqlConnection sqlConnection, ILogger<ModelosMarcasRepository> logger)
    {
        _sqlConnection = sqlConnection;
        _tableMarcas = FindAttribute.FindFullName(typeof(MarcasEntity));
        _tableModelosMarcas = FindAttribute.FindFullName(typeof(ModelosEntity));
        _tableVersoesModelos = FindAttribute.FindFullName(typeof(VersoesModelosEntity));
        _tableCotacoes = FindAttribute.FindFullName(typeof(CotacoesEntity));
        _logger = logger;
    }


    public async Task<int> Adicionar(ModelosEntity request)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(ModelosMarcasRepository).Name} e o Método: Adicionar");

        var sql = $@"INSERT INTO {_tableModelosMarcas}
                                 (IDMARCAS
                                , NomeModelo
                                , AnoInicialFabricacao
                                , AnoFinalFabricacao
                                , DataAlteracao
                                , DataCriacao)
                          VALUES({request.Marca.ID}
                                ,'{request.NomeModelo}'
                                , {request.AnoInicialFabricacao}
                                , {request.AnoFinalFabricacao}
                                ,'{request.DataAlteracao.ToString("yyyy-MM-dd HH:mm:ss")}'
                                ,'{request.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss")}')
                           SELECT @@IDENTITY";

        return await _sqlConnection.ExecuteScalarAsync<int>(sql);
    }

    public async Task Atualizar(ModelosEntity request)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(ModelosMarcasRepository).Name} e o Método: Atualizar");

        var sql = $@"UPDATE {_tableModelosMarcas}
                        SET NomeModelo = '{request.NomeModelo}'
                          , IDMARCAS = {request.Marca.ID}
                          , DataAlteracao = '{request.DataAlteracao.ToString("yyyy-MM-dd HH:mm:ss")}'
                      WHERE ID = {request.ID}";

        await _sqlConnection.ExecuteAsync(sql);
    }

    public async Task<IEnumerable<ModelosResult>> BuscarPorFiltro(ModelosFilters filter, RetornoLinhasBusca retornoLinhasBusca)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(ModelosMarcasRepository).Name} e o Método: BuscarPorFiltro");

        var sql = $@"SELECT RowNumeroLinha
	                      , IDModelo
	                      , NomeModelo
		                  , AnoInicialFabricacao
		                  , AnoFinalFabricacao
		                  , DataAlteracao
		                  , DataCriacao
		                  , IDMarcas
		                  , NomeMarca
	                   FROM
	                      (SELECT RowNumeroLinha = ROW_NUMBER() OVER (ORDER BY DataCriacao)
	                            , TBMM.ID AS IDModelo
	                            , TBMM.NomeModelo
		                        , TBMM.AnoInicialFabricacao
		                        , TBMM.AnoFinalFabricacao
		                        , TBMM.DataAlteracao
		                        , TBMM.DataCriacao
		                        , TBM.ID AS IDMarcas
		                        , TBM.NomeMarca 
	                         FROM {_tableMarcas} TBM
                       INNER JOIN {_tableModelosMarcas} TBMM
                               ON TBM.ID = TBMM.IDMARCAS";

        if (!string.IsNullOrEmpty(filter.NomeModelo)
         && !string.IsNullOrEmpty(filter.NomeMarca)
         && filter.AnoInicialFabricacao != 0 && filter.AnoFinalFabricacao != 0)
            sql = sql + $@"WHERE TBMM.NomeModelo LIKE '{filter.NomeModelo}'
                             AND TBMM.NOmeMarca LIKE '{filter.NomeMarca}'
                             AND TBMM.AnoInicialFabricacao = {filter.AnoInicialFabricacao} 
                             AND TBMM.AnoFinalFabricacao = {filter.AnoFinalFabricacao}) AS  RowConstrainedResult";

        if (string.IsNullOrEmpty(filter.NomeModelo)
         && !string.IsNullOrEmpty(filter.NomeMarca)
         && filter.AnoInicialFabricacao == 0 && filter.AnoFinalFabricacao == 0)
            sql = sql + $@"WHERE TBMM.NomeModelo LIKE '{filter.NomeModelo}') AS  RowConstrainedResult";

        if (!string.IsNullOrEmpty(filter.NomeModelo)
         && string.IsNullOrEmpty(filter.NomeMarca)
         && filter.AnoInicialFabricacao == 0 && filter.AnoFinalFabricacao == 0)
            sql = sql + $@"WHERE TBMM.NOmeMarca LIKE '{filter.NomeMarca}') AS  RowConstrainedResult";

        if (string.IsNullOrEmpty(filter.NomeModelo)
         && string.IsNullOrEmpty(filter.NomeMarca)
         && filter.AnoInicialFabricacao != 0 && filter.AnoFinalFabricacao == 0)
            sql = sql + $@"WHERE TBMM.AnoInicialFabricacao = {filter.AnoInicialFabricacao}) AS  RowConstrainedResult";

        if (string.IsNullOrEmpty(filter.NomeModelo)
         && string.IsNullOrEmpty(filter.NomeMarca)
         && filter.AnoInicialFabricacao == 0 && filter.AnoFinalFabricacao != 0)
            sql = sql + $@"WHERE TBMM.AnoFinalFabricacao = {filter.AnoInicialFabricacao}) AS  RowConstrainedResult";

        sql = sql + "ORDER BY DataCriacao";

        var modelosMarcas = await _sqlConnection.QueryAsync(sql);

        if (modelosMarcas != null && modelosMarcas.Count() > 0)
        {
            List<ModelosResult> modelosResults = new List<ModelosResult>(); 
            foreach(var modeloMarca in modelosMarcas) 
            {
                modelosResults.Add(new ModelosResult
                { 
                    ID = modeloMarca.IDModelo,
                    NomeModelo = modeloMarca.NomeModelo,
                    AnoInicialFabricacao = modeloMarca.AnoInicialFabricacao,
                    AnoFinalFabricacao = modeloMarca.AnoFinalFabricacao,
                    DataAlteracao = modeloMarca.DataAlteracao,
                    DataCriacao = modeloMarca.DataCriacao,
                    Marcas = new MarcasResult
                    {
                        ID = modeloMarca.IDMarca,
                        NomeMarca = modeloMarca.NomeMarca
                    }
                });
            }
            return modelosResults;
        }
        return null; 
    }

    public async Task<ModelosResult> BuscarPorId(int ID)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(ModelosMarcasRepository).Name} e o Método: BuscarPorFiltro");

        var sql = $@"SELECT TBMM.ID AS IDModelo
	                      , TBMM.NomeModelo
		                  , TBMM.AnoInicialFabricacao
		                  , TBMM.AnoFinalFabricacao
		                  , TBMM.DataAlteracao
		                  , TBMM.DataCriacao
		                  , TBM.ID AS IDMarcas
                          , TBM.NomeMarca
	                   FROM {_tableMarcas} TBM
                 INNER JOIN {_tableModelosMarcas} TBMM
                         ON TBM.ID = TBMM.IDMARCAS
	                  WHERE TBMM.ID = {ID}";

        var modelosMarcas = await _sqlConnection.QueryAsync(sql);

        if (modelosMarcas != null && modelosMarcas.Count() > 0)
        {
            var modeloMarca = modelosMarcas.FirstOrDefault();
            return new ModelosResult
            {
                ID = modeloMarca.IDModelo,
                NomeModelo = modeloMarca.NomeModelo,
                AnoInicialFabricacao = modeloMarca.AnoInicialFabricacao,
                AnoFinalFabricacao = modeloMarca.AnoFinalFabricacao,
                DataAlteracao = modeloMarca.DataAlteracao,
                DataCriacao = modeloMarca.DataCriacao,
                Marcas = new MarcasResult
                {
                    ID = modeloMarca.IDMarcas,
                    NomeMarca = modeloMarca.NomeMarca
                }
            };
        }
        return null;
    }

    public async Task Deletar(int ID)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(ModelosMarcasRepository).Name} e o Método: Deletar");

        var sql = $@"DELETE
                       FROM {_tableModelosMarcas}
                      WHERE ID = {ID}";

        await _sqlConnection.ExecuteAsync(sql);
    }

    public Task<bool> PersistirModeloExclusao(int ID)
    {
        throw new NotImplementedException();
    }

    public Task<int> TotalDeRegistrosCadastrados(ModelosFilters filters)
    {
        throw new NotImplementedException();
    }

    public Task<int> VerificarExistenciaRegistro(int ID)
    {
        throw new NotImplementedException();
    }
}
