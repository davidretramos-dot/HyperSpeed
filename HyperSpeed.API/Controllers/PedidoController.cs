using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Services;
using HyperSpeed.Domain.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        private readonly IPedidoRepository _pedidoRepository;



        public PedidoController(PedidoService pedidoService,

            IPedidoRepository pedidoRepository)
        {
            _pedidoService = pedidoService;


            _pedidoRepository = pedidoRepository;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);

            if (pedido == null)
            {
                return NotFound();

            }
            return Ok(pedido);

        }
        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(CreatePedidoDto dto)
        {
            try
            {
                var pedido =
                    await _pedidoService.CriarPedidoAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = pedido.Id },
                    pedido
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    erro = ex.Message,
                    detalhes = ex.InnerException?.Message
                });
            }
        }
    }
}