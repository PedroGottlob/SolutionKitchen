using Solutionkitchen.Model;

namespace Solutionkitchen.Service

{
    public class PedidoService
    {
        private static List<Pedido> _pedidos = new();

        public List<Pedido> ObterTodos() => _pedidos;

        public void CriarPedido(Pedido pedido) => _pedidos.Add(pedido);

        public void AtualizarStatus(int id, string novoStatus)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido != null) pedido.Status = novoStatus;
        }
    }

}