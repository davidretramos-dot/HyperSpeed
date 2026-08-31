using hyperSpeed.Application.DTOs;
using HyperSpeed.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly HttpCategoriaService _categoriaApi;

        public CategoriaController(
            HttpCategoriaService categoriaApi)
        {
            _categoriaApi = categoriaApi;
        }


        // =========================
        // LISTAGEM
        // =========================

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias =
                await _categoriaApi.GetAllAsync();

            return View(categorias);
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