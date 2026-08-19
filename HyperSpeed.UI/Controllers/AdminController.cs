<<<<<<< HEAD
﻿using System;
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
=======
﻿using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb

namespace SeuProjeto.Controllers
{
    public class AdminController : Controller
    {
<<<<<<< HEAD
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

        // GET: /Admin
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            ViewData["ActiveMenu"] = "Dashboard";
            ViewData["Title"] = "Painel Administrativo";

            var totalProdutos = await _produtoService.CountAsync();
            var totalCategorias = await _categoriaService.CountAsync(); // fallback if different name
            // fallback safe call in case method name or service differs
            if (totalCategorias == 0)
            {
                totalCategorias = await _categoriaService.CountAsync();
            }

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

        /// <summary>
        /// Registra um novo usuário.
        /// POST /Admin/Register
        /// </summary>
        [HttpPost("register")]
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
=======
        // Dashboard
        public IActionResult Index()
        {
            return View();
        }

        // Produtos
        public IActionResult Produtos()
        {
            return View();
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
        }

        public IActionResult CriarProduto()
        {
<<<<<<< HEAD
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Gerenciar Produtos";
            ViewData["Subtitle"] = "Cadastre, edite e exclua produtos do catálogo";

            var produtos = await _produtoService.GetAllAsync();

            // A view se chama "Produto.cshtml" na pasta Views/Admin.
            // Força o caminho para evitar erro de procura por "Produtos.cshtml".
            return View("~/Views/Admin/Produto.cshtml", produtos);
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

            // usa convenção: Views/Admin/CreateProd.cshtml
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
            ViewData["Title"] = "Editar Produtos";

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

            // usa convenção: Views/Admin/EditProd.cshtml
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

        [HttpGet]
        public async Task<IActionResult> DeleteProd(int id)
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Excluir Produto";

            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound();

            // usa convenção: Views/Admin/DeleteProd.cshtml
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProdConfirmed(int id)
        {
            await _produtoService.DeleteAsync(id);
            TempData["Success"] = "Produto excluído com sucesso!";
            return RedirectToAction(nameof(Produtos));
        }

        public async Task<IActionResult> Categorias()
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Gerenciar Categorias";
            ViewData["Subtitle"] = "Cadastre, edite e exclua categorias dos Produtos";

            var categorias = await _categoriaService.GetAllAsync();
            return View(categorias);
        }

        [HttpGet]
        public IActionResult CreateCategoria()
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Nova Categoria";
=======
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> CreateCategoria(CriacaoCategoriaDTo dto)
=======
        public IActionResult CriarProduto(ProdutoViewModel model)
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
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
<<<<<<< HEAD
        public async Task<IActionResult> EditCategoria(int id, AtualizacaoCategoriaDTo dto)
=======
        public IActionResult CriarCategoria(CategoriaViewModel model)
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
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
<<<<<<< HEAD
            var deleted = await _categoriaService.DeleteAsync(id);
            if (!deleted)
            {
                TempData["Error"] = "Não foi possível excluir a categoria. Verifique se há produtos associados.";
                return RedirectToAction(nameof(Categorias));
            }

            TempData["Success"] = "Categoria excluída com sucesso!";
            return RedirectToAction(nameof(Categorias));
        }

        ///<summary>
        /// Faz login do usuário.
        /// POST /Admin/Login
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                dto.Email, dto.Senha, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Email ou senha inválidos." });
            }

            var user = await _userManager.FindByEmailAsync(dto.Email);
            var roles = await _userManager.GetRolesAsync(user!);

            return Ok(new UsuarioDto
            {
                Id = user!.Id,
                Email = user.Email!,
                Regras = roles
            });
        }

        /// <summary>
        /// Faz logout do usuário
        /// POST /Admin/Logout
        /// </summary>
        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Logout realizado com sucesso!" });
        }

        /// <summary>
        /// Retorna os dados do usuário autenticado
        /// GET /Admin/Me
        /// </summary>
        [HttpGet("me")]
        [Authorize]
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

        // --- classes auxiliares ---
        public class ProdutoFormViewModel
        {
            public int? Id { get; set; }
            public string NomeProduto { get; set; } = string.Empty;
            public string Descricao { get; set; } = string.Empty;
            public int Preco { get; set; }
            public int Estoque { get; set; }
            public string ImagemUrl { get; set; } = string.Empty;
            public int IdCategoria { get; set; }
            public bool Destaque { get; set; }
            public IEnumerable<CategoriasDTo> Categorias { get; set; } = Enumerable.Empty<CategoriasDTo>();
        }

        public class DashboardViewModel
        {
            public int TotalProdutos { get; set; }
            public int TotalCategorias { get; set; }
            public IEnumerable<ProdutoDTo> RecentProdutos { get; set; } = Enumerable.Empty<ProdutoDTo>();
=======
            return View();
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
        }
    }
}