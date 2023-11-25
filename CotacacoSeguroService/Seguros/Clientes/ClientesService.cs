using CotacacoSeguroDomain.Seguros.Clientes.Entidades;
using CotacacoSeguroDomain.Seguros.Clientes.Interfaces.Services;
using CotacacoSeguroShared.Commands.Interfaces;

namespace CotacacoSeguroService.Seguros.Clientes;

public class ClientesService : IClientesService
{
    public Task<ICommandResult> Adicionar(ClientesRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ICommandResult> Atualizar(ClientesRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ICommandResult> BuscarPorFiltro(ClientesFilters filter)
    {
        throw new NotImplementedException();
    }

    public Task<ICommandResult> BuscarPorId(int ID)
    {
        throw new NotImplementedException();
    }

    public Task<ICommandResult> Deletar(int ID)
    {
        throw new NotImplementedException();
    }
}
