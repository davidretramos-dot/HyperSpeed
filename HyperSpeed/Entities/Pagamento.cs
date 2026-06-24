using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.Entities
{
    public enum TipoPagamento
    {
        Pix = 1,
        CartaoCredito = 2,
        CartaoDebito = 3,
        Boleto = 4
    }
    public class Pagamento
    {
        public int Id { get; set; }
        public TipoPagamento TipoPagamento {  get; set; }
        public decimal Valor { get; set; }
        public string SttsPagamento { get; set; } = string.Empty;

        public int IdPedido { get; set; }

        public ICollection<Pedido> Idpedido{ get; set; } = new List<Pedido>();
    }
}
