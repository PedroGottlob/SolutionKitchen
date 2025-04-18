using Solutionkitchen.Model;

namespace Solutionkitchen.Service;

public class GarcomService
{
    private readonly PedidoService _pedidoService;

    public GarcomService(PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    public void CriarPedido(Pedido pedido)
    {
        _pedidoService.CriarPedido(pedido);
    }

    public void EditarPedido(int id,string novoPrato,int novaQuantidade, double novoPrecoUnitario, MetodoPagamento novoMetodoPagamento)
    {
        _pedidoService.EditarPedido(id,novoPrato,novaQuantidade,novoPrecoUnitario,novoMetodoPagamento);
    }

    public void RemoverPedido(int id)
    {
        _pedidoService.RemoverPedido(id);
    }
    
    public void PegarPrato(object sender, EventArgs e)
    {
        Console.WriteLine("Garçom: Pedido pronto, indo buscar!");
    }
}