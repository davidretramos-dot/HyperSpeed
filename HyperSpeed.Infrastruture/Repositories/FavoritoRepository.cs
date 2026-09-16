using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using HyperSpeed.Infrastruture.Context;
using Microsoft.EntityFrameworkCore;

namespace HyperSpeed.Infrastruture.Repositories
{
    public class FavoritoRepository : IFavoritoRepository
    {
        private readonly HyperSpeedDbContext _context;

        public FavoritoRepository(HyperSpeedDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorito>> GetByUserIdAsync(
            string userId)
        {
            return await _context.Favoritos
                .Include(f => f.Produto)
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        public async Task<Favorito?> GetAsync(
            string userId,
            int produtoId)
        {
            return await _context.Favoritos
                .FirstOrDefaultAsync(f =>
                    f.UserId == userId &&
                    f.ProdutoId == produtoId);
        }

        public async Task AddAsync(Favorito favorito)
        {
            await _context.Favoritos.AddAsync(favorito);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Favorito favorito)
        {
            _context.Favoritos.Remove(favorito);
            await _context.SaveChangesAsync();
        }
    }
}