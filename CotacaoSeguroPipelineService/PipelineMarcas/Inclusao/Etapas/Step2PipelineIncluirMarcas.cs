using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Services;
using Microsoft.Extensions.Logging;
using PipelineFramework.Interfaces;

namespace CotacaoSeguroPipelineService.PipelineMarcas.Inclusao.Etapas;

public class Step2PipelineIncluirMarcas : IAsyncPipelineEtapa<MarcasEntity, MarcasEntity>
{
    private readonly ILogger<Step1PipelineValidarParaInclusao> _logger;
    private readonly IMarcasService _marcasService;

    public Step2PipelineIncluirMarcas(ILogger<Step1PipelineValidarParaInclusao> logger, IMarcasService marcasService)
    {
        _logger = logger;
        _marcasService = marcasService;
    }

    public async Task<MarcasEntity> EtapaProcesso(MarcasEntity Input)
    {
        _logger.LogInformation(@$"Executando a Etapa: {NomeEtapa()}");
        return await _marcasService.Adicionar(Input);
    }

    public string NomeEtapa() => nameof(Step2PipelineIncluirMarcas);
}
