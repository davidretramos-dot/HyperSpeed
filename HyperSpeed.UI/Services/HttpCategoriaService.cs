using System.Net.Http.Json;
using hyperSpeed.Application.DTOs;
namespace HyperSpeed.UI.Services
{
    public class HttpCategoriaService
    {
        private readonly HttpClient _httpClient;

        public HttpCategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoriasDTo>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CategoriasDTo>>(
                "api/Categorias") ?? Enumerable.Empty<CategoriasDTo>();
        }

        public async Task<CategoriasDTo?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CategoriasDTo>(
                $"api/Categorias/{id}");
        }

        public async Task<CategoriasDTo?> CreateAsync(
            CriacaoCategoriaDTo dto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Categorias",
                dto);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<CategoriasDTo>();
        }
        public async Task<CategoriasDTo?> UpdateAsync(
    int id,
    AtualizacaoCategoriaDTo dto)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/Categorias/{id}",
                dto);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content
                .ReadFromJsonAsync<CategoriasDTo>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/Categorias/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}

