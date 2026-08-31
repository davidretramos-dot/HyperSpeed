using HyperSpeed.Desktop.DTOs;
using HyperSpeed.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Desktop.Services
{
    public class CategoriasApiService
    {
        private readonly HttpClientHelper _http;

        public CategoriasApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        public async Task<List<CategoriaResponseDtos>> GetAllAsync()
        {
            try
            {
                var categorias = await _http.GetAsync<List<CategoriaResponseDtos>>("/api/categorias");
                return categorias;
            }
            catch
            {
                return new List<CategoriaResponseDtos>();
            }
        }

        public async Task<(bool success, CategoriaResponseDtos? Categoria, string ErrorMessage)>
            CreateAsync(CreateCategoriaDto dto)
        {
            return await _http.PostAsync<CategoriaResponseDtos>("/api/categorias", dto);
        }

        public async Task<(bool success, CategoriaResponseDtos? Categoria, string ErrorMessage)>
            UpdateAsync(int id, UpdateCategoriaDto dto)
        {
            return await _http.PutAsync<CategoriaResponseDtos>($"/api/categorias/{id}", dto);
        }

        public async Task<(bool success, string ErrorMessage)> DeleteAsync(int id)
        {
            return await _http.DeleteAsync($"/api/categorias/{id}");
        }
    }
}
