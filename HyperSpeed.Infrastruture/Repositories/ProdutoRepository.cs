using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using HyperSpeed.Infrastruture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly HyperSpeedDbContext _context;

        public ProdutoRepository(HyperSpeedDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos
                .Include(p => p.Categoria) // Inclui a categoria relacionada
                .OrderBy(p => p.Nome) // Ordena por nome do produto
                .ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos
                .Include(p => p.Categoria) // Inclui a categoria relacionada
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        //talvez esse aqui não precisse
        public async Task<IEnumerable<Produto>> GetFeaturedAsync()
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.IsFeatured)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>>GetByCategoryAsync(int IdCategoria)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.IdCategoria == IdCategoria)
                .ToListAsync();
        }

        public async Task AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if(produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync()
        {
            return await _context.Produtos.CountAsync();
        }
    }
}
