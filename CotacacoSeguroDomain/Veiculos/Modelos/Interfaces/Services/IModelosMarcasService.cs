using CotacacoSeguroDomain.ContratosGenericos.Interfaces.Services;
using CotacacoSeguroDomain.Veiculos.Modelos.Entidades;

namespace CotacacoSeguroDomain.Veiculos.Modelos.Interfaces.Services;

public interface IModelosMarcasService : IService<ModelosRequest, ModelosEntity, ModelosFilters, ModelosResult>
{

}
