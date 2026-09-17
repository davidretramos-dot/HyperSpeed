using HyperSpeed.Domain.Entities;

namespace HyperSpeed.Domain.interfaces
{
    public interface IFavoritoRepository
    {
        Task<IEnumerable<Favorito>> GetByUserIdAsync(string userId);

        Task<Favorito?> GetAsync(
            string userId,
            int produtoId);

        Task AddAsync(Favorito favorito);

        Task DeleteAsync(Favorito favorito);
    }
}