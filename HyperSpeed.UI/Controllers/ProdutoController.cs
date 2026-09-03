using hyperSpeed.Application.DTOs;
using HyperSpeed.Domain.Entities;
using HyperSpeed.UI.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using hyperSpeed.Application.ViewModels;

namespace HyperSpeed.UI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly HttpProdutoService _produtoApi;
        private readonly HttpCategoriaService _categoriaApi;

        public ProdutoController(
            HttpProdutoService produtoApi,
            HttpCategoriaService categoriaApi)
        {
            _produtoApi = produtoApi;
            _categoriaApi = categoriaApi;
        }

        // Lista de produtos
        [HttpGet]
        public async Task<IActionResult> Index(
            int? idCategoria = null,
            string? pesquisa = null)
        {
            IEnumerable<ProdutoDTo> produtosDto;

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                produtosDto = await _produtoApi.SearchAsync(pesquisa);
            }
            else if (idCategoria.HasValue)
            {
                produtosDto = await _produtoApi.GetByCategoryAsync(
                    idCategoria.Value);
            }
            else
            {
                produtosDto = await _produtoApi.GetAllAsync();
            }

            var categorias = await _categoriaApi.GetAllAsync();

            var produtos = produtosDto.Select(d => new Produto
            {
                Id = d.Id,
                Nome = d.NomeProduto,
                Descricao = d.Descricao,
                Preco = d.Preco,
                Estoque = d.Estoque,
                Imagem = d.ImagemUrl,
                IdCategoria = d.IdCategoria,
                Categoria = null
            });

            var model = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaNome = categorias
                    .FirstOrDefault(c => c.Id == idCategoria)?.Nome,

                CategoriaId = idCategoria,
                Pesquisa = pesquisa
            };

            return View(model);
        }

        // Detalhes
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoApi.GetByIdAsync(id);

            if (produto == null)
                return NotFound();

            var related = await _produtoApi.GetByCategoryAsync(
                produto.IdCategoria);

            var relatedFiltered = related
                .Where(p => p.Id != produto.Id)
                .Take(4);

            var model = new ProdutoDetailsViewModel
            {
                Produto = produto,
                RelatedProdutos = relatedFiltered
            };

            return View(model);
        }

        // Página de cadastro
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categorias = await _categoriaApi.GetAllAsync();

            ViewBag.Categorias = categorias;

            return View("~Views/Admin/CreateProd.cshtml",new ProdutoViewModel());
        }

        // Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias =
                    await _categoriaApi.GetAllAsync();

                return View("~Views/Admin/CreateProd.cshtml",model);
            }

            var dto = new CriacaoProdutoDTo
            {
                NomeProduto = model.Nome,
                Descricao = model.Descricao,
                Preco = model.Preco,
                Estoque = model.Estoque,
                ImagemUrl = model.ImagemUrl,
                IdCategoria = model.CategoriaId
            };

            var produto = await _produtoApi.CreateAsync(dto);

            if (produto == null)
            {
                ModelState.AddModelError(
                    "",
                    "Não foi possível cadastrar o produto.");

                ViewBag.Categorias =
                    await _categoriaApi.GetAllAsync();

                return View(model);
            }

            TempData["Sucesso"] = "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        // Página de edição
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtoApi.GetByIdAsync(id);

            if (produto == null)
                return NotFound();

            var categorias = await _categoriaApi.GetAllAsync();

            ViewBag.Categorias = categorias;

            var model = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.NomeProduto,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque,
                CategoriaId = produto.IdCategoria,
                ImagemUrl = produto.ImagemUrl
            };

            return View("~Views/Admin/EditProd.cshtml", model);
        }

        // Atualização
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            ProdutoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias =
                    await _categoriaApi.GetAllAsync();

                return View("~Views/Admin/EditProd.cshtml", model);
            }

            var dto = new AutualizacaoProdutoDTo
            {
                NomeProduto = model.Nome,
                Descricao = model.Descricao,
                Preco = model.Preco,
                Estoque = model.Estoque,
                ImagemUrl = model.ImagemUrl,
                IdCategoria = model.CategoriaId
            };

            var produto = await _produtoApi.UpdateAsync(id, dto);

            if (produto == null)
                return NotFound();

            TempData["Sucesso"] = "Produto atualizado!";

            return RedirectToAction(nameof(Index));
        }

        // Página de confirmação de exclusão
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoApi.GetByIdAsync(id);

            if (produto == null)
                return NotFound();

            var model = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.NomeProduto,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque,
                CategoriaId = produto.IdCategoria,
                ImagemUrl = produto.ImagemUrl
            };

            return View(
                "~/Views/Admin/DeleteProd.cshtml",
                model
            );
        }

        // Exclusão
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucesso = await _produtoApi.DeleteAsync(id);

            if (!sucesso)
                return NotFound();

            TempData["Sucesso"] = "Produto removido com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        // Promoções
        [HttpGet]
        public IActionResult Promocoes()
        {
            return RedirectToAction(nameof(Index));
        }

        // Periféricos
        [HttpGet]
        public IActionResult Perifericos()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}