using PipelineFramework.Interfaces;

namespace PipelineFramework.ImplantacaoEtapas;

public class AsyncSequencialInteracaoPipelineEtapas<TEntrada, TSaida> : IAsyncPipelineEtapa<IEnumerable<TEntrada>, IEnumerable<TSaida>> where TEntrada : TSaida
{
    private readonly IAsyncPipelineEtapa<TEntrada, TSaida> _etapa;
    private readonly bool _awaitProcess;

    public AsyncSequencialInteracaoPipelineEtapas(IAsyncPipelineEtapa<TEntrada, TSaida> etapa, bool awaitProcess = true)
    {
        _etapa = etapa;
        _awaitProcess = awaitProcess;
    }


    public string NomeEtapa() => nameof(AsyncSequencialInteracaoPipelineEtapas<TEntrada, TSaida>);
    
    public Task<IEnumerable<TSaida>> EtapaProcesso(IEnumerable<TEntrada> Input)
    {
        if (_awaitProcess)
            return AwaitEtapaProcesso(Input);

        return Task.FromResult((IEnumerable<TSaida>)Input);
    }

    private async Task<IEnumerable<TSaida>> AwaitEtapaProcesso(IEnumerable<TEntrada> Input)
    {
        return await Task.WhenAll(Input?.Select(x => _etapa.EtapaProcesso(x)));
    }
}