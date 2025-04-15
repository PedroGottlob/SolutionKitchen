using Solutionkitchen.Model;

namespace Solutionkitchen.Service;

public class ChefService
{
   private readonly List<Pedido> _pedidos;
   public event EventHandler Pronto;

   public ChefService(List<Pedido> pedidos)
   {
      _pedidos = pedidos;
   }

 
   
   public List<Pedido> ListarPedidosPendentes()
   {
      return _pedidos.Where(p=> p.Status == "Pendente").ToList();
   }

   public void PedidoEmPreparo(int pedidoId)
   {
      var pedido = _pedidos.FirstOrDefault( p => p.PedidoId == pedidoId);
      if (pedido != null && pedido.Status == "Pendente")
      {
         pedido.Status = "Em Preparo";
      }
   }

   public void PedidoPronto(int pedidoId)
   {
      var pedido = _pedidos.FirstOrDefault(p => p.PedidoId == pedidoId);
      if (pedido != null && pedido.Status == "Em Preparo")
      {
         pedido.Status = "Pronto";
      }
   }
   public void PrepararPrato()
   {
      EventHandler handler = Pronto;
      handler?.Invoke(this, EventArgs.Empty);
   }
}