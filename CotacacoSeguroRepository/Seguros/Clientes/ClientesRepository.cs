using CotacacoSeguroDomain.Seguros.Clientes.Entidades;
using CotacacoSeguroDomain.Seguros.Clientes.Interfaces.Repository;
using CotacacoSeguroDomain.Seguros.Cotacoes.Entidades;
using CotacacoSeguroRepository.Veiculos.Marcas;
using CotacacoSeguroShared.Attributes;
using CotacacoSeguroShared.PaginacaoBuscao;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace CotacacoSeguroRepository.Seguros.Clientes;

public class ClientesRepository : IClientesRepository
{
    private readonly SqlConnection _sqlConnection;
    private readonly string _tableClientes;
    private readonly ILogger<ClientesRepository> _logger;

    public ClientesRepository(SqlConnection sqlConnection, ILogger<ClientesRepository> logger)
    {
        _sqlConnection = sqlConnection;
        _tableClientes = FindAttribute.FindFullName(typeof(ClientesEntity));
        _logger = logger;
    }

    public async Task<int> Adicionar(ClientesEntity request)
    {
        _logger.LogInformation($@"Iniciando a Service: {typeof(ClientesRepository).Name} e o Método: Adicionar");


    }

    public Task Atualizar(ClientesEntity request)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ClientesResult>> BuscarPorFiltro(ClientesFilters filter, RetornoLinhasBusca retornoLinhasBusca)
    {
        throw new NotImplementedException();
    }

    public Task<ClientesResult> BuscarPorId(int ID)
    {
        throw new NotImplementedException();
    }

    public Task Deletar(int ID)
    {
        throw new NotImplementedException();
    }

    public Task<int> TotalDeRegistrosCadastrados(ClientesFilters filter)
    {
        throw new NotImplementedException();
    }
}
