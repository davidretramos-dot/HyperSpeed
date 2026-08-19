<<<<<<< HEAD
﻿using System.Linq;
using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Interfaces;
using HyperSpeed.Domain.Entities;
using HyperSpeed.UI.Models;
using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;
using HyperSpeed.Domain.Entities; // ou namespace correto
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb

namespace SeuProjeto.Controllers
{
    public class ProdutoController : Controller
    {
<<<<<<< HEAD
        private readonly IProdutoService _produtoService;
        private readonly ICategoriasService _categoriaService;

        public ProdutoController(IProdutoService produtoService, ICategoriasService categoriaService)
=======
        // Lista de produtos
        [HttpGet]
        public IActionResult Index()
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
        {
            var model = new ProdutoListViewModel
            {
<<<<<<< HEAD
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
=======
                Produtos = new List<Produto>
                {
                    new Produto
                    {
                        Id = 1,
                        Nome = "Ryzen 7 7700X",
                        Descricao = "Processador AMD Ryzen 7",
                        Preco = 1999.90m,
                        Estoque = 10,
                        IdCategoria = 1,
                        Imagem = "/images/produtos/cpu-amd.png"
                    },
                    new Produto
                    {
                        Id = 2,
                        Nome = "RTX 4070",
                        Descricao = "Placa de vídeo NVIDIA",
                        Preco = 4299.90m,
                        Estoque = 5,
                        IdCategoria = 2,
                        Imagem = "/images/produtos/gpu.png"
                    }
                }
            };

            return View(model);
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
        }

        // Detalhes do produto
        [HttpGet]
        public IActionResult Details(int id)
        {
<<<<<<< HEAD
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound();

            var relatedProdutos = await _produtoService.GetByCategoryAsync(produto.IdCategoria);

            var viewModel = new ProdutoDetailsViewModel 
=======
            var produto = new ProdutoDetailsViewModel
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
            {
                Id = id,
                Nome = "Ryzen 7 7700X",
                Descricao = "Processador AMD Ryzen 7 7700X",
                Preco = 1999.90m,
                Estoque = 10,
                Categoria = "Processadores",
                ImagemUrl = "/images/produtos/cpu-amd.png"
            };

            return View(produto);
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

            // Salvar no banco futuramente

            TempData["Sucesso"] = "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        // Editar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = new ProdutoViewModel
            {
                Id = id,
                Nome = "Ryzen 7 7700X",
                Descricao = "Processador AMD",
                Preco = 1999.90m,
                Estoque = 10,
                CategoriaId = 1,
                ImagemUrl = "/images/produtos/cpu-amd.png"
            };

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProdutoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Atualizar no banco

            TempData["Sucesso"] = "Produto atualizado!";

            return RedirectToAction(nameof(Index));
        }

        // Excluir
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var produto = new ProdutoViewModel
            {
                Id = id,
                Nome = "Ryzen 7 7700X"
            };

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Remover do banco

            TempData["Sucesso"] = "Produto removido!";

            return RedirectToAction(nameof(Index));
        }

        // Pesquisa
        [HttpGet]
        public IActionResult Pesquisa(string pesquisa)
        {
            var model = new ProdutoListViewModel
            {
                Pesquisa = pesquisa,
                Produtos = new List<Produto>() // antes: new List<ProdutoViewModel>()
            };

            return View("Index", model);
        }

        // Promoções
        [HttpGet]
        public IActionResult Promocoes()
        {
            return View("Index");
        }

        // Periféricos
        [HttpGet]
        public IActionResult Perifericos()
        {
            return View("Index");
        }
    }
<<<<<<< HEAD

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
=======
}
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
