using hyperSpeed.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HyperSpeed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FavoritoController : ControllerBase
    {
        private readonly FavoritoService _favoritoService;

        public FavoritoController(
            FavoritoService favoritoService)
        {
            _favoritoService = favoritoService;
        }

        // GET: api/Favorito/MeusFavoritos
        [HttpGet("MeusFavoritos")]
        public async Task<IActionResult> MeusFavoritos()
        {
            var userId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var favoritos =
                await _favoritoService
                    .GetMeusFavoritosAsync(userId);

            return Ok(favoritos);
        }

        // POST: api/Favorito/5
        [HttpPost("{produtoId}")]
        public async Task<IActionResult> Adicionar(
            int produtoId)
        {
            var userId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
                await _favoritoService.AdicionarAsync(
                    userId,
                    produtoId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    erro = ex.Message
                });
            }
        }

        // DELETE: api/Favorito/5
        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> Remover(
            int produtoId)
        {
            var userId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            await _favoritoService.RemoverAsync(
                userId,
                produtoId);

            return NoContent();
        }
    }
}