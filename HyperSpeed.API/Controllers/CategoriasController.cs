using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriasService _categoriasService;

        public CategoriasController(ICategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriasDTo>>> GetAll()
        {
            var categorias = await _categoriasService.GetAllAsync();
            return Ok(categorias);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoriasDTo>> Create([FromBody] CriacaoCategoriaDTo dto)
        {
            var category = await _categoriasService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = category.Id }, category);
        }
    }
}
