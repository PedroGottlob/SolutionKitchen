using Solutionkitchen.Model;

namespace Solutionkitchen.Service

{
    public class PedidoService
    {
        private static List<Pedido> pedidos = new();

        public List<Pedido> ObterTodos() => pedidos;

        public void CriarPedido(Pedido pedido) => pedidos.Add(pedido);

        public void EditarPedido(int id, List<Prato> novosPratos, int novaQuantidade, double novoPrecoUnitario,
            MetodoPagamento novoMetodoPagamento)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);

            if (pedido != null)
            {
                pedido.Prato = novosPratos;
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
        
        public bool RemoverPratoDoPedido(int pedidoId, int pratoId)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == pedidoId);

            if (pedido != null)
            {
                var pratoRemover = pedido.Prato.FirstOrDefault(p => p.Id == pratoId);
                if (pratoRemover != null)
                {
                    pedido.Prato.Remove(pratoRemover);
                    Console.WriteLine($"Prato {pratoId} removido do pedido {pedidoId}.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Prato {pratoId} não encontrado no pedido {pedidoId}.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Pedido {pedidoId} não encontrado.");
                return false;
            }
            
        }
    }
    
    
}