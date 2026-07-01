using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;

namespace SeuProjeto.Controllers
{
    public class AdminController : Controller
    {
        // Dashboard
        public IActionResult Index()
        {
            return View();
        }

        // Produtos
        public IActionResult Produtos()
        {
            return View();
        }

        public IActionResult CriarProduto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarProduto(ProdutoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Salvar produto no banco

            TempData["Sucesso"] = "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Produtos));
        }

        // Categorias
        public IActionResult Categorias()
        {
            return View();
        }

        public IActionResult CriarCategoria()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarCategoria(CategoriaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Salvar categoria

            TempData["Sucesso"] = "Categoria cadastrada com sucesso!";

            return RedirectToAction(nameof(Categorias));
        }

        // Usuários
        public IActionResult Usuarios()
        {
            return View();
        }

        // Pedidos
        public IActionResult Pedidos()
        {
            return View();
        }
    }
}