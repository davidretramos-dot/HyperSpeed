using hyperSpeed.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using hyperSpeed.Application.ViewModels;
using static System.Net.Mime.MediaTypeNames;


namespace HyperSpeed.UI.Controllers
{
    public class ContaController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ContaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Conta/Login
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View("~/Views/Account/Login.cshtml", new LoginViewModel());
        }

        // POST: /Conta/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View("~/Views/Account/Login.cshtml", model);

            // Buscamos sempre pelo e-mail: o UserName pode ter sido alterado
            // em "Editar Perfil" e não é mais garantido que seja igual ao e-mail.
            var usuarioParaLogin = await _userManager.FindByEmailAsync(model.Email);

            var result = usuarioParaLogin == null
                ? Microsoft.AspNetCore.Identity.SignInResult.Failed
                : await _signInManager.PasswordSignInAsync(
                    usuarioParaLogin, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
            return View("~/Views/Account/Login.cshtml", model);
        }

        // GET: /Conta/EsqueciSenha
        [HttpGet]
        public IActionResult EsqueciSenha()
        {
            return View("~/Views/Account/EsqueciSenha.cshtml", new EsqueciSenhaViewModel());
        }

        // POST: /Conta/EsqueciSenha
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EsqueciSenha(EsqueciSenhaViewModel model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/EsqueciSenha.cshtml", model);

            var usuario = await _userManager.FindByEmailAsync(model.Email);

            if (usuario == null)
            {
                // Não revelamos se o e-mail existe ou não na base.
                ModelState.AddModelError(string.Empty,
                    "Se este e-mail estiver cadastrado, você poderá continuar a recuperação.");

                return View("~/Views/Account/EsqueciSenha.cshtml", model);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

            var redefinirModel = new RedefinirSenhaViewModel
            {
                Email = model.Email,
                Token = token
            };

            // Versão acadêmica: o token é exibido na própria tela,
            // já preenchido, em vez de ser enviado por e-mail.
            TempData["TokenGerado"] = "true";

            return View("~/Views/Account/RedefinirSenha.cshtml", redefinirModel);
        }

        // GET: /Conta/RedefinirSenha
        [HttpGet]
        public IActionResult RedefinirSenha(string? email = null, string? token = null)
        {
            var model = new RedefinirSenhaViewModel
            {
                Email = email ?? string.Empty,
                Token = token ?? string.Empty
            };

            return View("~/Views/Account/RedefinirSenha.cshtml", model);
        }

        // POST: /Conta/RedefinirSenha
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RedefinirSenha(RedefinirSenhaViewModel model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/RedefinirSenha.cshtml", model);

            var usuario = await _userManager.FindByEmailAsync(model.Email);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário não encontrado.");
                return View("~/Views/Account/RedefinirSenha.cshtml", model);
            }

            var resultado = await _userManager.ResetPasswordAsync(
                usuario, model.Token, model.NovaSenha);

            if (!resultado.Succeeded)
            {
                foreach (var erro in resultado.Errors)
                    ModelState.AddModelError(string.Empty, erro.Description);

                return View("~/Views/Account/RedefinirSenha.cshtml", model);
            }

            TempData["Sucesso"] = "Senha redefinida com sucesso! Faça login com sua nova senha.";
            return RedirectToAction(nameof(Login));
        }

        // GET: /Conta/Register
        [HttpGet]
        public IActionResult Register()
        {
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
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View("~/Views/Account/Register.cshtml", dto);
        }

        // POST: /Conta/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["Sucesso"] = "Logout realizado com sucesso!";
            return RedirectToAction("Index", "Home");
        }

        // Acesso negado
        [HttpGet]
        public IActionResult AcessDenied()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login");

            var model = new PerfilViewModel
            {
                Nome = user.UserName ?? "",
                Email = user.Email ?? "",
                IsAdmin = User.IsInRole("Admin")
            };

            return View("~/Views/Account/Perfil.cshtml", model);
        }

        // GET: /Conta/EditarPerfil
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditarPerfil()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction(nameof(Login));

            var model = new EditarPerfilViewModel
            {
                Nome = user.UserName ?? "",
                Email = user.Email ?? "",
                IsAdmin = User.IsInRole("Admin")
            };

            return View("~/Views/Account/EditarPerfil.cshtml", model);
        }

        // POST: /Conta/EditarPerfil
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarPerfil(EditarPerfilViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction(nameof(Login));

            model.IsAdmin = User.IsInRole("Admin");

            if (!ModelState.IsValid)
                return View("~/Views/Account/EditarPerfil.cshtml", model);

            // E-mail em uso por outra conta?
            var emailAlterado = !string.Equals(
                user.Email, model.Email, StringComparison.OrdinalIgnoreCase);

            if (emailAlterado)
            {
                var usuarioComEsseEmail = await _userManager.FindByEmailAsync(model.Email);

                if (usuarioComEsseEmail != null && usuarioComEsseEmail.Id != user.Id)
                {
                    ModelState.AddModelError(
                        nameof(model.Email),
                        "Este e-mail já está em uso por outra conta.");

                    return View("~/Views/Account/EditarPerfil.cshtml", model);
                }
            }

            var nomeResult = await _userManager.SetUserNameAsync(user, model.Nome);

            if (!nomeResult.Succeeded)
            {
                foreach (var erro in nomeResult.Errors)
                    ModelState.AddModelError(string.Empty, erro.Description);

                return View("~/Views/Account/EditarPerfil.cshtml", model);
            }

            if (emailAlterado)
            {
                var emailResult = await _userManager.SetEmailAsync(user, model.Email);

                if (!emailResult.Succeeded)
                {
                    foreach (var erro in emailResult.Errors)
                        ModelState.AddModelError(string.Empty, erro.Description);

                    return View("~/Views/Account/EditarPerfil.cshtml", model);
                }
            }

            // Mantém o cookie de login coerente com os novos dados.
            await _signInManager.RefreshSignInAsync(user);

            TempData["Sucesso"] = "Perfil atualizado com sucesso!";
            return RedirectToAction(nameof(Perfil));
        }
    }
}