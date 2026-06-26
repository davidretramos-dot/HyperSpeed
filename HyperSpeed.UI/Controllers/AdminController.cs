using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.ViewModels;
using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using Microsoft.AspNetCore.Authorization;
<<<<<<< Updated upstream
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
=======
using hyperSpeed.Application.Interfaces;
>>>>>>> Stashed changes

namespace HyperSpeed.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
<<<<<<< Updated upstream
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AdminController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
=======
        private readonly ILojaSerivce _produtoService;
        private readonly ICategoriasService _categoriaService;

        public AdminController(ILojaSerivce produtoService, ICategoriasService categoriasService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriasService;
>>>>>>> Stashed changes
        }

        /// <summary>
        /// Registra um novo usuário.
        /// POST /api/admin/register
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegistoDto dto)
        {
            // validação de senha
            if (dto.Senha != dto.ConfirmarSenha)
                return BadRequest(new { message = "As senhas não coincidem." });

            var user = new IdentityUser
            {
<<<<<<< Updated upstream
                UserName = dto.Email,
                Email = dto.Email
=======
                TotalProdutos = await _produtoService.CountAsync(),
                TotalCategorias = await _categoriaService.CountAsync(),
                RecentProdutos = (await _produtoService.GetAllAsync()).Take(5)
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Produtos()
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Gerenciar Produtos";
            ViewData["Subtitle"] = "Cadastre, edite e exclua produtos do catálogo";

            var produto = await _produtoService.GetAllAsync();
            return View(produto);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProd()
        {
            ViewData["ActiveMenu"] = "Produtos";
            ViewData["Title"] = "Cadastrar Novo Game";

            var categorias = await _categoriaService.GetAllAsync();
            var viewModel = new ProdutoFormViewModel
            {
                Categorias = categorias,
                ReleaseYear = DateTime.Now.Year
>>>>>>> Stashed changes
            };

            // Cria o usuário usando o UserManager
            var result = await _userManager.CreateAsync(user, dto.Senha);

            if (!result.Succeeded)
            {
<<<<<<< Updated upstream
                var errors = result.Errors.Select(erros => erros.Description);
                return BadRequest(new { message = "Erro ao registrar usuário.", errors });
=======
                Title = viewModel.Title,
                Descricao = viewModel.Descricao,
                ReleaseYear = viewModel.ReleaseYear,
                CoverImageUrl = viewModel.CoverImageUrl,
                IdCategorias = viewModel.IdCategorias,
            };

            await _produtoService.CreateAsync(dto);
            TempData["Sucess"] = "Produto cadastrado com sucesso";
            return RedirectToAction(nameof(Produtos));
        }

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
                id = produto.Id,
                Title = produto.Title,
                Descricao = produto.Descricao,
                ReleaseYear = produto.ReleaseYear,
                CoverImageUrl = produto.CoverImageUrl,
                IdCategorias = produto.IdCategorias
                Categorias = categorias
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditProd(int id, ProdutoFormView viewModel)
        {
            var dto = new UpdateProdutoDto
            {
                Title = viewModel.Title,
                Descricao = viewModel.Descricao,
                ReleaseYear = viewModel.ReleaseYear,
                CoverImageUrl = viewModel.CoverImageUrl,
                IdCategorias = viewModel.IdCategorias
            };

            var result = await _produtoService.UpdateAsync(id, dto);

            if (result == null)
                return NotFound();
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
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProdConfirmed(int id)
        {
            await _produtoService.DeleteAsync(id);
            TempData["Sucess"] = "Game excluido com sucesso!";
            return RedirectToAction(nameof(Produtos));
        }

        public async Task<IActionResult> Categorias()
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Gerenciar Categorias";
            ViewData["Subtitle"] = "Cadastre, edite e exclua categorias de games";

            var categorias = await _categoriaService.GetAllAsync();
            return View(categorias);
        }

        [HttpGet]
        public IActionResult CreateCategoria()
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Nova Categoria";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategoria(CreateCategoriasDto dto)
        {
            await _categoriaService.CreateAsync(dto);
            TempData["Success"] = "Categoria cadastrada com sucesso!";
            return RedirectToAction(nameof(Categorias));
        }

        [HttpGet]
        public async Task<IActionResult> EditCategoria(int id)
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Editar Categoria";

            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategoria(int id, UpdateCategoriasDto dto)
        {
            var result = await _categoriaService.UpdateAsync(id, dto);
            if (result == null) return NotFound();

            TempData["Success"] = "Categoria atualizada com sucesso!";
            return RedirectToAction(nameof(Categorias));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            ViewData["ActiveMenu"] = "Categorias";
            ViewData["Title"] = "Excluir Categoria";

            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null) return NotFound();

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoriaConfirmed(int id)
        {
            var deleted = await _categoriaService.DeleteAsync(id);
            if (!deleted)
            {
                TempData["Error"] = "Não foi possivel excluir a categoria. Verifique se há produtos associados. ";
                return RedirectToAction(nameof(Categorias));
>>>>>>> Stashed changes
            }
            return Ok(new { message = "Usuário registrado com sucesso." });
        }

        ///<summary>
        /// Faz login do usuário.
        /// POST /api/admin/login
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                dto.Email, dto.Senha, isPersistent: false, lockoutOnFailure: false);
            // isPersistent: se o cookie de autenticação deve ser persistente
            // lockoutOnFailure: se deve bloquear a conta após falhas consecutivas de login
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
        /// POST /api/admin/logout
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
        /// GET /api/admin/me
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

        // --- classes auxiliares existentes no arquivo (mantive conforme estavam) ---

        public class ProdutoFormView
        {

        }

        internal class UpdateProdDto : AutualizacaoProdutoDTo
        {
            public object Title { get; set; }
            public object Descricao { get; set; }
            public object ReleaseYear { get; set; }
            public object CoverImageUrl { get; set; }
            public object IdCategorias { get; set; }
        }

        internal class ProdutoFormViewModel
        {
            public IEnumerable<CategoriasDTo> Categorias { get; set; }
            public int ReleaseYear { get; set; }
        }

        internal class DashboardViewModel
        {
            public int TotalProdutos { get; set; }
            public int TotalCategorias { get; set; }
            public IEnumerable<ProdutoDTo> RecentProdutos { get; set; }
        }
    }
}