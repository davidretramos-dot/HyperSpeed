using hyperSpeed.Application.ViewModels;
using hyperSpeed.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriasService _categoriasService;

        public HomeController(IProdutoService produtoService, ICategoriasService categoriasService)
        {
            _produtoService = produtoService;
            _categoriasService = categoriasService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModels
            {
                Categorias = await _categoriasService.GetAllAsync(),
                ProdutosRecentes = await _produtoService.GetAllAsync(),
            };
            return View(viewModel);
        }
    }
}
