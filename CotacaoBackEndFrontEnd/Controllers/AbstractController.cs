using Microsoft.AspNetCore.Mvc;

namespace CotacaoBackEnd.Controllers;

[ApiController]
public abstract class AbstractController<Domain, Filters> : Controller
{
    public abstract Task<IActionResult> Adicionar([FromBody] Domain domain, CancellationToken cancellationToken);

    public abstract Task<IActionResult> BuscarPorId(int ID, CancellationToken cancellationToken);

    public abstract Task<IActionResult> BuscarPorFiltro([FromBody] Filters domain, CancellationToken cancellationToken);

    public abstract Task<IActionResult> Atualizar([FromBody] Domain domain, CancellationToken cancellationToken);

    public abstract Task<IActionResult> Deletar(int ID, CancellationToken cancellationToken);
}
