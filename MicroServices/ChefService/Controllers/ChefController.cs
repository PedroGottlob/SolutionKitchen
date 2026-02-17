using Microsoft.AspNetCore.Mvc;
using ChefService.Models;
using ChefService.Services;

namespace ChefService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChefController : ControllerBase
{
    private readonly ChefServiceImpl _chefService;

    public ChefController(ChefServiceImpl chefService)
    {
        _chefService = chefService;
    }

    [HttpGet("pendentes")]
    public ActionResult<List<Pedido>> ListarPedidosPendentes()
    {
        var listaDePedidos = _chefService.ListarPedidosPendentes();
        return Ok(listaDePedidos);
    }

    [HttpGet("em-preparo")]
    public ActionResult<List<Pedido>> ListarPedidosEmPreparo()
    {
        var listaDePedidos = _chefService.ListarPedidosEmPreparo();
        return Ok(listaDePedidos);
    }

    [HttpGet("prontos")]
    public ActionResult<List<Pedido>> ListarPedidosProntos()
    {
        var listaDePedidos = _chefService.ListarPedidosProntos();
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
