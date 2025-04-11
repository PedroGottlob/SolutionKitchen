using Microsoft.AspNetCore.Mvc;
using Solutionkitchen.Model;
using Solutionkitchen.Service;


namespace Solutionkitchen.Controller;

public class GarcomController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly PedidoService _pedidoService;

    public GarcomController(PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public IActionResult NovoPedido() => View();

    [HttpPost]
    public IActionResult NovoPedido(Pedido pedido)
    {
        _pedidoService.CriarPedido(pedido);
        return RedirectToAction("Index", "Chef");
    }
}
