using hyperSpeed.Application.DTOs;

using System.Net.Http.Json;

namespace HyperSpeed.UI.Services

{

    public class HttpPedidoService

    {

        private readonly HttpClient _httpClient;

        public HttpPedidoService(HttpClient httpClient)

        {

            _httpClient = httpClient;

        }

        // ADMIN - todos os pedidos

        public async Task<IEnumerable<PedidoDTo>> GetAllAsync()

        {

            return await _httpClient

                .GetFromJsonAsync<IEnumerable<PedidoDTo>>(

                    "api/Pedido"

                )

                ?? Enumerable.Empty<PedidoDTo>();

        }

        // USUÁRIO - somente os próprios pedidos

        public async Task<IEnumerable<PedidoDTo>> GetMeusPedidosAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<IEnumerable<PedidoDTo>>(
                    "api/Pedido/MeusPedidos"
                )
                ?? Enumerable.Empty<PedidoDTo>();
        }

        // Pedido específico

        public async Task<PedidoDTo?> GetByIdAsync(int id)

        {

            return await _httpClient

                .GetFromJsonAsync<PedidoDTo>(

                    $"api/Pedido/{id}"

                );

        }

    }

}
