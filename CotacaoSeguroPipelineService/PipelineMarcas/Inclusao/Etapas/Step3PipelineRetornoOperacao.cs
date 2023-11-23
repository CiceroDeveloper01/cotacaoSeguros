using CotacacoSeguroDomain.Enums;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroShared.Commands.Domain;
using Microsoft.Extensions.Logging;
using PipelineFramework.Interfaces;

namespace CotacaoSeguroPipelineService.PipelineMarcas.Inclusao.Etapas;

public class Step3PipelineRetornoOperacao : IAsyncPipelineEtapa<MarcasEntity, CreatingResultObject>
{
    private readonly ILogger<Step1PipelineValidarParaInclusao> _logger;
    public Step3PipelineRetornoOperacao(ILogger<Step1PipelineValidarParaInclusao> logger)
    {
        _logger = logger;
    }

    public async Task<CreatingResultObject> EtapaProcesso(MarcasEntity Input)
    {
        _logger.LogInformation(@$"Executando Etapa Controller: {typeof(Step3PipelineRetornoOperacao).Name}");

        if (Input.IsValid())
        {
            var resultado = Input.EntityToDto();
            return new CreatingResultObject((int)ERetornosApi.Created, true, "Marca Cadastrada Com Sucesso", resultado);
        }
        
        return new CreatingResultObject((int)ERetornosApi.NotAcceptable, false, "Marca Não Foi Cadastrada Com Sucesso", Input.Errors);
    }

    public string NomeEtapa() => nameof(Step3PipelineRetornoOperacao);
}