using HyperSpeed.Domain.Entities;
using System.Net.Http.Json;

namespace HyperSpeed.UI.Services
{
    public class HttpFavoritoService
    {
        private readonly HttpClient _httpClient;

        public HttpFavoritoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Favorito>> GetMeusFavoritosAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<IEnumerable<Favorito>>(
                    "api/Favorito/MeusFavoritos")
                ?? Enumerable.Empty<Favorito>();
        }

        public async Task<bool> AdicionarAsync(int produtoId)
        {
            var response = await _httpClient
                .PostAsync(
                    $"api/Favorito/{produtoId}",
                    null);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoverAsync(int produtoId)
        {
            var response = await _httpClient
                .DeleteAsync(
                    $"api/Favorito/{produtoId}");

            return response.IsSuccessStatusCode;
        }
    }
}