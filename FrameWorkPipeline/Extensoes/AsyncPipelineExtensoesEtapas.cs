using PipelineFramework.Interfaces;

namespace PipelineFramework.Extensoes;

public static class AsyncPipelineExtensoesEtapas
{
    public async static Task<TSaida> AdicionarEtapa<TEntrada, TSaida>(this Task<TEntrada> Input, IAsyncPipelineEtapa<TEntrada, TSaida> Step)
    {
        var ProcessedInput = await Input;
        return await Step.EtapaProcesso(ProcessedInput);
    }
    public async static Task<TSaida> AdicionarEtapa<TEntrada, TSaida>(this TEntrada Input, IAsyncPipelineEtapa<TEntrada, TSaida> Step)
    {
        return await Step.EtapaProcesso(Input);
    }
}
