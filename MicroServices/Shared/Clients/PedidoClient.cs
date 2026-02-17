using System.Net.Http.Json;

namespace Shared.Clients
{
    public class PedidoClient : IPedidoClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _garcomServiceUrl;

        public PedidoClient(HttpClient httpClient, string garcomServiceUrl = "http://localhost:5002")
        {
            _httpClient = httpClient;
            _garcomServiceUrl = garcomServiceUrl;
        }

        public async Task<bool> AtualizarStatusPedidoAsync(int pedidoId, string novoStatus)
        {
            try
            {
                var response = await _httpClient.PatchAsync(
                    $"{_garcomServiceUrl}/api/garcom/listar-pedidos",
                    null
                );
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar status do pedido: {ex.Message}");
                return false;
            }
        }

        public async Task<List<dynamic>> ListarPedidosPendentesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_garcomServiceUrl}/api/garcom/listar-pedidos"
                );

                if (response.IsSuccessStatusCode)
                {
                    var pedidos = await response.Content.ReadAsAsync<List<dynamic>>();
                    return pedidos ?? new List<dynamic>();
                }

                return new List<dynamic>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar pedidos pendentes: {ex.Message}");
                return new List<dynamic>();
            }
        }
    }
}
