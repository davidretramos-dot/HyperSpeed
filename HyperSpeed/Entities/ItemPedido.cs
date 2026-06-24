using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.Entities
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public string Quantidade { get; set; } = string.Empty;
        public decimal PrecoUni {  get; set; }
        public decimal subTotal { get; set; }

        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

        public virtual Pedido Pedidos { get; set; }
        public ICollection <Produto> produto { get; set; }
    }
}
