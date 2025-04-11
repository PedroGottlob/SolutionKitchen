using Microsoft.AspNetCore.Mvc;
using Solutionkitchen.Service;

namespace Solutionkitchen.Controller;

public class AdmController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly AdmService _admService;

    public AdmController(AdmService admService)
    {
        _admService = admService;
    }

    public IActionResult Relatorio()
    {
        ViewBag.Total = _admService.TotalArrecadado;
        ViewBag.Quantidade = _admService.TotalPratos;
        ViewBag.PorMetodo = _admService.VendasPorMetodo();
        return View();
    }
}
