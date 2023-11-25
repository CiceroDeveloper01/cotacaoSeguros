using CotacacoSeguroDomain.ContratosGenericos.Interfaces.Services;
using CotacacoSeguroDomain.Seguros.Clientes.Entidades;

namespace CotacacoSeguroDomain.Seguros.Clientes.Interfaces.Services;

public interface IClientesService : IService<ClientesRequest, ClientesEntity, ClientesFilters, ClientesResult>
{

}
