using HyperSpeed.Domain.Entities;
using System;
using System.Collections.Generic;

namespace hyperSpeed.Application.DTOs
{
    public class PedidoDTo
    {
        public int Id { get; set; }

        public StatusPedido Status { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataPedido { get; set; }
    }

    public class CreatePedidoDto
    {
        public List<CreateItemPedidoDto> Itens { get; set; } = new();

        public TipoPagamento TipoPagamento { get; set; }
    }
}