using hyperSpeed.Application.DTOs;
using HyperSpeed.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            // view está em Views/Account/Login.cshtml
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

        // Página do acesso negado
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
