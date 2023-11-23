using CotacacoSeguroShared.PaginacaoBuscao;

namespace CotacacoSeguroDomain.ContratosGenericos.Interfaces.Repository;

public interface IRepository<TEntity, TFilter, TResult>
{
    public Task<int> Adicionar(TEntity request);
    public Task Atualizar(TEntity request);
    public Task<TResult> BuscarPorId(int ID);
    public Task<IEnumerable<TResult>> BuscarPorFiltro(TFilter filter, RetornoLinhasBusca retornoLinhasBusca);
    public Task Deletar(int ID);
    public Task<int> VerificarExistenciaRegistro(int ID);
    public Task<int> TotalDeRgistrosCadastrados();
}