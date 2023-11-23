using PipelineFramework.Interfaces;

namespace PipelineFramework.ImplantacaoEtapas;

public class AsyncColecaoFiltroPipelineEtapa<TEntrada, TSaida> : IAsyncPipelineEtapa<IEnumerable<TEntrada>, IEnumerable<TSaida>> where TEntrada : TSaida
{
    private readonly Func<TEntrada, bool> _filter;

    public AsyncColecaoFiltroPipelineEtapa(Func<TEntrada, bool> filter)
    {
        _filter = filter;
    }

    public string NomeEtapa() => nameof(AsyncColecaoFiltroPipelineEtapa<TEntrada, TSaida>);
    
    public async Task<IEnumerable<TSaida>> EtapaProcesso(IEnumerable<TEntrada> Input)
    {
        return await Task.FromResult((IEnumerable<TSaida>) Input?.Where(x => _filter(x)));
    }
}