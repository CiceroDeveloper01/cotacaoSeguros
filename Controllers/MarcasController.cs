using CotacacoSeguroDomain.Enums;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroShared.Commands.Domain;
using CotacaoSeguroPipelineService.PipelineMarcas.Inclusao.Orquestrador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CotacaoBackEnd.Controllers;

[AllowAnonymous]
[Route("v1/")]
public class MarcasController : AbstractController<MarcasRequest, MarcasFilters>
{
    private readonly Step0OrquestradorPipelineInclusaoMarcas _step0OrquestradorPipelineInclusaoMarcas;
    private readonly ILogger<MarcasController> _logger;

    public MarcasController(Step0OrquestradorPipelineInclusaoMarcas step0OrquestradorPipelineInclusaoMarcas, 
                            ILogger<MarcasController> logger)
    {
        _step0OrquestradorPipelineInclusaoMarcas = step0OrquestradorPipelineInclusaoMarcas;
        _logger = logger;
    }

    [HttpPost]
    [Route("AdicionarMarcas")]
    [SwaggerOperation("Marcas")]
    [SwaggerResponse(201, Type = typeof(MarcasResult), Description = "Adiciona Uma Nova Marca de Carros, Caminhões, Motos e Barcos")]
    public override async Task<IActionResult> Adicionar([FromBody] MarcasRequest domain)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(MarcasController).Name} e o Método: Adicionar");
            var resultadoInclusaoMarca = await _step0OrquestradorPipelineInclusaoMarcas.EtapaProcesso(domain);
            return StatusCode(resultadoInclusaoMarca.CodeReturn, resultadoInclusaoMarca);
        }
        catch(Exception ex) 
        {
            _logger.LogInformation($@"Erro a Controller: {typeof(MarcasController).Name} e o Método: Adicionar a Mensagem: {ex.Message}");
            var error = new CreatingResultObject((int)ERetornosApi.InternalServerError, 
                                                 false, 
                                                 "Houve Um Erro Inesperado, Por favor, tente mais tarde.", 
                                                 ex.Message);
            return StatusCode(error.CodeReturn, error);
        }
    }

    [HttpPost]
    [Route("AtualizarMarcas")]
    public override Task<IActionResult> Atualizar([FromBody] MarcasRequest domain)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Route("BuscarPorFiltros")]
    public override Task<IActionResult> BuscarPorFiltro([FromBody] MarcasFilters domain)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("BuscarPorIdMarcas")]
    public override Task<IActionResult> BuscarPorId(int ID)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("DeletarPorMarcas")]
    public override Task<IActionResult> Deletar(int ID)
    {
        throw new NotImplementedException();
    }
}