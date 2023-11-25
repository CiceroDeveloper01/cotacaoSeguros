using CotacacoSeguroDomain.ContratosGenericos.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.Versoes.Entidades;

namespace CotacacoSeguroDomain.Veiculos.VersoesModelos.Interfaces.Repository;

public interface IVersoesModelosRepository : IRepository<VersoesModelosEntity, VersoesModelosFilters, VersoesModelosResult>
{
}
