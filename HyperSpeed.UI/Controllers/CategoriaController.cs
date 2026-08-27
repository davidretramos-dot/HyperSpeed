using hyperSpeed.Application.DTOs;
using HyperSpeed.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly HttpCategoriaService _categoriaApi;

        public CategoriasController(HttpCategoriaService categoriaApi)
        {
            _categoriaApi = categoriaApi;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaApi.GetAllAsync();

            return View(categorias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriacaoCategoriaDTo dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _categoriaApi.CreateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaApi.GetByIdAsync(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            AtualizacaoCategoriaDTo dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var categoria = await _categoriaApi.UpdateAsync(id, dto);

            if (categoria == null)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _categoriaApi.DeleteAsync(id);

            if (!sucesso)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}