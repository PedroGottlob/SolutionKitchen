using Microsoft.AspNetCore.Mvc;
using Solutionkitchen.Service;

namespace Solutionkitchen.Controller;

public class ChefController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly PedidoService _pedidoService;
    private readonly AdmService _admService;

    public ChefController(PedidoService pedidoService, AdmService admService)
    {
        _pedidoService = pedidoService;
        _admService = admService;
    }

    public IActionResult Index()
    {
        var pedidosPendentes = _pedidoService.ObterTodos().Where(p => p.Status == "Pendente").ToList();
        return View(pedidosPendentes);
    }

    public IActionResult Finalizar(int id)
    {
        _pedidoService.AtualizarStatus(id, "Finalizado");
        var pedido = _pedidoService.ObterTodos().FirstOrDefault(p => p.Id == id);
        _admService.RegistrarVenda(pedido);
        return RedirectToAction("Index");
    }
}
