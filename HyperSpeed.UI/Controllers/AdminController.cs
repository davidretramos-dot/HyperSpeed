using hyperSpeed.Application.DTOs;
using HyperSpeed.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace HyperSpeed.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        // =====================================================
        // DASHBOARD
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");

            var produtos = await client
                .GetFromJsonAsync<List<ProdutoDTo>>(
                    "api/Produtos"
                ) ?? new List<ProdutoDTo>();


            var categorias = await client
                .GetFromJsonAsync<List<CategoriasDTo>>(
                    "api/Categorias"
                ) ?? new List<CategoriasDTo>();


            var model = new DashboardViewModel
            {
                TotalProdutos = produtos.Count,
                TotalCategorias = categorias.Count,

                RecentProdutos = produtos
                    .Take(5)
                    .ToList()
            };

            return View(model);
        }


        // =====================================================
        // PRODUTOS - LISTA
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> Produtos()
        {
            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");

            var produtos = await client
                .GetFromJsonAsync<List<ProdutoDTo>>(
                    "api/Produtos"
                );

            return View(
                produtos ?? new List<ProdutoDTo>()
            );
        }


        // =====================================================
        // CREATE PRODUTO - GET
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> CreateProd()
        {
            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");

            var categorias = await client
                .GetFromJsonAsync<List<CategoriasDTo>>(
                    "api/Categorias"
                ) ?? new List<CategoriasDTo>();


            var model = new ProdutoFormViewModel
            {
                Categorias = categorias
            };

            return View(model);
        }


        // =====================================================
        // CREATE PRODUTO - POST
        // =====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProd(
            ProdutoFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var clientCategorias =
                    _httpClientFactory.CreateClient("HyperSpeedAPI");

                model.Categorias = await clientCategorias
                    .GetFromJsonAsync<List<CategoriasDTo>>(
                        "api/Categorias"
                    ) ?? new List<CategoriasDTo>();

                return View(model);
            }


            var dto = new CriacaoProdutoDTo
            {
                NomeProduto = model.NomeProduto,
                Descricao = model.Descricao,
                Preco = model.Preco,
                Estoque = model.Estoque,
                IdCategoria = model.IdCategoria,
                ImagemUrl = model.ImagemUrl,
                Destaque = model.Destaque
            };


            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");

            var response = await client.PostAsJsonAsync(
                "api/Produtos",
                dto
            );


            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(
                    "",
                    "Não foi possível cadastrar o produto."
                );

                model.Categorias = await client
                    .GetFromJsonAsync<List<CategoriasDTo>>(
                        "api/Categorias"
                    ) ?? new List<CategoriasDTo>();

                return View(model);
            }


            TempData["Sucesso"] =
                "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Produtos));
        }


        // =====================================================
        // EDIT PRODUTO - GET
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> EditProd(int id)
        {
            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");


            var produto = await client
                .GetFromJsonAsync<ProdutoDTo>(
                    $"api/Produtos/{id}"
                );


            if (produto == null)
                return NotFound();


            var categorias = await client
                .GetFromJsonAsync<List<CategoriasDTo>>(
                    "api/Categorias"
                ) ?? new List<CategoriasDTo>();


            var model = new ProdutoFormViewModel
            {
                Id = produto.Id,

                NomeProduto = produto.NomeProduto,

                Descricao = produto.Descricao,

                Preco = produto.Preco,

                Estoque = produto.Estoque,

                IdCategoria = produto.IdCategoria,

                ImagemUrl = produto.ImagemUrl,

                Destaque = produto.Destaque,

                Categorias = categorias
            };


            return View(model);
        }


        // =====================================================
        // EDIT PRODUTO - POST
        // =====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProd(
            ProdutoFormViewModel model)
        {
            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");


            if (!ModelState.IsValid)
            {
                model.Categorias = await client
                    .GetFromJsonAsync<List<CategoriasDTo>>(
                        "api/Categorias"
                    ) ?? new List<CategoriasDTo>();

                return View(model);
            }


            var dto = new AutualizacaoProdutoDTo
            {
                NomeProduto = model.NomeProduto,
                Descricao = model.Descricao,
                Preco = model.Preco,
                Estoque = model.Estoque,
                IdCategoria = model.IdCategoria,
                ImagemUrl = model.ImagemUrl,
                Destaque = model.Destaque
            };


            var response = await client.PutAsJsonAsync(
                $"api/Produtos/{model.Id}",
                dto
            );


            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(
                    "",
                    "Não foi possível atualizar o produto."
                );

                model.Categorias = await client
                    .GetFromJsonAsync<List<CategoriasDTo>>(
                        "api/Categorias"
                    ) ?? new List<CategoriasDTo>();

                return View(model);
            }


            TempData["Sucesso"] =
                "Produto atualizado com sucesso!";


            return RedirectToAction(nameof(Produtos));
        }


        // =====================================================
        // DELETE PRODUTO
        // =====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProd(int id)
        {
            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");


            var response = await client.DeleteAsync(
                $"api/Produtos/{id}"
            );


            if (response.IsSuccessStatusCode)
            {
                TempData["Sucesso"] =
                    "Produto excluído com sucesso!";
            }
            else
            {
                TempData["Erro"] =
                    "Não foi possível excluir o produto.";
            }


            return RedirectToAction(nameof(Produtos));
        }


        // =====================================================
        // CATEGORIAS - LISTA
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> Categorias()
        {
            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");


            var categorias = await client
                .GetFromJsonAsync<List<CategoriasDTo>>(
                    "api/Categorias"
                );


            return View(
                categorias ?? new List<CategoriasDTo>()
            );
        }


        // =====================================================
        // CREATE CATEGORIA - GET
        // =====================================================

        [HttpGet]
        public IActionResult CreateCategoria()
        {
            return View(
                new CriacaoCategoriaDTo()
            );
        }


        // =====================================================
        // CREATE CATEGORIA - POST
        // =====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategoria(
            CriacaoCategoriaDTo dto)
        {
            if (!ModelState.IsValid)
                return View(dto);


            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");


            var response = await client.PostAsJsonAsync(
                "api/Categorias",
                dto
            );


            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(
                    "",
                    "Não foi possível cadastrar a categoria."
                );

                return View(dto);
            }


            TempData["Sucesso"] =
                "Categoria cadastrada com sucesso!";


            return RedirectToAction(
                nameof(Categorias)
            );
        }


        // =====================================================
        // EDIT CATEGORIA - GET
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> EditCategoria(
            int id)
        {
            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");


            var categoria = await client
                .GetFromJsonAsync<CategoriasDTo>(
                    $"api/Categorias/{id}"
                );


            if (categoria == null)
                return NotFound();


            var model =
                new AtualizacaoCategoriaDTo
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };


            return View(model);
        }


        // =====================================================
        // EDIT CATEGORIA - POST
        // =====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategoria(
            AtualizacaoCategoriaDTo dto)
        {
            if (!ModelState.IsValid)
                return View(dto);


            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");


            var response = await client.PutAsJsonAsync(
                $"api/Categorias/{dto.Id}",
                dto
            );


            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(
                    "",
                    "Não foi possível atualizar a categoria."
                );

                return View(dto);
            }


            TempData["Sucesso"] =
                "Categoria atualizada com sucesso!";


            return RedirectToAction(
                nameof(Categorias)
            );
        }


        // =====================================================
        // DELETE CATEGORIA
        // =====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoria(
            int id)
        {
            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");


            var response = await client.DeleteAsync(
                $"api/Categorias/{id}"
            );


            if (response.IsSuccessStatusCode)
            {
                TempData["Sucesso"] =
                    "Categoria excluída com sucesso!";
            }
            else
            {
                TempData["Erro"] =
                    "Não foi possível excluir a categoria.";
            }


            return RedirectToAction(
                nameof(Categorias)
            );
        }
    }
}