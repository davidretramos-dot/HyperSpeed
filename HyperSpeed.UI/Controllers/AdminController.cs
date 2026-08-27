using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.ViewModels;
using HyperSpeed.UI.Models;
using HyperSpeed.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;

namespace HyperSpeed.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly HttpProdutoService _produtoApi;
        private readonly HttpCategoriaService _categoriaApi;

        public AdminController(
            HttpProdutoService produtoApi,
            HttpCategoriaService categoriaApi)
        {
            _produtoApi = produtoApi;
            _categoriaApi = categoriaApi;
        }

        // ============================================================
        // DASHBOARD
        // ============================================================

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["ActiveMenu"] = "Dashboard";
            ViewData["Title"] = "Painel Administrativo";

            var produtos = await _produtoApi.GetAllAsync();
            var categorias = await _categoriaApi.GetAllAsync();

            var recent = produtos
                .OrderByDescending(p => p.CriacaoAt)
                .Take(5)
                .ToList();

            var vm = new DashboardViewModel
            {
                TotalProdutos = produtos.Count(),
                TotalCategorias = categorias.Count(),
                RecentProdutos = recent
            };

            return View(vm);
        }

        // ============================================================
        // PRODUTOS
        // ============================================================

        [HttpGet]
        public async Task<IActionResult> Produtos()
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Gerenciar Produtos";

            var produtos = await _produtoApi.GetAllAsync();

            return View("~/Views/Admin/Produtos.cshtml", produtos);
        }

        // Criar produto - GET
        [HttpGet]
        public async Task<IActionResult> CreateProd()
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Inserir Novo Produto";

            var categorias = await _categoriaApi.GetAllAsync();

            var viewModel = new ProdutoFormViewModel
            {
                Categorias = categorias
            };

            return View(viewModel);
        }

        // Criar produto - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProd(
            ProdutoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categorias =
                    await _categoriaApi.GetAllAsync();

                return View(viewModel);
            }

            var dto = new CriacaoProdutoDTo
            {
                NomeProduto = viewModel.NomeProduto,
                Descricao = viewModel.Descricao,
                Preco = viewModel.Preco,
                Estoque = viewModel.Estoque,
                ImagemUrl = viewModel.ImagemUrl,
                IdCategoria = viewModel.IdCategoria,
                Destaque = viewModel.Destaque
            };

            var produto = await _produtoApi.CreateAsync(dto);

            if (produto == null)
            {
                ModelState.AddModelError(
                    "",
                    "Não foi possível cadastrar o produto.");

                viewModel.Categorias =
                    await _categoriaApi.GetAllAsync();

                return View(viewModel);
            }

            TempData["Success"] =
                "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Produtos));
        }

        // Editar produto - GET
        [HttpGet]
        public async Task<IActionResult> EditProd(int id)
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Editar Produto";

            var produto = await _produtoApi.GetByIdAsync(id);

            if (produto == null)
                return NotFound();

            var categorias = await _categoriaApi.GetAllAsync();

            var viewModel = new ProdutoFormViewModel
            {
                Id = produto.Id,
                NomeProduto = produto.NomeProduto,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque,
                ImagemUrl = produto.ImagemUrl,
                IdCategoria = produto.IdCategoria,
                Destaque = produto.Destaque,
                Categorias = categorias
            };

            return View(viewModel);
        }

        // Editar produto - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProd(
            int id,
            ProdutoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categorias =
                    await _categoriaApi.GetAllAsync();

                return View(viewModel);
            }

            var dto = new AutualizacaoProdutoDTo
            {
                NomeProduto = viewModel.NomeProduto,
                Descricao = viewModel.Descricao,
                Preco = viewModel.Preco,
                Estoque = viewModel.Estoque,
                ImagemUrl = viewModel.ImagemUrl,
                IdCategoria = viewModel.IdCategoria,
                Destaque = viewModel.Destaque
            };

            var result =
                await _produtoApi.UpdateAsync(id, dto);

            if (result == null)
                return NotFound();

            TempData["Success"] =
                "Produto atualizado com sucesso!";

            return RedirectToAction(nameof(Produtos));
        }

        // Excluir produto - GET
        [HttpGet]
        public async Task<IActionResult> DeleteProd(int id)
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Excluir Produto";

            var produto = await _produtoApi.GetByIdAsync(id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // Excluir produto - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProdConfirmed(int id)
        {
            var sucesso = await _produtoApi.DeleteAsync(id);

            if (!sucesso)
            {
                TempData["Error"] =
                    "Não foi possível excluir o produto.";

                return RedirectToAction(nameof(Produtos));
            }

            TempData["Success"] =
                "Produto excluído com sucesso!";

            return RedirectToAction(nameof(Produtos));
        }

        // ============================================================
        // CATEGORIAS
        // ============================================================

        [HttpGet]
        public async Task<IActionResult> Categorias()
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Gerenciar Categorias";

            var categorias = await _categoriaApi.GetAllAsync();

            return View(categorias);
        }

        // Criar categoria - GET
        [HttpGet]
        public IActionResult CreateCategoria()
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Nova Categoria";

            return View();
        }

        // Criar categoria - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategoria(
            CategoriaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new CriacaoCategoriaDTo
            {
                Nome = model.Nome
            };

            var categoria =
                await _categoriaApi.CreateAsync(dto);

            if (categoria == null)
            {
                ModelState.AddModelError(
                    "",
                    "Não foi possível cadastrar a categoria.");

                return View(model);
            }

            TempData["Success"] =
                "Categoria cadastrada com sucesso!";

            return RedirectToAction(nameof(Categorias));
        }

        // Editar categoria - GET
        [HttpGet]
        public async Task<IActionResult> EditCategoria(int id)
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Editar Categoria";

            var categoria =
                await _categoriaApi.GetByIdAsync(id);

            if (categoria == null)
                return NotFound();

            var model = new AtualizacaoCategoriaDTo
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };

            return View(model);
        }

        // Editar categoria - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategoria(
            AtualizacaoCategoriaDTo model)
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Editar Categoria";

            if (!ModelState.IsValid)
                return View(model);

            if (model.Id == null)
                return NotFound();

            var categoria =
                await _categoriaApi.UpdateAsync(
                    model.Id.Value,
                    model);

            if (categoria == null)
                return NotFound();

            TempData["Success"] =
                "Categoria atualizada com sucesso!";

            return RedirectToAction(nameof(Categorias));
        }

        // Excluir categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var deleted =
                await _categoriaApi.DeleteAsync(id);

            if (!deleted)
            {
                TempData["Error"] =
                    "Não foi possível excluir a categoria. " +
                    "Verifique se há produtos associados.";

                return RedirectToAction(nameof(Categorias));
            }

            TempData["Success"] =
                "Categoria excluída com sucesso!";

            return RedirectToAction(nameof(Categorias));
        }

        // ============================================================
        // USUÁRIOS
        // ============================================================

        [HttpGet]
        public IActionResult Usuarios()
        {
            return View();
        }

        // ============================================================
        // PEDIDOS
        // ============================================================

        [HttpGet]
        public IActionResult Pedidos()
        {
            return View();
        }
    }
}