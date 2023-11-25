using CotacacoSeguroDomain.Veiculos.Versoes.Entidades;
using CotacacoSeguroDomain.Veiculos.VersoesModelos.Interfaces.Repository;
using CotacacoSeguroShared.PaginacaoBuscao;

namespace CotacacoSeguroRepository.Veiculos.VersoesModelos;

public class VersoesModelosRepository : IVersoesModelosRepository
{
    public Task<int> Adicionar(VersoesModelosEntity request)
    {
        throw new NotImplementedException();
    }

    public Task Atualizar(VersoesModelosEntity request)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<VersoesModelosResult>> BuscarPorFiltro(VersoesModelosFilters filter, RetornoLinhasBusca retornoLinhasBusca)
    {
        throw new NotImplementedException();
    }

    public Task<VersoesModelosResult> BuscarPorId(int ID)
    {
        throw new NotImplementedException();
    }

    public Task Deletar(int ID)
    {
        throw new NotImplementedException();
    }

    public Task<int> TotalDeRegistrosCadastrados(VersoesModelosFilters filter)
    {
        throw new NotImplementedException();
    }
}
