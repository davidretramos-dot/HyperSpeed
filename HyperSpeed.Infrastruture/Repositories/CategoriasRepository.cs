using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using HyperSpeed.Infrastruture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Infrastruture.Repositories
{
   public class CategoriasRepository : ICategoriaRepository
    {
        private readonly HyperSpeedDbContext _context;

        public CategoriasRepository(HyperSpeedDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorias>> GetAllCategoriasAsync()
        {
            return await _context.Categorias
                // Inclui os produtos relacionados
                .OrderBy(c => c.Nome) // Ordena por nome da categoria
                .ToListAsync();
        }

        public async Task<Categorias?> GetCategoriaByIdAsync(int id)
        {
            return await _context.Categorias
                 // Inclui os produtos relacionados
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Categorias categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Categorias categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync()
        {
            return await _context.Categorias.CountAsync();
        } 
      public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            return await GetAllCategoriasAsync();
        }

        public async Task<Categorias?> GetByIdAsync(int id)
        {
            return await GetCategoriaByIdAsync(id);
        }
    }
}
