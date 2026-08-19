using HyperSpeed.UI.Models;
using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;

namespace SeuProjeto.Controllers
{
    public class ContaController : Controller
    {
<<<<<<< HEAD

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ContaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
=======
        // ==========================
        // LOGIN
        // ==========================
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb

        // GET: /Conta/Login
        [HttpGet]
        public IActionResult Login()
        {
<<<<<<< HEAD
            ViewData["ReturnUrl"] = returnUrl;
            // view está em Views/Account/Login.cshtml
            return View("~/Views/Account/Login.cshtml", new LoginViewModel());
=======
            return View();
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
        }

        // POST: /Conta/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
<<<<<<< HEAD
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View("~/Views/Account/Login.cshtml", model);

            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
            return View("~/Views/Account/Login.cshtml", model);
        }

        // GET: /Conta/Register
        [HttpGet]
        public IActionResult Register()
        {
            // view está em Views/Account/Register.cshtml — retornar caminho explícito
            return View("~/Views/Account/Register.cshtml", new RegistoDto());
        }

        // POST: /Conta/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistoDto dto)
        {
            if (dto.Senha != dto.ConfirmarSenha)
            {
                ModelState.AddModelError(string.Empty, "As senhas não coincidem");
                // em caso de erro, renderiza a view correta com o DTO
                return View("~/Views/Account/Register.cshtml", dto);
            }

            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Senha);

            if (result.Succeeded)
            {
                // Faz login automático após o registro
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            // Se falhou, exibe os erros e retorna a view correta
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("~/Views/Account/Register.cshtml", dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
=======
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
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb

        // Página do acesso negado
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