using CotacaoSeguroPipelineService.PipelineMarcas.Inclusao.Etapas;
using CotacaoSeguroPipelineService.PipelineMarcas.Inclusao.Orquestrador;
using Microsoft.Extensions.DependencyInjection;

namespace CotacaoSeguroPipelineService;

public static class DIPipelineService
{
    public static IServiceCollection AddPipeline(this IServiceCollection services)
    {
        services = AddPipelineInclusaoMarcas(services);
        return services;
    }

    private static IServiceCollection AddPipelineInclusaoMarcas(this IServiceCollection services)
    {
        services.AddScoped<Step0OrquestradorPipelineInclusaoMarcas>();
        services.AddScoped<Step1PipelineValidarParaInclusao>();
        services.AddScoped<Step2PipelineIncluirMarcas>();
        services.AddScoped<Step3PipelineRetornoOperacao>();
        return services;
    }
}