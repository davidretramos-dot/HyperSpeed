using HyperSpeed.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using HyperSpeed.Desktop.DTOs;

namespace HyperSpeed.Desktop.Services
{
    public class ProdutosApiService
    {
        private readonly HttpClientHelper _http;
        public ProdutosApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        public async Task<List<ProdutosDtos>> GetAllAsync()
        {
            try
            {
                var produtos = await _http.GetAsync<List<ProdutosDtos>>("/api/produtos");
                return produtos ?? new List<ProdutosDtos>();
            }
            catch
            {
                return new List<ProdutosDtos>();
            }
        }

        public async Task<ProdutosDtos?> GetAsync(int id)
        {
            return await _http.GetAsync<ProdutosDtos>($"/api/produtos/{id}");
        }

        public async Task<(bool Success, ProdutosDtos? Produto, string ErrorMessage)>
            CreateAsync(CreateProdutoDto dto)
        {
            return await _http.PostAsync<ProdutosDtos>("/api/produtos", dto);
        }

        public async Task<(bool Success, ProdutosDtos? Produto, string ErrorMessage)>
            UpdateAsync(int id, UpdateProdutoDto dto)
        {
            return await _http.PutAsync<ProdutosDtos>($"/api/produtos/{id}", dto);
        }

        public async Task<(bool Success, string ErrorMessage)> DeleteAsync(int id)
        {
            return await _http.DeleteAsync($"/api/produtos/{id}");
        }
    }
}
