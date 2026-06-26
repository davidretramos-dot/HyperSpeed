using Microsoft.AspNetCore.Mvc;
using HyperSpeed.Application.DTOs;
using HyperSpeed.Application.Interfaces;
using HyperSpeed.Application.ViewModels;
using HyperSpeed.Domain.interfaces;
using HyperSpeed.Domain.Entities;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;

namespace HyperSpeed.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriasService _categoriaService;

        public AdminController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoService = produtoService;
            _categoriasService = categoriasService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["ActiveMenu"] = "Dashboard";
            ViewData["Title"] = "Dashboard";
            ViewData["Subtitle"] = "Resumo do sistema HyperSpeed";

            var viewModel = new DashboardViewModel
            {
                TotalProdutos = await _produtoService.CountAsync(),
                TotalCategorias = await _categoriaService.CountAsync(),
                RecentProdutos = (await _produtoService.GetAllAsync()).Take(5)
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Produtos()
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Gerenciar Produtos";
            ViewData["Subtitle"] = "Cadastre, edite e exclua produtos do catálogo";

            var produto = await _produtoService.GetAllAsync();
            return View(games);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProd()
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Cadastrar Novo Game";

            var categorias = await _categoriaService.GetAllAsync();
            var viewModel = new ProdutoFormViewModel
            {
                Categorias = categorias,
                ReleaseYear = DateTime.Now.Year
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProd(ProdutoFormViewModel viewModel)
        {
            var dto = new CreateProdutoDto
            {
                Title = viewModel.Title,
                Descricao = viewModel.Descricao,
                ReleaseYear = viewModel.ReleaseYear,
                CoverImageUrl = viewModel.CoverImageUrl,
                IdCategorias = viewModel.IdCategorias,
            };

            await _produtoService.CreateAsync(dto);
            TempData["Sucess"] = "Produto cadastrado com sucesso";
            return RedirectToAction(nameof(Produtos));
        }

        [HttpGet]
        public async Task<IActionResult> EditProd(int id)
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Editar Produtos";

            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound();

            var categorias = await _categoriasService.GetAllAsync();
            var viewModel = new ProdutoFormViewModel
            {
                id = produto.Id,
                Title = produto.Title,
                Descricao = produto.Descricao,
                ReleaseYear = produto.ReleaseYear,
                CoverImageUrl = produto.CoverImageUrl,
                IdCategorias = produto.IdCategorias
                Categorias = categorias
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditProd(int id, ProdutoFormView viewModel)
        {
            var dto = new UpdateProdDto
            {
                Title = viewModel.Title,
                Descricao = viewModel.Descricao,
                ReleaseYear = viewModel.ReleaseYear,
                CoverImageUrl = viewModel.CoverImageUrl,
                IdCategorias = viewModel.IdCategorias
            };

            var result = await _produtoService.UpdateAsync(id, dto);

            if (result == null)
                return NotFound();
            TempData["Success"] = "Produto atualizado com sucesso!";
            return RedirectToAction(nameof(Produtos));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProd(int id)
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Excluir Produto";

            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProdConfirmed(int id)
        {
            await _produtoService.DeleteAsync(id);
            TempData["Sucess"] = "Game excluido com sucesso!";
            return RedirectToAction(nameof(Produtos));
        }

        public async Task<IActionResult> Categorias()
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Gerenciar Categorias";
            ViewData["Subtitle"] = "Cadastre, edite e exclua categorias de games";

            var categorias = await _categoriasService.GetAllAsync();
            return View(categorias);
        }

        [HttpGet]
        public IActionResult CreateCategoria()
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Nova Categoria";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategoria(CreateCategoriasDto dto)
        {
            await _categoriasService.CreateAsync(dto);
            TempData["Success"] = "Categoria cadastrada com sucesso!";
            return RedirectToAction(nameof(Categorias));
        }

        [HttpGet]
        public async Task<IActionResult> EditCategoria(int id)
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Editar Categoria";

            var categoria = await _categoriasService.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategoria(int id, UpdateCategoriasDto dto)
        {
            var result = await _categoriasService.UpdateAsync(id, dto);
            if (result == null) return NotFound();

            TempData["Success"] = "Categoria atualizada com sucesso!";
            return RedirectToAction(nameof(Categorias));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Excluir Categoria";

            var categoria = await _categoriasService.GetByIdAsync(id);
            if (categoria == null) return NotFound();

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoriaConfirmed(int id)
        {
            var deleted = await _categoriasService.DeleteAsync(id);
            if (!deleted)
            {
                TempData["Error"] = "Não foi possivel excluir a categoria. Verifique se há produtos associados. ";
                return RedirectToAction(nameof(Categorias));
            }
            TempData["Success"] = "Categoria excluirda com sucesso!";
            return RedirectToAction(nameof(Categorias));
        }
    }
}
