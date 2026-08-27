using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Interfaces;
using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var categoria = new Categorias
            {
                Nome = dto.Nome
            };

            await _categoriaRepository.AddAsync(categoria);

            return MapToDto(categoria);
        }

        public async Task<IEnumerable<CategoriasDTo>> GetAllAsync()
        {
            var categorias = await _categoriaRepository.GetAllAsync();

            return categorias.Select(MapToDto);
        }

        public async Task<CategoriasDTo?> GetByIdAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            return categoria == null
                ? null
                : MapToDto(categoria);
        }

        public async Task<CategoriasDTo?> UpdateAsync(
            int id,
            AtualizacaoCategoriaDTo dto)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria == null)
                return null;

            categoria.Nome = dto.Nome;

            await _categoriaRepository.UpdateAsync(categoria);

            return MapToDto(categoria);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria == null)
                return false;

            await _categoriaRepository.DeleteAsync(id);

            return true;
        }

        public async Task<int> CountAsync()
        {
            return await _categoriaRepository.CountAsync();
        }

        private static CategoriasDTo MapToDto(Categorias categoria)
        {
            return new CategoriasDTo
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
        }
    }
}