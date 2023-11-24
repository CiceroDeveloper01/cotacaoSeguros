using CotacacoSeguroDomain.ContratosGenericos.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.Modelos.Entidades;

namespace CotacacoSeguroDomain.Veiculos.Modelos.Interfaces.Repository;

public interface IModelosMarcasRepository : IRepository<ModelosEntity, ModelosFilters, ModelosResult>
{
    Task<bool> PersistirModeloExclusao(int ID);
}
