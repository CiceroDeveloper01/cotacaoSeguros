using CotacacoSeguroDomain.Seguros.Clientes.Entidades;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroShared.Commands.Interfaces;
using CotacaoBackEnd.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CotacaoBackEndApi.Controllers;

[AllowAnonymous]
[Route("v1/clientes")]
public class ClientesController : AbstractController<ClientesRequest, ClientesFilters>
{
    [HttpPost]
    [Route("Adicionar")]
    [SwaggerOperation("Clientes")]
    [SwaggerResponse(201, Type = typeof(MarcasResult), Description = "Adiciona Uma Nova Marca de Carros, Caminhões, Motos e Barcos")]
    public override Task<IActionResult> Adicionar([FromBody] ClientesRequest domain, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Route("Atualizar")]
    [SwaggerOperation("Clientes")]
    [SwaggerResponse(200, Type = typeof(MarcasResult), Description = "Atualizar Uma Nova Marca de Carros, Caminhões, Motos e Barcos")]
    public override Task<IActionResult> Atualizar([FromBody] ClientesRequest domain, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("BuscarPorFiltros")]
    [SwaggerOperation("Clientes")]
    [SwaggerResponse(200, Type = typeof(MarcasResult), Description = "Buscar Marcas Por Filtro")]
    public override Task<IActionResult> BuscarPorFiltro([FromBody] ClientesFilters domain, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("BuscarPorId")]
    [SwaggerOperation("Clientes")]
    [SwaggerResponse(200, Type = typeof(ICommandResult), Description = "Buscar Clientes Por ID")]
    [SwaggerResponse(404, Type = typeof(ICommandResult), Description = "Quando Não For Localizado o Cliente Retornará Uma Mensagem de Erro")]
    public override Task<IActionResult> BuscarPorId(int ID, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("Deletar")]
    [SwaggerOperation("Clientes")]
    [SwaggerResponse(200, Type = typeof(MarcasResult), Description = "Deletar Marcas Por ID")]
    public override Task<IActionResult> Deletar(int ID, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
