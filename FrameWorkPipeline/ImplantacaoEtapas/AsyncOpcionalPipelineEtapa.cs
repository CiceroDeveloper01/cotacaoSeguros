using PipelineFramework.Interfaces;

namespace PipelineFramework.ImplantacaoEtapas;

public class AsyncOpcionalPipelineEtapa<TEntrada, TSaida> : IAsyncPipelineEtapa<TEntrada, TSaida> where TEntrada : TSaida
{
    private Func<TEntrada, bool> _decisao;
    private readonly IAsyncPipelineEtapa<TEntrada, TSaida> _etapa;
    
    public AsyncOpcionalPipelineEtapa(Func<TEntrada, bool> decisao, IAsyncPipelineEtapa<TEntrada, TSaida> etapa)
    {
        _decisao = decisao;
        _etapa = etapa;
    }

    public string NomeEtapa() => nameof(AsyncOpcionalPipelineEtapa<TEntrada, TSaida>);

    public Task<TSaida> EtapaProcesso(TEntrada Input)
    {
        if (_decisao(Input))
            return _etapa.EtapaProcesso(Input);

        return Task.FromResult((TSaida)Input);
    }
}