using HyperSpeed.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers
{
    [Authorize]
    public class FavoritoController : Controller
    {
        private readonly HttpFavoritoService _favoritoService;

        public FavoritoController(
            HttpFavoritoService favoritoService)
        {
            _favoritoService = favoritoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var favoritos =
                await _favoritoService
                    .GetMeusFavoritosAsync();

            return View(favoritos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar(
            int produtoId)
        {
            var sucesso =
                await _favoritoService
                    .AdicionarAsync(produtoId);

            if (!sucesso)
            {
                TempData["Erro"] =
                    "Não foi possível adicionar o produto aos favoritos.";

                return RedirectToAction(
                    "Index");
            }

            return RedirectToAction(
                "Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remover(
            int produtoId)
        {
            await _favoritoService
                .RemoverAsync(produtoId);

            return RedirectToAction(nameof(Index));
        }
    }
}