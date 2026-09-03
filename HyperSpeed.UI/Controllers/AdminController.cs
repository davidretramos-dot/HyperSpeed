using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.ViewModels;
using HyperSpeed.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace HyperSpeed.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpProdutoService _produtoApi;
        private readonly HttpCategoriaService _categoriaApi;

        public AdminController(
            HttpProdutoService produtoApi,
            HttpCategoriaService categoriaApi,
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _produtoApi = produtoApi;
            _categoriaApi = categoriaApi;
        }


        // =====================================================
        // DASHBOARD
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client =
                _httpClientFactory.CreateClient("HyperSpeedAPI");

            // Busca produtos pela API
            var produtos = await client
                .GetFromJsonAsync<List<ProdutoDTo>>(
                    "api/Produtos"
                ) ?? new List<ProdutoDTo>();

            // Busca categorias pela API
            var categorias = await client
                .GetFromJsonAsync<List<CategoriasDTo>>(
                    "api/Categorias"
                ) ?? new List<CategoriasDTo>();

            // Relaciona cada produto com sua categoria
            foreach (var produto in produtos)
            {
                var categoria = categorias
                    .FirstOrDefault(c => c.Id == produto.IdCategoria);

                produto.NomeCategoria =
                    categoria?.Nome ?? "Sem categoria";
            }

            var model = new DashboardViewModel
            {
                TotalProdutos = produtos.Count,

                TotalCategorias = categorias.Count,

                RecentProdutos = produtos
                    .OrderByDescending(p => p.CriacaoAt)
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
                var erroApi = await response.Content.ReadAsStringAsync();

                ModelState.AddModelError(
                    "",
                    $"Erro da API: {erroApi}"
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
        // DELETE PRODUTO - GET
        // =====================================================
        [HttpGet]

        public async Task<IActionResult> DeleteProd(int id)

        {

            var produto = await _produtoApi.GetByIdAsync(id);

            if (produto == null)

                return NotFound();

            return View(

                "~/Views/Admin/DeleteProd.cshtml",

                produto

            );

        }



        // =====================================================
        // DELETE PRODUTO - POST
        // =====================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProdConfirmed(int id)
        {
            var sucesso = await _produtoApi.DeleteAsync(id);

            if (!sucesso)
            {
                TempData["Erro"] =
                    "Não foi possível excluir o produto.";

                return RedirectToAction(
                    nameof(DeleteProd),
                    new { id }
                );
            }

            TempData["Sucesso"] =
                "Produto removido com sucesso!";

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
                ) ?? new List<CategoriasDTo>();

            return View(
                "~/Views/Admin/Categorias.cshtml",
                categorias
            );
        }


        // =====================================================

        // CREATE CATEGORIA - GET

        // =====================================================

        [HttpGet]

        public IActionResult CreateCategoria()

        {

            return View(

                "~/Views/Admin/CreateCategoria.cshtml",

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

            {

                return View(

                    "~/Views/Admin/CreateCategoria.cshtml",

                    dto

                );

            }

            var categoria = await _categoriaApi.CreateAsync(dto);

            if (categoria == null)

            {

                ModelState.AddModelError(

                    "",

                    "Não foi possível cadastrar a categoria."

                );

                return View(

                    "~/Views/Admin/CreateCategoria.cshtml",

                    dto

                );

            }

            TempData["Sucesso"] =

                "Categoria cadastrada com sucesso!";

            return RedirectToAction(nameof(Categorias));

        }


        // =====================================================

        // EDIT CATEGORIA - GET

        // =====================================================

        [HttpGet]

        public async Task<IActionResult> EditCategoria(int id)

        {

            var categoria =

                await _categoriaApi.GetByIdAsync(id);

            if (categoria == null)

            {

                return NotFound();

            }

            var model = new AtualizacaoCategoriaDTo

            {

                Id = categoria.Id,

                Nome = categoria.Nome

            };

            return View(

                "~/Views/Admin/EditCategoria.cshtml",

                model

            );

        }


        // =====================================================

        // EDIT CATEGORIA - POST

        // =====================================================

        [HttpPost]

        [ValidateAntiForgeryToken]

        [ActionName("EditCategoria")]

        public async Task<IActionResult> EditCategoriaConfirmed(

            AtualizacaoCategoriaDTo dto)

        {

            if (!ModelState.IsValid)

            {

                return View(

                    "~/Views/Admin/EditCategoria.cshtml",

                    dto

                );

            }

            var categoria = await _categoriaApi.UpdateAsync(

                dto.Id,

                dto

            );

            if (categoria == null)

            {

                ModelState.AddModelError(

                    "",

                    "Não foi possível atualizar a categoria."

                );

                return View(

                    "~/Views/Admin/EditCategoria.cshtml",

                    dto

                );

            }

            TempData["Sucesso"] =

                "Categoria atualizada com sucesso!";

            return RedirectToAction(nameof(Categorias));

        }

        // =====================================================

        // DELETE CATEGORIA - GET

        // =====================================================

        [HttpGet]

        public async Task<IActionResult> DeleteCategoria(int id)

        {

            var categoria = await _categoriaApi.GetByIdAsync(id);

            if (categoria == null)

            {

                return NotFound();

            }

            return View(

                "~/Views/Admin/DeleteCategoria.cshtml",

                categoria

            );

        }
        // =====================================================
        // DELETE CATEGORIA - POST
        // =====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteCategoria")]
        public async Task<IActionResult> DeleteCategoriaConfirmed(int id)
        {
            var sucesso = await _categoriaApi.DeleteAsync(id);

            if (!sucesso)
            {
                TempData["Erro"] =
                    "Não foi possível excluir a categoria.";

                return RedirectToAction(
                    nameof(DeleteCategoria),
                    new { id }
                );
            }

            TempData["Sucesso"] =
                "Categoria excluída com sucesso!";

            return RedirectToAction(nameof(Categorias));
        }

    }
}