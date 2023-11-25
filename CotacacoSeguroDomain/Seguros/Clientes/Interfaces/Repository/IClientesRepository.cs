using CotacacoSeguroDomain.ContratosGenericos.Interfaces.Repository;
using CotacacoSeguroDomain.Seguros.Clientes.Entidades;

namespace CotacacoSeguroDomain.Seguros.Clientes.Interfaces.Repository;

public interface IClientesRepository : IRepository<ClientesEntity, ClientesFilters, ClientesResult> 
{

}
