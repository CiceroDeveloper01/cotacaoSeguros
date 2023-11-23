namespace CotacacoSeguroDomain.ContratosGenericos.Interfaces.Services;

public interface IEntityPersistence<TEntity>
{
    public Dictionary<string, string> ValidFields { get;}
    Task<bool> ValidateAdiconar(TEntity entity);
    Task<bool> ValidateAtualizar(TEntity entity);
}
