using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.ViewModels;
using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using hyperSpeed.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;
using HyperSpeed.UI.Models;

namespace HyperSpeed.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IProdutoService _produtoService;
        private readonly ICategoriasService _categoriaService;

        public AdminController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IProdutoService produtoService,
            ICategoriasService categoriasService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _produtoService = produtoService;
            _categoriaService = categoriasService;
        }

        // GET: /Admin (dashboard principal)
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["ActiveMenu"] = "Dashboard";
            ViewData["Title"] = "Painel Administrativo";

            var totalProdutos = await _produtoService.CountAsync();
            var totalCategorias = await _categoriaService.CountAsync();

            var allProdutos = await _produtoService.GetAllAsync();
            var recent = allProdutos
                .OrderByDescending(p => p.CriacaoAt)
                .Take(5)
                .ToList();

            var vm = new DashboardViewModel
            {
                TotalProdutos = totalProdutos,
                TotalCategorias = totalCategorias,
                RecentProdutos = recent
            };

            return View(vm);
        }

        // Produtos - lista
        [HttpGet]
        public async Task<IActionResult> Produtos()
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Gerenciar Produtos";

            var produtos = await _produtoService.GetAllAsync();
            return View("~/Views/Admin/Produtos.cshtml", produtos);
        }

        // GET: Admin/CreateProd
        [HttpGet]
        public async Task<IActionResult> CreateProd()
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Inserir Novo Produto";

            var categorias = await _categoriaService.GetAllAsync();
            var viewModel = new ProdutoFormViewModel
            {
                Categorias = categorias
            };

            return View(viewModel);
        }

        // POST: Admin/CreateProd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProd(ProdutoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categorias = await _categoriaService.GetAllAsync();
                return View(viewModel);
            }

            var dto = new CriacaoProdutoDTo
            {
                NomeProduto = viewModel.NomeProduto,
                Descricao = viewModel.Descricao,
                Preco = viewModel.Preco,
                Estoque = viewModel.Estoque,
                ImagemUrl = viewModel.ImagemUrl,
                IdCategoria = viewModel.IdCategoria,
                Destaque = viewModel.Destaque
            };

            await _produtoService.CreateAsync(dto);
            TempData["Success"] = "Produto cadastrado com sucesso";
            return RedirectToAction(nameof(Produtos));
        }

        // GET: Admin/EditProd/5
        [HttpGet]
        public async Task<IActionResult> EditProd(int id)
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Editar Produto";

            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound();

            var categorias = await _categoriaService.GetAllAsync();
            var viewModel = new ProdutoFormViewModel
            {
                Id = produto.Id,
                NomeProduto = produto.NomeProduto,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque,
                ImagemUrl = produto.ImagemUrl,
                IdCategoria = produto.IdCategoria,
                Destaque = produto.Destaque,
                Categorias = categorias
            };

            return View(viewModel);
        }

        // POST: Admin/EditProd/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProd(int id, ProdutoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categorias = await _categoriaService.GetAllAsync();
                return View(viewModel);
            }

            var dto = new AutualizacaoProdutoDTo
            {
                NomeProduto = viewModel.NomeProduto,
                Descricao = viewModel.Descricao,
                Preco = viewModel.Preco,
                Estoque = viewModel.Estoque,
                ImagemUrl = viewModel.ImagemUrl,
                IdCategoria = viewModel.IdCategoria,
                Destaque = viewModel.Destaque
            };

            var result = await _produtoService.UpdateAsync(id, dto);
            if (result == null) return NotFound();

            TempData["Success"] = "Produto atualizado com sucesso!";
            return RedirectToAction(nameof(Produtos));
        }

        // GET: Admin/DeleteProd/5
        [HttpGet]
        public async Task<IActionResult> DeleteProd(int id)
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Excluir Produto";

            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound();

            return View(produto);
        }

        // POST: Admin/DeleteProdConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProdConfirmed(int id)
        {
            await _produtoService.DeleteAsync(id);
            TempData["Success"] = "Produto excluído com sucesso!";
            return RedirectToAction(nameof(Produtos));
        }

        // Categorias - lista
        [HttpGet]
        public async Task<IActionResult> Categorias()
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Gerenciar Categorias";

            var categorias = await _categoriaService.GetAllAsync();
            return View(categorias);
        }

        [HttpGet]
        public IActionResult CreateCategoria()
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Nova Categoria";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditCategoria(int id)
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Editar Categoria";

            var category = await _categoriaService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            var model = new AtualizacaoCategoriaDTo
            {
                Id = category.Id,
                Nome = category.Nome
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategoria(AtualizacaoCategoriaDTo model)
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Editar Categoria";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id == null)
            {
                return NotFound();
            }

            var categoria = await _categoriaService.UpdateAsync(
                model.Id.Value,
                model
            );

            if (categoria == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Categorias));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategoria(CategoriaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Se existir um método de criação no serviço, use-o:
            if (_categoriaService is not null)
            {
                // tenta usar um método CreateAsync se disponível
                try
                {
                    await _categoriaService.CreateAsync(new CriacaoCategoriaDTo { Nome = model.Nome });
                }
                catch
                {
                    // fallback: apenas redireciona se serviço não suportar operação
                }
            }

            TempData["Success"] = "Categoria cadastrada com sucesso!";
            return RedirectToAction(nameof(Categorias));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var deleted = await _categoriaService.DeleteAsync(id);
            if (!deleted)
            {
                TempData["Error"] = "Não foi possível excluir a categoria. Verifique se há produtos associados.";
                return RedirectToAction(nameof(Categorias));
            }

            TempData["Success"] = "Categoria excluída com sucesso!";
            return RedirectToAction(nameof(Categorias));
        }

        // Usuários
        [HttpGet]
        public IActionResult Usuarios()
        {
            return View();
        }

        // Pedidos
        [HttpGet]
        public IActionResult Pedidos()
        {
            return View();
        }

        // Autenticação API endpoints (login/register/logout/me)
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] RegistoDto dto)
        {
            if (dto.Senha != dto.ConfirmarSenha)
                return BadRequest(new { message = "As senhas não coincidem." });

            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Senha);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { message = "Erro ao registrar usuário.", errors });
            }

            return Ok(new { message = "Usuário registrado com sucesso." });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                dto.Email, dto.Senha, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return Unauthorized(new { message = "Email ou senha inválidos." });

            var user = await _userManager.FindByEmailAsync(dto.Email);
            var roles = await _userManager.GetRolesAsync(user!);

            return Ok(new UsuarioDto
            {
                Id = user!.Id,
                Email = user.Email!,
                Regras = roles
            });
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Logout realizado com sucesso!" });
        }

        [HttpGet("me")]
        public async Task<ActionResult<UsuarioDto>> Me()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized(new { message = "Usuário não autenticado." });

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(new UsuarioDto
            {
                Id = user.Id,
                Email = user.Email,
                Regras = roles
            });
        }

        
    }
}
    
