using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;

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

        // Lista de produtos (opcionalmente por categoria ou pesquisa)
        [HttpGet]
        public async Task<IActionResult> Index(int? idCategoria = null, string? pesquisa = null)
        {
            IEnumerable<ProdutoDTo> produtos;
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                produtos = await _produtoService.SearchAsync(pesquisa);
            }
            else if (idCategoria.HasValue)
            {
                produtos = await _produtoService.GetByCategoryAsync(idCategoria.Value);
            }
            else
            {
                produtos = await _produtoService.GetAllAsync();
            }

            var categorias = await _categoriaService.GetAllAsync();

            var model = new ProdutoListViewModel
            {
                Produtos = produtos,
                Categorias = categorias,
                SelectedIdCategoria = idCategoria,
                Pesquisa = pesquisa
            };

            return View(model);
        }

        // Detalhes do produto
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound();

            var related = await _produtoService.GetByCategoryAsync(produto.IdCategoria);
            var relatedFiltered = related.Where(p => p.Id != produto.Id).Take(4);

            var model = new ProdutoDetailsViewModel
            {
                Produto = produto,
                RelatedProdutos = relatedFiltered
            };

            return View(model);
        }

        // Página de cadastro
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProdutoViewModel());
        }

        // Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // TODO: salvar usando _produtoService.CreateAsync(...)
            TempData["Sucesso"] = "Produto cadastrado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        // Editar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // TODO: buscar dados reais via _produtoService.GetByIdAsync(id)
            var produto = new ProdutoViewModel
            {
                Id = id,
                Nome = "Exemplo",
                Descricao = string.Empty,
                Preco = 0m,
                Estoque = 0,
                CategoriaId = 0,
                ImagemUrl = string.Empty
            };

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProdutoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // TODO: atualizar via _produtoService.UpdateAsync(...)
            TempData["Sucesso"] = "Produto atualizado!";
            return RedirectToAction(nameof(Index));
        }

        // Excluir
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var produto = new ProdutoViewModel { Id = id, Nome = "Exemplo" };
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: remover via _produtoService.DeleteAsync(id)
            TempData["Sucesso"] = "Produto removido!";
            return RedirectToAction(nameof(Index));
        }

        // Promoções / Periféricos (apontam para lista ou filtros)
        [HttpGet]
        public IActionResult Promocoes() => RedirectToAction(nameof(Index));

        [HttpGet]
        public IActionResult Perifericos() => RedirectToAction(nameof(Index));
    }

    internal class ProdutoListViewModel
    {
        public IEnumerable<ProdutoDTo> Produtos { get; set; } = Enumerable.Empty<ProdutoDTo>();
        public IEnumerable<CategoriasDTo> Categorias { get; set; } = Enumerable.Empty<CategoriasDTo>();
        public int? SelectedIdCategoria { get; set; }
        public string? Pesquisa { get; set; }
    }

    internal class ProdutoDetailsViewModel
    {
        public ProdutoDTo Produto { get; set; } = null!;
        public IEnumerable<ProdutoDTo> RelatedProdutos { get; set; } = Enumerable.Empty<ProdutoDTo>();
    }
}