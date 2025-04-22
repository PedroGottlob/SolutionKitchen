using Microsoft.AspNetCore.Mvc;
using Solutionkitchen.Model;
using Solutionkitchen.Service;

namespace Solutionkitchen.Controller;

[ApiController]
[Route("api/mesa")]
public class MesaController : ControllerBase
{
    private readonly MesaService _mesaService;

    public MesaController(MesaService mesaService)
    {
        _mesaService = mesaService;
    }

    [HttpGet("obter-pedidos-mesa/{numeroMesa}")]
    public ActionResult<List<Pedido>> ObterPedidosMesa(int numeroMesa)
    {
        var pedidos = _mesaService.ObterPedidosMesa(numeroMesa);
        return Ok(pedidos);
    }

    [HttpGet("obter-total-mesa/{numeroMesa}")]
    public ActionResult<double> ObterTotalMesa(int numeroMesa)
    {
        var total = _mesaService.ObterTotalMesa(numeroMesa);
        return Ok(total);
    }

    [HttpPost("adicionar-mesa")]
    public IActionResult AdicionarMesa([FromBody] Mesa novaMesa)
    {
        _mesaService.AdicionarMesa(novaMesa);
        return CreatedAtAction(nameof(ObterPedidosMesa), new { numeroMesa = novaMesa.NumeroMesa }, novaMesa);
    }

    [HttpGet("buscar-mesa/{numeroMesa}")]
    public ActionResult<Mesa> BuscarMesa(int numeroMesa)
    {
       var mesa= _mesaService.BuscarMesa(numeroMesa);
        if (mesa == null)
        {
            return NotFound();
        }
        
        return Ok(mesa);
    }
}