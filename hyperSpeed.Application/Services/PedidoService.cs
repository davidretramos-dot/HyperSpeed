using hyperSpeed.Application.DTOs;
using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace hyperSpeed.Application.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }
        public async Task<Pedido> CriarPedidoAsync(CreatePedidoDto dto)
        {
            var pedido = new Pedido();

            decimal total = 0;

            foreach (var itemDto in dto.Itens)
            {
                var produto =
                    await _produtoRepository
                        .GetByIdAsync(itemDto.ProdutoId);

                if (produto == null)
                {
                    throw new Exception($"Produto {itemDto.ProdutoId} não encontrado");
                }
                var subtotal =
                    produto.Preco * itemDto.Quantidade;

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
    }
}
