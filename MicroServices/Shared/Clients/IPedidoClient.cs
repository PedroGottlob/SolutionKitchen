namespace Shared.Clients
{
    public interface IPedidoClient
    {
        Task<bool> AtualizarStatusPedidoAsync(int pedidoId, string novoStatus);
        Task<List<dynamic>> ListarPedidosPendentesAsync();
    }
}
