using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _categoriasService;

        public CategoriasController(ICategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriasDTo>>> GetAll()
        {
            var categorias = await _categoriasService.GetAllAsync();

            return Ok(categorias);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriasDTo>> GetById(int id)
        {
            var categoria = await _categoriasService.GetByIdAsync(id);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        // POST: api/Categorias
        [HttpPost]
        public async Task<ActionResult<CategoriasDTo>> Create(
            [FromBody] CriacaoCategoriaDTo dto)
        {
            var categoria = await _categoriasService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = categoria.Id },
                categoria);
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriasDTo>> Update(
            int id,
            [FromBody] AtualizacaoCategoriaDTo dto)
        {
            var categoria = await _categoriasService.UpdateAsync(id, dto);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _categoriasService.DeleteAsync(id);

            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}