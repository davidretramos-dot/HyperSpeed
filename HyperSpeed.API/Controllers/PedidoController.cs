using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Services;
using HyperSpeed.Domain.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace HyperSpeed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(
            PedidoService pedidoService,
            IPedidoRepository pedidoRepository)
        {
            _pedidoService = pedidoService;
            _pedidoRepository = pedidoRepository;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoRepository.GetAllAsync();

            var pedidosDto = pedidos.Select(p => new PedidoDTo
            {
                Id = p.Id,
                Status = p.Status,
                Valor = p.ValorTotal,
                DataPedido = p.DataPedido
            });

            return Ok(pedidosDto);
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);

            if (pedido == null)
                return NotFound();

            var pedidoDto = new PedidoDTo
            {
                Id = pedido.Id,
                Status = pedido.Status,
                Valor = pedido.ValorTotal,
                DataPedido = pedido.DataPedido,

                Itens = pedido.ItemPedidos.Select(item => new ItemPedidoDTo
                {
                    ProdutoId = item.ProdutoId,
                    NomeProduto = item.Produto.Nome,
                    Quantidade = item.Quantidade,
                    PrecoUni = item.PrecoUni,
                    SubTotal = item.SubTotal
                }).ToList()
            };

            return Ok(pedidoDto);
        }

        // POST: api/Pedido/Criar
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

        // GET: api/Pedido/MeusPedidos
        [Authorize]
        [HttpGet("MeusPedidos")]
        public async Task<IActionResult> MeusPedidos()
        {
            var userId = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier
            )?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var pedidos = await _pedidoRepository
                .GetByUserIdAsync(userId);

            return Ok(pedidos);
        }
    }
}