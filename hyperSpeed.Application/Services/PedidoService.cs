using hyperSpeed.Application.DTOs;
using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
namespace hyperSpeed.Application.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PedidoService(
            IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Pedido> CriarPedidoAsync(CreatePedidoDto dto)
        {
            var userId = _httpContextAccessor.HttpContext?
                .User
                .FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?
                .Value;

            if (string.IsNullOrEmpty(userId))
                throw new Exception("Usuário não autenticado.");

            var pedido = new Pedido
            {
                UserId = userId
            };

            decimal total = 0;

            foreach (var itemDto in dto.Itens)
            {
                var produto = await _produtoRepository
                    .GetByIdAsync(itemDto.ProdutoId);

                if (produto == null)
                    throw new Exception(
                        $"Produto {itemDto.ProdutoId} não encontrado"
                    );

                var subtotal = produto.Preco * itemDto.Quantidade;

                var itemPedido = new ItemPedido
                {
                    ProdutoId = produto.Id,
                    Quantidade = itemDto.Quantidade,
                    PrecoUni = produto.Preco,
                    SubTotal = subtotal
                };

                pedido.ItemPedidos.Add(itemPedido);

                total += subtotal;
            }

            pedido.ValorTotal = total;

            await _pedidoRepository.AddAsync(pedido);

            return pedido;
        }


        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _pedidoRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Pedido>> MeusPedidosAsync(string userId)
        {
            return await _pedidoRepository.GetByUserIdAsync(userId);
        }
    }
}
