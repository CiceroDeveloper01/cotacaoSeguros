using CotacacoSeguroDomain.Enums;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Services;
using CotacacoSeguroShared.Commands.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CotacaoBackEnd.Controllers;

[AllowAnonymous]
[Route("v1/marcas")]
public class MarcasController : AbstractController<MarcasRequest, MarcasFilters>
{
    private readonly ILogger<MarcasController> _logger;
    private readonly IMarcasService _marcasService;

    public MarcasController(ILogger<MarcasController> logger, IMarcasService marcasService)
    {
        _logger = logger;
        _marcasService = marcasService;
    }

    [HttpPost]
    [Route("Adicionar")]
    [SwaggerOperation("Marcas")]
    [SwaggerResponse(201, Type = typeof(MarcasResult), Description = "Adiciona Uma Nova Marca de Carros, Caminhões, Motos e Barcos")]
    public override async Task<IActionResult> Adicionar([FromBody] MarcasRequest request)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(MarcasController).Name} e o Método: Adicionar");
            var resultadoInclusaoMarca = await _marcasService.Adicionar(request);
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

    [HttpPut]
    [Route("Atualizar")]
    [SwaggerOperation("Marcas")]
    [SwaggerResponse(200, Type = typeof(MarcasResult), Description = "Atualizar Uma Nova Marca de Carros, Caminhões, Motos e Barcos")]
    public override async Task<IActionResult> Atualizar([FromBody] MarcasRequest request)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(MarcasController).Name} e o Método: Adicionar");
            var resultadoAtualizacaoMarca = await _marcasService.Atualizar(request);
            return StatusCode(resultadoAtualizacaoMarca.CodeReturn, resultadoAtualizacaoMarca);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($@"Erro a Controller: {typeof(MarcasController).Name} e o Método: Atualizar a Mensagem: {ex.Message}");
            var error = new CreatingResultObject((int)ERetornosApi.InternalServerError,
                                                 false,
                                                 "Houve Um Erro Inesperado, Por favor, tente mais tarde.",
                                                 ex.Message);
            return StatusCode(error.CodeReturn, error);
        }
    }

    [HttpGet]
    [Route("BuscarPorFiltros")]
    [SwaggerOperation("Marcas")]
    [SwaggerResponse(200, Type = typeof(MarcasResult), Description = "Buscar Marcas Por Filtro")]
    public override async Task<IActionResult> BuscarPorFiltro([FromBody] MarcasFilters domain)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(MarcasController).Name} e o Método: BuscarPorId");
            var resultadoBuscaMarca = await _marcasService.BuscarPorFiltro(domain);
            return StatusCode(resultadoBuscaMarca.CodeReturn, resultadoBuscaMarca);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($@"Erro a Controller: {typeof(MarcasController).Name} e o Método: BuscarPorId a Mensagem: {ex.Message}");
            var error = new CreatingResultObject((int)ERetornosApi.InternalServerError,
                                                 false,
                                                 "Houve Um Erro Inesperado, Por favor, tente mais tarde.",
                                                 ex.Message);
            return StatusCode(error.CodeReturn, error);
        }
    }

    [HttpGet]
    [Route("BuscarPorId")]
    [SwaggerOperation("Marcas")]
    [SwaggerResponse(200, Type = typeof(MarcasResult), Description = "Buscar Marcas Por ID")]
    public override async Task<IActionResult> BuscarPorId(int ID)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(MarcasController).Name} e o Método: BuscarPorId");
            var resultadoBuscaMarca = await _marcasService.BuscarPorId(ID);
            return StatusCode(resultadoBuscaMarca.CodeReturn, resultadoBuscaMarca);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($@"Erro a Controller: {typeof(MarcasController).Name} e o Método: BuscarPorId a Mensagem: {ex.Message}");
            var error = new CreatingResultObject((int)ERetornosApi.InternalServerError,
                                                 false,
                                                 "Houve Um Erro Inesperado, Por favor, tente mais tarde.",
                                                 ex.Message);
            return StatusCode(error.CodeReturn, error);
        }
    }

    [HttpDelete]
    [Route("Deletar")]
    [SwaggerOperation("Marcas")]
    [SwaggerResponse(200, Type = typeof(MarcasResult), Description = "Deletar Marcas Por ID")]
    public override async Task<IActionResult> Deletar(int ID)
    {
        try
        {
            _logger.LogInformation($@"Iniciando a Controller: {typeof(MarcasController).Name} e o Método: Deletar");
            var resultadoDeleteMarca = await _marcasService.Deletar(ID);
            return StatusCode(resultadoDeleteMarca.CodeReturn, resultadoDeleteMarca);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($@"Erro a Controller: {typeof(MarcasController).Name} e o Método: Deletar a Mensagem: {ex.Message}");
            var error = new CreatingResultObject((int)ERetornosApi.InternalServerError,
                                                 false,
                                                 "Houve Um Erro Inesperado, Por favor, tente mais tarde.",
                                                 ex.Message);
            return StatusCode(error.CodeReturn, error);
        }
    }
}