using GarcomService.Models;
using GarcomService.Data;
using Microsoft.EntityFrameworkCore;

namespace GarcomService.Services;

public class GarcomServiceImpl
{
    private readonly GarcomDbContext _context;

    public GarcomServiceImpl(GarcomDbContext context)
    {
        _context = context;
    }

    public void CriarPedido(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();
    }

    public void EditarPedido(int id, List<Prato> novosPratos, int novaQuantidade, double novoPrecoUnitario, MetodoPagamento novoMetodoPagamento)
    {
        var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);

        if (pedido != null)
        {
            pedido.Prato = novosPratos;
            pedido.Quantidade = novaQuantidade;
            pedido.PrecoUnitario = novoPrecoUnitario;
            pedido.MetodoPagamento = novoMetodoPagamento;
            _context.SaveChanges();
        }
    }

    public void RemoverPedido(int id)
    {
        var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }
    }

    public bool RemoverPratoDoPedido(int pedidoId, int pratoId)
    {
        var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == pedidoId);

        if (pedido != null)
        {
            var pratoRemover = pedido.Prato.FirstOrDefault(p => p.Id == pratoId);
            if (pratoRemover != null)
            {
                pedido.Prato.Remove(pratoRemover);
                _context.SaveChanges();
                return true;
            }
        }

        return false;
    }

    public async Task<List<Pedido>> ListarPedidosAsync()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public Pedido? ObterPedidoPorId(int id)
    {
        return _context.Pedidos.FirstOrDefault(p => p.Id == id);
    }
}
