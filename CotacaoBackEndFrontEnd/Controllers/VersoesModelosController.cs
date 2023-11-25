using CotacacoSeguroDomain.Veiculos.Modelos.Entidades;
using CotacacoSeguroDomain.Veiculos.Versoes.Entidades;
using CotacaoBackEnd.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CotacaoBackEndApi.Controllers;

[AllowAnonymous]
[Route("v1/versoesmodelos")]
public class VersoesModelosController : AbstractController<VersoesModelosRequest, VersoesModelosFilters>
{
    [HttpPost]
    [Route("Adicionar")]
    [SwaggerOperation("VersoesModelos")]
    [SwaggerResponse(201, Type = typeof(VersoesModelosResult), Description = "Adiciona Um Novo Modelo de Carros, Caminhões, Motos e Barcos")]
    public override Task<IActionResult> Adicionar([FromBody] VersoesModelosRequest domain, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Route("Atualizar")]
    [SwaggerOperation("VersoesModelos")]
    [SwaggerResponse(200, Type = typeof(ModelosResult), Description = "Atualizar Uma Nova Marca de Carros, Caminhões, Motos e Barcos")]
    public override Task<IActionResult> Atualizar([FromBody] VersoesModelosRequest domain, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("BuscarPorFiltros")]
    [SwaggerOperation("VersoesModelos")]
    [SwaggerResponse(200, Type = typeof(ModelosResult), Description = "Buscar Modelos Por Filtro")]
    public override Task<IActionResult> BuscarPorFiltro([FromBody] VersoesModelosFilters domain, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("BuscarPorId")]
    [SwaggerOperation("VersoesModelos")]
    [SwaggerResponse(200, Type = typeof(ModelosResult), Description = "Buscar Modelos Por ID")]
    public override Task<IActionResult> BuscarPorId(int ID, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("Deletar")]
    [SwaggerOperation("VersoesModelos")]
    [SwaggerResponse(200, Type = typeof(ModelosResult), Description = "Deletar Modelos Por ID")]
    public override Task<IActionResult> Deletar(int ID, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
