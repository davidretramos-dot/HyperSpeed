using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.ViewModels;
using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HyperSpeed.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AdminController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                UserName = dto.Email,
                Email = dto.Email
            };

            // Cria o usuário usando o UserManager
            var result = await _userManager.CreateAsync(user, dto.Senha);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(erros => erros.Description);
                return BadRequest(new { message = "Erro ao registrar usuário.", errors });
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