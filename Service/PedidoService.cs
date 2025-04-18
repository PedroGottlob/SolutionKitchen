using Solutionkitchen.Model;

namespace Solutionkitchen.Service

{
    public class PedidoService
    {
        private static List<Pedido> pedidos = new();

        public List<Pedido> ObterTodos() => pedidos;

        public void CriarPedido(Pedido pedido) => pedidos.Add(pedido);

        public void EditarPedido(int id, string novoPrato, int novaQuantidade, double novoPrecoUnitario,
            MetodoPagamento novoMetodoPagamento)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);

            if (pedido != null)
            {
                pedido.Prato = novoPrato;
                pedido.Quantidade = novaQuantidade;
                pedido.PrecoUnitario = novoPrecoUnitario;
                pedido.MetodoPagamento = novoMetodoPagamento;

                Console.WriteLine($"Pedido {id} atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }

        public void RemoverPedido(int id)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido != null)
            {
                pedidos.Remove(pedido);
                Console.WriteLine($"Pedido {id} removido com sucesso.");
            }
        }

        public void AtualizarStatus(int id, string novoStatus)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido != null) pedido.Status = novoStatus;
        }
    }
}