using CotacacoSeguroDomain.ContratosGenericos.Interfaces.Services;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;

namespace CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Services;

public interface IMarcasService : IService<MarcasRequest, MarcasEntity, MarcasFilters, MarcasResult>
{
}
