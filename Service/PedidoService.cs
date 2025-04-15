using Solutionkitchen.Model;

namespace Solutionkitchen.Service

{
    public class PedidoService
    {
        private static List<Pedido> pedidos = new();

        public List<Pedido> ObterTodos() => pedidos;

        public void CriarPedido(Pedido pedido) => pedidos.Add(pedido);
        public void EditarPedido(Pedido pedido) => pedidos.Remove(pedido);
        public void ValidarPedido(Pedido pedido) => pedidos.Find(p => p.Id == pedido.Id);

    public void AtualizarStatus(int id, string novoStatus)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido != null) pedido.Status = novoStatus;
        }
        
    }
}
