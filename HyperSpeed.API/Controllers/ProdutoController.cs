using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoSerivce;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoSerivce = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTo>>> GetAll()
        {
            var games = await _produtoSerivce.GetAllAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTo>> GetById(int id)
        {
            var game = await _produtoSerivce.GetByIdAsync(id);

            if (game == null)
                return NotFound(new { message = "Produto não encontrado." });

            return Ok(game);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProdutoDTo>> Create([FromBody] CriacaoProdutoDTo dto)
        {
            var game = await _produtoSerivce.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProdutoDTo>> Update(int id, [FromBody] AutualizacaoProdutoDTo dto)
        {
            var game = await _produtoSerivce.UpdateAsync(id, dto);

            if (game == null)
                return NotFound(new { message = "Produto não encontrado." });

            return Ok(game);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _produtoSerivce.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Produto não encontrado." });

            return NoContent();
        }
    }
}

