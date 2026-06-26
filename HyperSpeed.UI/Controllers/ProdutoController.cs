using hyperSpeed.Application.Interfaces;
using HyperSpeed.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ILojaSerivce _produtoService;
        private readonly ICategoriasService _categoriaService;

        public ProdutoController (ILojaSerivce produtoService, ICategoriasService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index(int? IdCategoria)
        {
            var viewModel = new ProdutoListViewModel
            {
                Categorias = await _categoriaService.GetAllAsync(),
                SelectedIdCategoria = IdCategoria
            };

            if (IdCategoria.HasValue)
            {
                viewModel.Games = await _produtoService.GetByCategoryAsync(IdCategoria.Value)
            } 
            else
            {
                viewModel.Games = await _gameService.GetAllAsync();
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound();

            var relatedGames = await _gameService.GetByCategoryAsync(produto.IdCategoria);

            var viewModel = new ProdutoDetailsViewModel
            {
                Produto = produto,
                RelatedProdutos = relatedProdutos.Where(p => p.Id != produto.Id).Take(4)
            };
            return View(viewModel);
        }
    }
}
