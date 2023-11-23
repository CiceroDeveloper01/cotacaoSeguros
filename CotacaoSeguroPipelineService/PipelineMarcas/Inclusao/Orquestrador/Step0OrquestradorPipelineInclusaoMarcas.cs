using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroShared.Commands.Domain;
using CotacaoSeguroPipelineService.PipelineMarcas.Inclusao.Etapas;
using PipelineFramework.Extensoes;
using PipelineFramework.ImplantacaoEtapas;

namespace CotacaoSeguroPipelineService.PipelineMarcas.Inclusao.Orquestrador;

public class Step0OrquestradorPipelineInclusaoMarcas : AsyncPipeline<MarcasRequest, CreatingResultObject>
{
    private readonly Step1PipelineValidarParaInclusao _step1PipelineValidarParaInclusao;
    private readonly Step2PipelineIncluirMarcas _step2PipelineIncluirMarcas;
    private readonly Step3PipelineRetornoOperacao _step3PipelineRetornoOperacao;

    public Step0OrquestradorPipelineInclusaoMarcas(Step1PipelineValidarParaInclusao step1PipelineValidarParaInclusao, 
                                                   Step2PipelineIncluirMarcas step2PipelineIncluirMarcas, 
                                                   Step3PipelineRetornoOperacao step3PipelineRetornoOperacao)
    {
        _step1PipelineValidarParaInclusao = step1PipelineValidarParaInclusao;
        _step2PipelineIncluirMarcas = step2PipelineIncluirMarcas;
        _step3PipelineRetornoOperacao = step3PipelineRetornoOperacao;

        _pipelineSteps = Entrada => Entrada
        .AdicionarEtapa(_step1PipelineValidarParaInclusao)
        .AdicionarEtapa(new AsyncOpcionalPipelineEtapa<MarcasEntity, MarcasEntity>(Entrada => Entrada.IsValid(),
                                                                                  _step2PipelineIncluirMarcas))
        .AdicionarEtapa(_step3PipelineRetornoOperacao);
    }
}