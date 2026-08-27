using System.Net.Http.Json;
using hyperSpeed.Application.DTOs;

namespace HyperSpeed.UI.Services
{
    public class HttpProdutoService
    {
        private readonly HttpClient _httpClient;

        public HttpProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProdutoDTo>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDTo>>(
                "api/Produtos") ?? Enumerable.Empty<ProdutoDTo>();
        }

        public async Task<ProdutoDTo?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProdutoDTo>(
                $"api/Produtos/{id}");
        }

        public async Task<IEnumerable<ProdutoDTo>> GetByCategoryAsync(int idCategoria)
        {
            var produtos = await GetAllAsync();

            return produtos.Where(p => p.IdCategoria == idCategoria);
        }

        public async Task<IEnumerable<ProdutoDTo>> SearchAsync(string pesquisa)
        {
            var produtos = await GetAllAsync();

            if (string.IsNullOrWhiteSpace(pesquisa))
                return produtos;

            pesquisa = pesquisa.Trim();

            return produtos.Where(p =>
                p.NomeProduto.Contains(
                    pesquisa,
                    StringComparison.OrdinalIgnoreCase)
                ||
                p.Descricao.Contains(
                    pesquisa,
                    StringComparison.OrdinalIgnoreCase));
        }

        public async Task<ProdutoDTo?> CreateAsync(CriacaoProdutoDTo dto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Produtos",
                dto);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ProdutoDTo>();
        }

        public async Task<ProdutoDTo?> UpdateAsync(
            int id,
            AutualizacaoProdutoDTo dto)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/Produtos/{id}",
                dto);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ProdutoDTo>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/Produtos/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<int> CountAsync()
        {
            var produtos = await GetAllAsync();
            return produtos.Count();
        }
    }
}
