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

    public void EditarPedido(int id, List<Prato> novosPratos,int novaQuantidade, double novoPrecoUnitario, MetodoPagamento novoMetodoPagamento)
    {
        _pedidoService.EditarPedido(id,novosPratos,novaQuantidade,novoPrecoUnitario,novoMetodoPagamento);
    }

    public void RemoverPedido(int id)
    {
        _pedidoService.RemoverPedido(id);
    }

    public bool RemoverPratoDoPedido(int pedidoId, int pratoId)
    {
        return _pedidoService.RemoverPratoDoPedido(pedidoId,pratoId);
    }
    
   
}