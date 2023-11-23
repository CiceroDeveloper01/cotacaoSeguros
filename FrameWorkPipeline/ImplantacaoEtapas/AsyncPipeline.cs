using PipelineFramework.Interfaces;

namespace PipelineFramework.ImplantacaoEtapas;

public class AsyncPipeline<TEntrada, TSaida> : IAsyncPipelineEtapa<TEntrada, TSaida>
{
    public Func<TEntrada, Task<TSaida>> _pipelineSteps { get; protected set; }
    
    public string NomeEtapa() => nameof(AsyncPipeline<TEntrada, TSaida>);

    public Task<TSaida> EtapaProcesso(TEntrada Input)
    {
        return _pipelineSteps(Input);
    }
}