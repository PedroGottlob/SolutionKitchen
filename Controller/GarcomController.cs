using Microsoft.AspNetCore.Mvc;
using Solutionkitchen.Model;
using Solutionkitchen.Service;

namespace Solutionkitchen.Controller;

[ApiController]
[Route("api/[controller]")]
public class GarcomController : ControllerBase
{
    private readonly GarcomService _garcomService;

    public GarcomController(GarcomService garcomService)
    {
        _garcomService = garcomService;
    }

    [HttpPost("criar-pedido")]
    public IActionResult CriarPedido([FromBody] Pedido pedido)
    {
        _garcomService.CriarPedido(pedido);
        return Ok("Pedido cadastrado com sucesso!");
    }

    [HttpPut("editar-pedido")]
    public IActionResult EditarPedido(int id, [FromBody] Pedido novoPedido)
    {
        _garcomService.EditarPedido(id, novoPedido.Prato, novoPedido.Quantidade, novoPedido.PrecoUnitario,
            novoPedido.MetodoPagamento);
        return Ok("Pedido editado com sucesso!");
    }

    [HttpDelete("remover-pedido")]
    public IActionResult RemoverPedido(int id)
    {
        _garcomService.RemoverPedido(id);
        return Ok("Pedido excluido com sucesso!");
    }
}