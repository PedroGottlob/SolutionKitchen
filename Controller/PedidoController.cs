using Microsoft.AspNetCore.Mvc;
using Solutionkitchen.Data;
using Solutionkitchen.Model;
using Solutionkitchen.Service;

namespace Solutionkitchen.Controller;


[ApiController]
[Route("api/[controller]")]
public class PedidoController :ControllerBase
{
    private readonly PedidoService _pedidoService;

    public PedidoController(PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public ActionResult<List<Pedido>> ObterTodos()
    {
        return Ok(_pedidoService.ObterTodos());
    }

    [HttpPost]
    public IActionResult CriarPedido([FromBody] Pedido pedido)
    {
        _pedidoService.CriarPedido(pedido);
        return CreatedAtAction(nameof(ObterTodos), new {id = pedido.Id},pedido);
    }

    [HttpPut("{id}")]
    public IActionResult EditarPedido(int id, [FromBody] Pedido pedidoAtualizado)
    {
        _pedidoService.EditarPedido(id, pedidoAtualizado.Prato,pedidoAtualizado.Quantidade, pedidoAtualizado.PrecoUnitario,pedidoAtualizado.MetodoPagamento);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverPedido(int id)
    {
        _pedidoService.RemoverPedido(id);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarStatus(int id, [FromBody] string status)
    {
        _pedidoService.AtualizarStatus(id, status);
        return NoContent();
    }
    
    
    
}