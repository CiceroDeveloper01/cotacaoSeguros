using Microsoft.AspNetCore.Mvc;

namespace CotacaoBackEndApi.Controllers;

public class CotacoesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
