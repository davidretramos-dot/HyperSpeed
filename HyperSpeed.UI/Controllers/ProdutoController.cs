using System.Linq;
using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Interfaces;
using HyperSpeed.Domain.Entities;
using HyperSpeed.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriasService _categoriaService;

        public ProdutoController(IProdutoService produtoService, ICategoriasService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index(int? IdCategoria)
        {
            var viewModel = new ProdutoListViewModel
            {
                Produtos = await _produtoService.GetAllAsync(),
                Categorias = await _categoriaService.GetAllAsync(),
                SelectedIdCategoria = IdCategoria
            };

            if (IdCategoria.HasValue)
            {
                viewModel.Produtos = await _produtoService.GetByCategoryAsync(IdCategoria.Value);
            }
            else
            {
                viewModel.Categorias = await _categoriaService.GetAllAsync();
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound();

            var relatedProdutos = await _produtoService.GetByCategoryAsync(produto.IdCategoria);

            var viewModel = new ProdutoDetailsViewModel 
            {
                Produto = produto,
                RelatedProdutos = relatedProdutos.Where(p => p.Id != produto.Id).Take(4)
            };
            return View(viewModel);
        }
    }

    internal class ProdutoListViewModel
    {
        public IEnumerable<ProdutoDTo> Produtos { get; set; }
        public IEnumerable<CategoriasDTo> Categorias { get; set; }
        public int? SelectedIdCategoria { get; set; }
    }

    internal class ProdutoDetailsViewModel
    {
        public ProdutoDTo Produto { get; set; }
        public IEnumerable<ProdutoDTo> RelatedProdutos { get; set; }
    }
}
