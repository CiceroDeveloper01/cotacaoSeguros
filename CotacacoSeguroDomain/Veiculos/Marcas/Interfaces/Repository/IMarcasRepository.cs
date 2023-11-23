using CotacacoSeguroDomain.ContratosGenericos.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;

namespace CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Repository;

public interface IMarcasRepository : IRepository<MarcasEntity, MarcasFilters, MarcasResult> 
{
    Task<bool> PersistirMarcaExclusao(int ID); 
}