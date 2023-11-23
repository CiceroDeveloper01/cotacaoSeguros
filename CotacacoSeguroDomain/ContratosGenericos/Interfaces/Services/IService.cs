using CotacacoSeguroShared.Commands.Interfaces;

namespace CotacacoSeguroDomain.ContratosGenericos.Interfaces.Services;

public interface IService<TRequest, TEntity, TFilter, TResult>
{
    public Task<ICommandResult> Adicionar(TRequest request);
    public Task<ICommandResult> Atualizar(TRequest request);
    public Task<ICommandResult> BuscarPorId(int ID);
    public Task<ICommandResult> BuscarPorFiltro(TFilter filter);
    public Task<ICommandResult> Deletar(int ID);
}
