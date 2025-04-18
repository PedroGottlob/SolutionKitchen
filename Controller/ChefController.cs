using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Solutionkitchen.Model;
using Solutionkitchen.Service;

namespace Solutionkitchen.Controller;

[ApiController]
[Route("api/[controller]")]
public class ChefController : ControllerBase
{
    private readonly ChefService _chefService;

    public ChefController(ChefService chefService)
    {
        _chefService = chefService;
    }

    [HttpGet("pendentes")]
    public ActionResult<List<Pedido>> ListarPedidosPendentes()
    {
        var listaDePedidos = _chefService.ListarPedidosPendentes();
        return Ok(listaDePedidos);
    }

    [HttpPatch("preparar/{id}")]
    public IActionResult PedidoEmPreparo(int id)
    {
        _chefService.PedidoEmPreparo(id);
        return NoContent();
    }

    [HttpPatch("pronto/{id}")]
    public IActionResult PedidoPronto(int id)
    {
        _chefService.PedidoPronto(id);
        return NoContent();
    }

}