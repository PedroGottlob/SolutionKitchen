using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Solutionkitchen.Model;
using Solutionkitchen.Service;

namespace Solutionkitchen.Controller;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly MenuService _menuService;

    public MenuController(MenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet("pratos-do-dia")]
    public ActionResult<List<Prato>> ObterPratosDoDia()
    {
        return _menuService.ObterPratosDoDia();
    }

    [HttpPost("definir-pratos-do-dia")]
    public IActionResult DefinirPratosDoDia([FromBody] List<Prato> pratos)
    {
        _menuService.DefinirPratosDoDia(pratos);
        return NoContent();
    }
}


