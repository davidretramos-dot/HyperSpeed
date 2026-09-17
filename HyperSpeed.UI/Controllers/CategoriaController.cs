using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.ViewModels;
using HyperSpeed.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly HttpCategoriaService _categoriaApi;
        private readonly HttpProdutoService _produtoApi;

        public CategoriaController(
            HttpCategoriaService categoriaApi,
            HttpProdutoService produtoApi)
        {
            _categoriaApi = categoriaApi;
            _produtoApi = produtoApi;
        }


        // =========================
        // LISTAGEM
        // =========================

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias =
                await _categoriaApi.GetAllAsync();

            var produtos =
                await _produtoApi.GetAllAsync();


            var model = new CategoriaListViewModel
            {
                Categorias = categorias,

                TotalPorCategoria = produtos
                    .GroupBy(p => p.IdCategoria)
                    .ToDictionary(g => g.Key, g => g.Count())
            };


            return View(model);
        }


        // =========================
        // PRODUTOS DE UMA CATEGORIA
        // =========================

        [HttpGet]
        public async Task<IActionResult> Produtos(
            int id,
            string? pesquisa = null,
            string? ordem = null)
        {
            var categorias =
                (await _categoriaApi.GetAllAsync()).ToList();


            var categoria =
                categorias.FirstOrDefault(c => c.Id == id);

            if (categoria == null)
                return NotFound();


            var produtos =
                await _produtoApi.GetByCategoryAsync(id);


            // Filtro por texto dentro da categoria
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                var termo = pesquisa.Trim();

                produtos = produtos.Where(p =>
                    p.NomeProduto.Contains(
                        termo,
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    p.Descricao.Contains(
                        termo,
                        StringComparison.OrdinalIgnoreCase));
            }


            // Ordenacao
            produtos = ordem switch
            {
                "menor" => produtos.OrderBy(p => p.Preco),

                "maior" => produtos.OrderByDescending(p => p.Preco),

                "nome" => produtos.OrderBy(p => p.NomeProduto),

                _ => produtos
                        .OrderByDescending(p => p.Destaque)
                        .ThenBy(p => p.NomeProduto)
            };


            var model = new CategoriaProdutosViewModel
            {
                Categoria = categoria,
                Categorias = categorias,
                Produtos = produtos.ToList(),
                Pesquisa = pesquisa,
                Ordem = ordem
            };


            return View(model);
        }


        // =========================
        // CRIAÇÃO
        // =========================

        [HttpGet]
        public IActionResult Create()
        {
            return View(
                new CriacaoCategoriaDTo()
            );
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            CriacaoCategoriaDTo dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var categoria =
                await _categoriaApi.CreateAsync(dto);

            if (categoria == null)
            {
                ModelState.AddModelError(
                    "",
                    "Não foi possível criar a categoria."
                );

                return View(dto);
            }

            TempData["Sucesso"] =
                "Categoria cadastrada com sucesso!";

            return RedirectToAction(
                nameof(Index)
            );
        }


        // =========================
        // EDIÇÃO
        // =========================

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categoria =
                await _categoriaApi.GetByIdAsync(id);

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            AtualizacaoCategoriaDTo dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }


            var categoria =
                await _categoriaApi.UpdateAsync(
                    id,
                    dto
                );


            if (categoria == null)
                return NotFound();


            TempData["Sucesso"] =
                "Categoria atualizada com sucesso!";


            return RedirectToAction(
                nameof(Index)
            );
        }


        // =========================
        // EXCLUSÃO
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso =
                await _categoriaApi.DeleteAsync(id);


            if (!sucesso)
                return NotFound();


            TempData["Sucesso"] =
                "Categoria excluída com sucesso!";


            return RedirectToAction(
                nameof(Index)
            );
        }
    }
}