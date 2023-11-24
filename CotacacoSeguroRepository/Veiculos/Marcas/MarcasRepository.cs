using CotacacoSeguroDomain.Seguros.Cotacoes.Entidades;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.Modelos.Entidades;
using CotacacoSeguroDomain.Veiculos.Versoes.Entidades;
using CotacacoSeguroShared.Attributes;
using CotacacoSeguroShared.PaginacaoBuscao;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace CotacacoSeguroRepository.Veiculos.Marcas;

public class MarcasRepository : IMarcasRepository
{
    private readonly SqlConnection _sqlConnection;
    private string _tableMarcas;
    private string _tableModelosMarcas;
    private string _tableVersoesModelos;
    private string _tableCotacoes;
    private readonly ILogger<MarcasRepository> _logger;

    public MarcasRepository(SqlConnection sqlConnection, ILogger<MarcasRepository> logger)
    {
        _sqlConnection = sqlConnection;
        _tableMarcas = FindAttribute.FindFullName(typeof(MarcasEntity));
        _tableModelosMarcas = FindAttribute.FindFullName(typeof(ModelosEntity));
        _tableVersoesModelos = FindAttribute.FindFullName(typeof(VersoesModelosEntity));
        _tableCotacoes = FindAttribute.FindFullName(typeof(CotacoesEntity));
        _logger = logger;
    }

    public async Task<int> Adicionar(MarcasEntity request)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(MarcasRepository).Name} e o Método: Adicionar");

        var sql = @$"INSERT INTO {_tableMarcas}
                                 (NomeMarca
                                , TipoProducao
                                , DataAlteracao
                                , DataCriacao)
                          VALUES ('{request.NomeMarca}'         
                                , '{request.TipoProducao}'   
                                , '{request.DataAlteracao.ToString("yyyy-MM-dd HH:mm:ss")}'
                                , '{request.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss")}')
                           SELECT @@IDENTITY";

        return await _sqlConnection.ExecuteScalarAsync<int>(sql);
    }

    public async Task Atualizar(MarcasEntity request)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(MarcasRepository).Name} e o Método: Atualizar");

        var sql = $@"UPDATE {_tableMarcas}
                        SET NomeMarca = '{request.NomeMarca}'
                          , TipoProducao = '{request.TipoProducao}'
                          , DataAlteracao = '{request.DataAlteracao.ToString("yyyy-MM-dd HH:mm:ss")}'
                      WHERE ID = {request.ID}";

        await _sqlConnection.ExecuteAsync(sql);
    }

    public async Task<IEnumerable<MarcasResult>> BuscarPorFiltro(MarcasFilters filter, RetornoLinhasBusca retornoLinhasBusca)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(MarcasRepository).Name} e o Método: BuscarPorFiltro");

        var sql = $@"SELECT RowNumeroLinha
                          , ID
                          , NomeMarca
                          , TipoProducao
                          , DataAlteracao
                          , DataCriacao                            
                       FROM 
                          (SELECT RowNumeroLinha  = ROW_NUMBER() OVER (ORDER BY DataCriacao)
                                , ID
                                , NomeMarca
                                , TipoProducao
                                , DataAlteracao
                                , DataCriacao                            
                             FROM {_tableMarcas}";

        if (filter.NomeMarca != "" && filter.TipoProducao != null)
            sql = sql + $@"WHERE NomeMarca LIKE '%{filter.NomeMarca}%'
                             AND TipoProducao = '{filter.TipoProducao?.ToString("G")}') AS RowConstrainedResult";


        if (filter.NomeMarca != "" && filter.TipoProducao == null)
            sql = sql + $@"WHERE NomeMarca LIKE '%{filter.NomeMarca}%') AS RowConstrainedResult";

        if (filter.TipoProducao != null && filter.NomeMarca == "")
            sql = sql + $@"WHERE TipoProducao = '{filter.TipoProducao?.ToString("G")}') AS RowConstrainedResult";
        else
            sql = sql + $@") AS RowConstrainedResult";

        sql = sql + $@"WHERE RowNumeroLinha 
                     BETWEEN {retornoLinhasBusca.LinhaInicialCaptura} AND { retornoLinhasBusca.LinhaFinalCaptura}
                    ORDER BY DataCriacao";

        return (IEnumerable<MarcasResult>)await _sqlConnection.QueryAsync<IEnumerable<MarcasResult>>(sql);
    }

    public async Task<MarcasResult> BuscarPorId(int ID)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(MarcasRepository).Name} e o Método: BuscarPorFiltro");

        var sql = $@"SELECT ID
                          , NomeMarca
                          , TipoProducao
                          , DataAlteracao
                          , DataCriacao
                       FROM {_tableMarcas}
                      WHERE ID = {ID}";

        return await _sqlConnection.QueryFirstOrDefaultAsync<MarcasResult>(sql);
    }

    public async Task Deletar(int ID)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(MarcasRepository).Name} e o Método: Deletar");

        var sql = $@"DELETE
                       FROM {_tableMarcas}
                      WHERE ID = {ID}";

        await _sqlConnection.ExecuteAsync(sql);
    }

    public async Task<int> TotalDeRegistrosCadastrados(MarcasFilters filter)
    {
        var sql = $@"SELECT COUNT(1)
                       FROM {_tableMarcas}";

        if (filter.NomeMarca != "" && filter.TipoProducao != null)
            sql = sql + $@"WHERE NomeMarca LIKE '%{filter.NomeMarca}%'
                             AND TipoProducao = '{filter.TipoProducao?.ToString("G")}'";


        if (filter.NomeMarca != "" && filter.TipoProducao == null)
            sql = sql + $@"WHERE NomeMarca LIKE '%{filter.NomeMarca}%'";

        if (filter.TipoProducao != null && filter.NomeMarca == "")
            sql = sql + $@"WHERE TipoProducao = '{filter.TipoProducao?.ToString("G")}'";

        return await _sqlConnection.ExecuteScalarAsync<int>(sql);
    }

    public async Task<bool> PersistirMarcaExclusao(int ID)
    {
        var sql = $@"SELECT (TBMM.QuantidadeModeloMarcas
	                      + TBMMV.QuantidadeModeloMarcasVersoes 
		                  + TBMMVC.QuantidadeModeloMarcasVersoesCotacoes) As Quantidade
	                   FROM (SELECT COUNT(1) QuantidadeModeloMarcas
	                           FROM {_tableMarcas} TBM WITH(NOLOCK)
		                 INNER JOIN {_tableModelosMarcas} TBMM WITH(NOLOCK)
		                         ON TBM.ID = TBMM.IDMARCAS
			                  WHERE TBM.ID = {ID}) AS TBMM,
	                        (SELECT COUNT(1) QuantidadeModeloMarcasVersoes
	                           FROM {_tableMarcas} TBM WITH(NOLOCK)
		                 INNER JOIN {_tableModelosMarcas} TBMM WITH(NOLOCK)
		                         ON TBM.ID = TBMM.IDMARCAS
		                 INNER JOIN {_tableVersoesModelos} TBVM WITH(NOLOCK)
		                         ON TBMM.ID = TBVM.IDMODELOSMARCAS
			                  WHERE TBM.ID = {ID}) AS TBMMV,
			                (SELECT COUNT(1) QuantidadeModeloMarcasVersoesCotacoes
	                           FROM {_tableMarcas} TBM WITH(NOLOCK)
		                 INNER JOIN {_tableModelosMarcas} TBMM WITH(NOLOCK)
		                         ON TBM.ID = TBMM.IDMARCAS
		                 INNER JOIN {_tableVersoesModelos} TBVM WITH(NOLOCK)
		                         ON TBMM.ID = TBVM.IDMODELOSMARCAS
		                 INNER JOIN {_tableCotacoes} TBC WITH(NOLOCK)
		                         ON TBC.IDVERSOESMODELOS = TBVM.ID
			                  WHERE TBM.ID = {ID}) AS TBMMVC";

        var quantidade = await _sqlConnection.ExecuteScalarAsync<int>(sql);

        if (quantidade == 0)
            return true;
        else 
            return false;
    }
}