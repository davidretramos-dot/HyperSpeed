using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Interfaces;
using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace hyperSpeed.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _ProdutoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _ProdutoRepository = produtoRepository;
        }

        public async Task<ProdutoDTo> CreateAsync(
            CriacaoProdutoDTo dto)
        {
            var produto = new Produto
            {
                Nome = dto.NomeProduto,
                Descricao = dto.Descricao,
                Imagem = dto.ImagemUrl,
                IdCategoria = dto.IdCategoria,
                Preco = dto.Preco,
                Estoque = dto.Estoque,
                Destaque = dto.Destaque,

                CriacaoAt = DateTime.Now
            };

            await _ProdutoRepository.AddAsync(produto);

            return MapToDTo(produto);
        }

        public async Task<ProdutoDTo?> UpdateAsync(
            int id,
            AutualizacaoProdutoDTo dto)
        {
            var produto =
                await _ProdutoRepository.GetByIdAsync(id);

            if (produto == null)
                return null;

            produto.Nome = dto.NomeProduto;
            produto.Descricao = dto.Descricao;
            produto.Imagem = dto.ImagemUrl;
            produto.IdCategoria = dto.IdCategoria;
            produto.Preco = dto.Preco;
            produto.Estoque = dto.Estoque;
            produto.Destaque = dto.Destaque;

            await _ProdutoRepository.UpdateAsync(produto);

            return MapToDTo(produto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Produto = await _ProdutoRepository.GetByIdAsync(id);
            if (Produto == null)
            {
                return false;
            }

            await _ProdutoRepository.DeleteAsync(id);
            return true;
        }

        // Adicione este método na sua classe ProdutoService
        public static ProdutoDTo MapToDTo(Produto produto)
        {
            return new ProdutoDTo
            {
                Id = produto.Id,

                NomeProduto = produto.Nome,

                Descricao = produto.Descricao,

                ImagemUrl = produto.Imagem,

                IdCategoria = produto.IdCategoria,

                NomeCategoria =
                    produto.Categoria?.Nome ?? "Sem categoria",

                Preco = (int)produto.Preco,

                Estoque = produto.Estoque,

                CriacaoAt = produto.CriacaoAt,

                Destaque = produto.Destaque
            };
        }

        public async Task<ProdutoDTo?> GetByIdAsync(int id)
        {
            var produto = await _ProdutoRepository.GetByIdAsync(id);
            return produto == null ? null : MapToDTo(produto);
        }

        public async Task<IEnumerable<ProdutoDTo>> GetByCategoryAsync(int categoriasId)
        {
            var produtos = await _ProdutoRepository.GetAllAsync();
            return produtos
                .Where(p => p.IdCategoria == categoriasId).Select(MapToDTo);
        }

        public async Task<int> CountAsync()
        {
            return await _ProdutoRepository.CountAsync();
        }

        public async Task<IEnumerable<ProdutoDTo>> GetAllAsync()
        {
            var produtos = await _ProdutoRepository.GetAllAsync();
            return produtos.Select(MapToDTo);
        }

        public async Task<IEnumerable<ProdutoDTo>> GetFeaturedAsync()
        {
            // Exemplo: Retorna os produtos com base em algum critério de destaque.
            var produtos = await _ProdutoRepository.GetAllAsync();

            return produtos.Take(5).Select(MapToDTo);
        }

        public async Task<IEnumerable<ProdutoDTo>> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Enumerable.Empty<ProdutoDTo>();

            var produtos = await _ProdutoRepository.GetAllAsync();
            var termos = query.Trim().ToLowerInvariant();

            return produtos
                .Where(p =>
                    (!string.IsNullOrEmpty(p.Nome) && p.Nome.ToLowerInvariant().Contains(termos)) ||
                    (!string.IsNullOrEmpty(p.Descricao) && p.Descricao.ToLowerInvariant().Contains(termos)))
                .Select(MapToDTo);
        }
    }
}