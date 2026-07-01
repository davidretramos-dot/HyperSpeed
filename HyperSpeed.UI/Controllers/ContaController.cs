using HyperSpeed.UI.Models;
using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;

namespace SeuProjeto.Controllers
{
    public class ContaController : Controller
    {
        // ==========================
        // LOGIN
        // ==========================

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Aqui será feita a validação do usuário no banco

            // Exemplo:
            // var usuario = _context.Usuarios
            //     .FirstOrDefault(u => u.Email == model.Email
            //                       && u.Senha == model.Senha);

            // if (usuario == null)
            // {
            //     ModelState.AddModelError("", "E-mail ou senha inválidos.");
            //     return View(model);
            // }

            TempData["Sucesso"] = "Login realizado com sucesso!";

            return RedirectToAction("Index", "Home");
        }

        // ==========================
        // REGISTRO
        // ==========================

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(RegistroViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Aqui será salvo o usuário no banco

            TempData["Sucesso"] = "Conta criada com sucesso!";

            return RedirectToAction(nameof(Login));
        }

        // ==========================
        // LOGOUT
        // ==========================

        public IActionResult Logout()
        {
            // Aqui será encerrada a sessão

            TempData["Sucesso"] = "Logout realizado com sucesso!";

            return RedirectToAction("Index", "Home");
        }

        // ==========================
        // ACESSO NEGADO
        // ==========================

        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}