using Microsoft.AspNetCore.Mvc;
using GarcomService.Models;
using GarcomService.Services;

namespace GarcomService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GarcomController : ControllerBase
{
    private readonly GarcomServiceImpl _garcomService;

    public GarcomController(GarcomServiceImpl garcomService)
    {
        _garcomService = garcomService;
    }

    [HttpPost("criar-pedido")]
    public IActionResult CriarPedido([FromBody] Pedido pedido)
    {
        _garcomService.CriarPedido(pedido);
        return CreatedAtAction(nameof(ObterPedidoPorId), new { id = pedido.Id }, pedido);
    }

    [HttpPut("editar-pedido/{id}")]
    public IActionResult EditarPedido(int id, [FromBody] Pedido novoPedido)
    {
        _garcomService.EditarPedido(id, novoPedido.Prato, novoPedido.Quantidade, novoPedido.PrecoUnitario,
            novoPedido.MetodoPagamento);
        return Ok("Pedido editado com sucesso!");
    }

    [HttpDelete("remover-pedido/{id}")]
    public IActionResult RemoverPedido(int id)
    {
        _garcomService.RemoverPedido(id);
        return Ok("Pedido excluído com sucesso!");
    }

    [HttpDelete("remover-prato/{pedidoId}/{pratoId}")]
    public IActionResult RemoverPrato(int pedidoId, int pratoId)
    {
        var sucesso = _garcomService.RemoverPratoDoPedido(pedidoId, pratoId);

        if (sucesso)
        {
            return Ok("Prato removido do pedido com sucesso!");
        }
        else
        {
            return NotFound("Pedido ou prato não encontrado.");
        }
    }

    [HttpGet("listar-pedidos")]
    public async Task<IActionResult> ListarPedidos()
    {
        var pedidos = await _garcomService.ListarPedidosAsync();
        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public IActionResult ObterPedidoPorId(int id)
    {
        var pedido = _garcomService.ObterPedidoPorId(id);
        if (pedido == null)
        {
            return NotFound("Pedido não encontrado.");
        }

        return Ok(pedido);
    }
}
