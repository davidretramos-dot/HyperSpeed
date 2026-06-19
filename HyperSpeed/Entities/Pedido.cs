using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }= DateTime.Now;
        public string Status {  get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }

    }
}
