using ChefService.Models;
using ChefService.Data;

namespace ChefService.Services;

public class ChefServiceImpl
{
    private readonly ChefDbContext _context;

    public ChefServiceImpl(ChefDbContext context)
    {
        _context = context;
    }

    public List<Pedido> ListarPedidosPendentes()
    {
        return _context.Pedidos.Where(p => p.Status == "Pendente").ToList();
    }

    public void PedidoEmPreparo(int pedidoId)
    {
        var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == pedidoId);
        if (pedido != null && pedido.Status == "Pendente")
        {
            pedido.Status = "Em Preparo";
            _context.SaveChanges();
        }
    }

    public void PedidoPronto(int pedidoId)
    {
        var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == pedidoId);
        if (pedido != null && pedido.Status == "Em Preparo")
        {
            pedido.Status = "Pronto";
            _context.SaveChanges();
        }
    }

    public List<Pedido> ListarPedidosEmPreparo()
    {
        return _context.Pedidos.Where(p => p.Status == "Em Preparo").ToList();
    }

    public List<Pedido> ListarPedidosProntos()
    {
        return _context.Pedidos.Where(p => p.Status == "Pronto").ToList();
    }
}
