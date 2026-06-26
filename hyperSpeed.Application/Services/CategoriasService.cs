using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Interfaces;
using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.Services
{
    public class CategoriasService : ICategoriasService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<CategoriasDTo> CreateAsync(CriacaoCategoriaDTo dto)
        {
            var categorias = new Categorias { Nome = dto.Nome };
            await _categoriaRepository.AddAsync(categorias);
            return MapToDto(categorias);
        }
        public async Task<IEnumerable<CategoriasDTo>> GetAllAsync()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            return categorias.Select(MapToDto);
        }

        public async Task<CategoriasDTo?> GetByIdAsync(int id)
        {
            var categorias = await _categoriaRepository.GetByIdAsync(id);
            return categorias == null ? null : MapToDto(categorias);
        }

        public async Task<CategoriasDTo> CreateAsync(AtualizacaoCategoriaDTo dto)
        {
            var categorias = new Categorias { Nome = dto.Nome };
            await _categoriaRepository.AddAsync(categorias);
            return MapToDto(categorias);
        }

        public async Task<CategoriasDTo?> UpdateAsync(int id, AtualizacaoCategoriaDTo dto)
        {
            var category = await _categoriaRepository.GetByIdAsync(id);
            if (category == null) return null;

            category.Nome = dto.Nome;
            await _categoriaRepository.UpdateAsync(category);
            return MapToDto(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoriaRepository.GetByIdAsync(id);
            if (category == null) return false;

            await _categoriaRepository.DeleteAsync(id);
            return true;
        }

        public async Task<int> CountAsync()
        {
            return await _categoriaRepository.CountAsync();
        }

      
        private static CategoriasDTo MapToDto(Categorias categorias)
        {
            return new CategoriasDTo
            {
                Id = categorias.Id,
                Nome = categorias.Nome,
            };
        }
    }
}
