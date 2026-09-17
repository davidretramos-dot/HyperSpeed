using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;

namespace hyperSpeed.Application.Services
{
    public class FavoritoService
    {
        private readonly IFavoritoRepository _favoritoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public FavoritoService(
            IFavoritoRepository favoritoRepository,
            IProdutoRepository produtoRepository)
        {
            _favoritoRepository = favoritoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Favorito>> GetMeusFavoritosAsync(
            string userId)
        {
            return await _favoritoRepository
                .GetByUserIdAsync(userId);
        }

        public async Task AdicionarAsync(
            string userId,
            int produtoId)
        {
            var produto = await _produtoRepository
                .GetByIdAsync(produtoId);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            var existente = await _favoritoRepository
                .GetAsync(userId, produtoId);

            if (existente != null)
                return;

            var favorito = new Favorito
            {
                UserId = userId,
                ProdutoId = produtoId
            };

            await _favoritoRepository.AddAsync(favorito);
        }

        public async Task RemoverAsync(
            string userId,
            int produtoId)
        {
            var favorito = await _favoritoRepository
                .GetAsync(userId, produtoId);

            if (favorito == null)
                return;

            await _favoritoRepository.DeleteAsync(favorito);
        }
    }
}