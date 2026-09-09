using hyperSpeed.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuariosController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTo>>> GetAll()
        {
            var usuarios = _userManager.Users.ToList();

            var resultado = new List<ClienteDTo>();

            foreach (var usuario in usuarios)
            {
                var roles = await _userManager.GetRolesAsync(usuario);

                resultado.Add(new ClienteDTo
                {
                    Id = usuario.Id,
                    Name = usuario.UserName ?? string.Empty,
                    Email = usuario.Email ?? string.Empty,
                    Perfil = roles.FirstOrDefault() ?? string.Empty
                });
            }

            return Ok(resultado);
        }

        // GET: api/usuarios/perfis
        [HttpGet("perfis")]
        public async Task<ActionResult<IEnumerable<string>>> GetPerfis()
        {
            var perfis = _roleManager.Roles
                .Select(r => r.Name!)
                .Where(n => !string.IsNullOrEmpty(n))
                .ToList();

            return Ok(perfis);
        }

        // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult<ClienteDTo>> Create(
            [FromBody] CriarClienteDTo dto)
        {
            if (dto.Senha != dto.ConfirmarSenha)
                return BadRequest(new
                {
                    message = "As senhas não coincidem."
                });

            if (string.IsNullOrWhiteSpace(dto.Perfil))
                return BadRequest(new
                {
                    message = "Selecione um perfil."
                });

            if (!await _roleManager.RoleExistsAsync(dto.Perfil))
                return BadRequest(new
                {
                    message = "O perfil informado não existe."
                });

            var usuario = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(
                usuario,
                dto.Senha);

            if (!result.Succeeded)
            {
                var erros = result.Errors
                    .Select(e => e.Description)
                    .ToList();

                return BadRequest(new
                {
                    message = "Não foi possível criar o usuário.",
                    errors = erros
                });
            }

            await _userManager.AddToRoleAsync(
                usuario,
                dto.Perfil);

            var response = new ClienteDTo
            {
                Id = usuario.Id,
                Name = usuario.UserName ?? string.Empty,
                Email = usuario.Email ?? string.Empty,
                Perfil = dto.Perfil
            };

            return Ok(response);
        }

        // PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDTo>> Update(
            string id,
            [FromBody] AutualizacaoClienteDTo dto)
        {
            var usuario = await _userManager.FindByIdAsync(id);

            if (usuario == null)
                return NotFound(new
                {
                    message = "Usuário não encontrado."
                });

            usuario.UserName = dto.Email;
            usuario.Email = dto.Email;

            var result = await _userManager.UpdateAsync(usuario);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Não foi possível atualizar o usuário.",
                    errors = result.Errors.Select(e => e.Description)
                });
            }

            if (!string.IsNullOrWhiteSpace(dto.Senha))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

                var passwordResult =
                    await _userManager.ResetPasswordAsync(
                        usuario,
                        token,
                        dto.Senha);

                if (!passwordResult.Succeeded)
                {
                    return BadRequest(new
                    {
                        message = "Usuário atualizado, mas não foi possível alterar a senha.",
                        errors = passwordResult.Errors.Select(e => e.Description)
                    });
                }
            }

            var rolesAtuais = await _userManager.GetRolesAsync(usuario);
            if (!string.IsNullOrWhiteSpace(dto.Perfil))
            {
              if (!await _roleManager.RoleExistsAsync(dto.Perfil))
                 return BadRequest(new
                 {
                  message = "O perfil informado não existe."
                 });

                await _userManager.AddToRoleAsync(
                usuario,
                dto.Perfil);
            }
            if (rolesAtuais.Any())
            {
                await _userManager.RemoveFromRolesAsync(
                    usuario,
                    rolesAtuais);
            }

            

            var response = new ClienteDTo
            {
                Id = usuario.Id,
                Name = usuario.UserName ?? string.Empty,
                Email = usuario.Email ?? string.Empty,
                Perfil = dto.Perfil ?? string.Empty
            };

            return Ok(response);
        }

        // DELETE: api/usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);

            if (usuario == null)
                return NotFound(new
                {
                    message = "Usuário não encontrado."
                });

            var result = await _userManager.DeleteAsync(usuario);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Não foi possível excluir o usuário.",
                    errors = result.Errors.Select(e => e.Description)
                });
            }

            return NoContent();
        }
    }
}