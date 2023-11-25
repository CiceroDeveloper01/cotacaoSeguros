using CotacacoSeguroDomain.Veiculos.Versoes.Entidades;
using CotacacoSeguroDomain.Veiculos.VersoesModelos.Interfaces.Services;
using CotacacoSeguroShared.Commands.Interfaces;

namespace CotacacoSeguroService.Veiculos.VersoesModelos;

public class VersoesModelosService : IVersoesModelosService
{
    public Task<ICommandResult> Adicionar(VersoesModelosRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ICommandResult> Atualizar(VersoesModelosRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ICommandResult> BuscarPorFiltro(VersoesModelosFilters filter)
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
