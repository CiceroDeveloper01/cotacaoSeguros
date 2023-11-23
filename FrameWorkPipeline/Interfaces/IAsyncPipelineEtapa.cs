namespace PipelineFramework.Interfaces;

public interface IAsyncPipelineEtapa<TEntrada, TSaida>
{
    string NomeEtapa();
    Task<TSaida> EtapaProcesso(TEntrada Input);
}