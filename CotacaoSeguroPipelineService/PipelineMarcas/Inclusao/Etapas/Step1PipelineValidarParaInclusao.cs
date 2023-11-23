using CotacacoSeguroDomain.ContratosGenericos.Interfaces.Services;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using Microsoft.Extensions.Logging;
using PipelineFramework.Interfaces;

namespace CotacaoSeguroPipelineService.PipelineMarcas.Inclusao.Etapas;

public class Step1PipelineValidarParaInclusao : IAsyncPipelineEtapa<MarcasRequest, MarcasEntity>
{
    private readonly ILogger<Step1PipelineValidarParaInclusao> _logger;
    private readonly IServiceValidator<MarcasRequest, MarcasEntity> _marcasServiceValidator;

    public Step1PipelineValidarParaInclusao(ILogger<Step1PipelineValidarParaInclusao> logger,
                                            IServiceValidator<MarcasRequest, MarcasEntity> marcasServiceValidator)
    {
        _logger = logger;
        _marcasServiceValidator = marcasServiceValidator;
    }

    public async Task<MarcasEntity> EtapaProcesso(MarcasRequest Input)
    {
        return await _marcasServiceValidator.Validar(Input);
    }

    public string NomeEtapa() => nameof(Step1PipelineValidarParaInclusao);
}