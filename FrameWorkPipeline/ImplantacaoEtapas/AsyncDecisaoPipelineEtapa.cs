using PipelineFramework.Interfaces;

namespace PipelineFramework.ImplantacaoEtapas;

public class AsyncDecisaoPipelineEtapa<TEntrada, TSaida> : IAsyncPipelineEtapa<TEntrada, TSaida>
{
    private readonly IAsyncPipelineEtapa<TEntrada, TSaida> _primeira;
    private readonly IAsyncPipelineEtapa<TEntrada, TSaida> _segunda;
    private Func<TEntrada, bool> _decisao;

    public AsyncDecisaoPipelineEtapa(Func<TEntrada, bool> decisao, 
                                          IAsyncPipelineEtapa<TEntrada, TSaida> primeira, 
                                          IAsyncPipelineEtapa<TEntrada, TSaida> segunda)
    {
        _decisao = decisao;
        _primeira = primeira;
        _segunda = segunda;
    }
   
    public string NomeEtapa() => nameof(AsyncDecisaoPipelineEtapa<TEntrada, TSaida>);

    public Task<TSaida> EtapaProcesso(TEntrada Input)
    {
        if (_decisao(Input))
            return _primeira.EtapaProcesso(Input);
        else
            return _segunda.EtapaProcesso(Input);
    }
}