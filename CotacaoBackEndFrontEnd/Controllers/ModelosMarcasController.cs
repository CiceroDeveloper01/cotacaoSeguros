using CotacacoSeguroDomain.Enums;
using CotacacoSeguroDomain.Veiculos.Modelos.Entidades;
using CotacacoSeguroDomain.Veiculos.Modelos.Interfaces.Services;
using CotacacoSeguroShared.Commands.Domain;
using CotacaoBackEnd.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CotacaoBackEndApi.Controllers;

[AllowAnonymous]
[Route("v1/modelosmarcas")]
public class ModelosMarcasController : AbstractController<ModelosRequest, ModelosFilters>
{
    private readonly ILogger<ModelosMarcasController> _logger;
    private readonly IModelosMarcasService _modelosService;

    public ModelosMarcasController(ILogger<ModelosMarcasController> logger, IModelosMarcasService modelosService)
    {
        _logger = logger;
        _modelosService = modelosService;
    }


    [HttpPost]
    [Route("Adicionar")]
    [SwaggerOperation("ModelosMarcas")]
    [SwaggerResponse(201, Type = typeof(ModelosResult), Description = "Adiciona Um Novo Modelo de Carros, Caminhões, Motos e Barcos")]
    public override async Task<IActionResult> Adicionar([FromBody] ModelosRequest request)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(ModelosMarcasController).Name} e o Método: Adicionar");
            var resultadoInclusaoMarca = await _modelosService.Adicionar(request);
            return StatusCode(resultadoInclusaoMarca.CodeReturn, resultadoInclusaoMarca);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($@"Erro a Controller: {typeof(ModelosMarcasController).Name} e o Método: Adicionar a Mensagem: {ex.Message}");
            var error = new CreatingResultObject((int)ERetornosApi.InternalServerError,
                                                 false,
                                                 "Houve Um Erro Inesperado, Por favor, tente mais tarde.",
                                                 ex.Message);
            return StatusCode(error.CodeReturn, error);
        }
    }

    [HttpPut]
    [Route("Atualizar")]
    [SwaggerOperation("ModelosMarcas")]
    [SwaggerResponse(200, Type = typeof(ModelosResult), Description = "Atualizar Uma Nova Marca de Carros, Caminhões, Motos e Barcos")]
    public override async Task<IActionResult> Atualizar([FromBody] ModelosRequest request)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(ModelosMarcasController).Name} e o Método: Adicionar");
            var resultadoAtualizacaoMarca = await _modelosService.Atualizar(request);
            return StatusCode(resultadoAtualizacaoMarca.CodeReturn, resultadoAtualizacaoMarca);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($@"Erro a Controller: {typeof(ModelosMarcasController).Name} e o Método: Atualizar a Mensagem: {ex.Message}");
            var error = new CreatingResultObject((int)ERetornosApi.InternalServerError,
                                                 false,
                                                 "Houve Um Erro Inesperado, Por favor, tente mais tarde.",
                                                 ex.Message);
            return StatusCode(error.CodeReturn, error);
        }
    }

    [HttpGet]
    [Route("BuscarPorFiltros")]
    [SwaggerOperation("ModelosMarcas")]
    [SwaggerResponse(200, Type = typeof(ModelosResult), Description = "Buscar Modelos Por Filtro")]
    public override async Task<IActionResult> BuscarPorFiltro([FromBody] ModelosFilters domain)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(ModelosMarcasController).Name} e o Método: BuscarPorId");
            var resultadoBuscaMarca = await _modelosService.BuscarPorFiltro(domain);
            return StatusCode(resultadoBuscaMarca.CodeReturn, resultadoBuscaMarca);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($@"Erro a Controller: {typeof(ModelosMarcasController).Name} e o Método: BuscarPorId a Mensagem: {ex.Message}");
            var error = new CreatingResultObject((int)ERetornosApi.InternalServerError,
                                                 false,
                                                 "Houve Um Erro Inesperado, Por favor, tente mais tarde.",
                                                 ex.Message);
            return StatusCode(error.CodeReturn, error);
        }
    }

    [HttpGet]
    [Route("BuscarPorId")]
    [SwaggerOperation("ModelosMarcas")]
    [SwaggerResponse(200, Type = typeof(ModelosResult), Description = "Buscar Modelos Por ID")]
    public override async Task<IActionResult> BuscarPorId(int ID)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(ModelosMarcasController).Name} e o Método: BuscarPorId");
            var resultadoBuscaMarca = await _modelosService.BuscarPorId(ID);
            return StatusCode(resultadoBuscaMarca.CodeReturn, resultadoBuscaMarca);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($@"Erro a Controller: {typeof(ModelosMarcasController).Name} e o Método: BuscarPorId a Mensagem: {ex.Message}");
            var error = new CreatingResultObject((int)ERetornosApi.InternalServerError,
                                                 false,
                                                 "Houve Um Erro Inesperado, Por favor, tente mais tarde.",
                                                 ex.Message);
            return StatusCode(error.CodeReturn, error);
        }
    }

    [HttpDelete]
    [Route("Deletar")]
    [SwaggerOperation("ModelosMarcas")]
    [SwaggerResponse(200, Type = typeof(ModelosResult), Description = "Deletar Modelos Por ID")]
    public override async Task<IActionResult> Deletar(int ID)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(ModelosMarcasController).Name} e o Método: Deletar");
            var resultadoDeleteMarca = await _modelosService.Deletar(ID);
            return StatusCode(resultadoDeleteMarca.CodeReturn, resultadoDeleteMarca);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($@"Erro a Controller: {typeof(ModelosMarcasController).Name} e o Método: Deletar a Mensagem: {ex.Message}");
            var error = new CreatingResultObject((int)ERetornosApi.InternalServerError,
                                                 false,
                                                 "Houve Um Erro Inesperado, Por favor, tente mais tarde.",
                                                 ex.Message);
            return StatusCode(error.CodeReturn, error);
        }
    }
}
