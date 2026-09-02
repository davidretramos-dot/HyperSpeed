using hyperSpeed.Application.ViewModels;

using HyperSpeed.UI.Services;

using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers

{

    public class HomeController : Controller

    {

        private readonly HttpProdutoService _produtoApi;

        public HomeController(

            HttpProdutoService produtoApi)

        {

            _produtoApi = produtoApi;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos =
                (await _produtoApi.GetAllAsync())
                .ToList();

            var destaques = produtos
                .Where(p => p.Destaque)
                .Take(4)
                .ToList();

            if (!destaques.Any())
            {
                destaques = produtos
                    .Take(4)
                    .ToList();
            }

            var model = new HomeViewModels
            {
                Produtos = produtos,

                ProdutosDestaque = destaques
            };

            return View(model);


        }

    }
}
