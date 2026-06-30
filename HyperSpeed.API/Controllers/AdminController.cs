using hyperSpeed.Application.DTOs;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.API.Controllers

{

    [ApiController]

    [Route("api/[controller]")]

    public class AuthController : ControllerBase

    {

        // UserManager: gerencia operações com usuários (criar, buscar...)

        // SignInManager: gerencia operações de autenticação (login, logout...)

        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(

            UserManager<IdentityUser> userManager,

            SignInManager<IdentityUser> signInManager)

        {

            _userManager = userManager;

            _signInManager = signInManager;

        }

        /// <summary>

        /// Registra um novo usuário.

        /// POST /api/auth/register

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

                var errors = result.Errors.Select(erro => erro.Description);

                return BadRequest(new { message = "Erro ao registrar usuário.", errors });

            }

            return Ok(new { message = "Usuário registrado com sucesso." });

        }

        /// <summary>

        /// Faz login do usuário.

        /// POST /api/auth/login

        /// </summary>

        [HttpPost("login")]

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
               
            });
        }
    }
}
 