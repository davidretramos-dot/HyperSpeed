using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.DTOs
{

    public class ItemPedidoDTo
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUni { get; set; }
        public decimal SubTotal { get; set; }
    }

    public class CreateItemPedidoDto
        {
            public int ProdutoId { get; set; }

            public int Quantidade { get; set; }
        }
    
}
