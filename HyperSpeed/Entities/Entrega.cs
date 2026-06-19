using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.Entities
{
    public class Entrega
    {
        public int Id { get; set; }
        public string CodigoRast {  get; set; }
        public string Transpotadora { get; set; }
        public string SttsEntrega {  get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime DataEntrega { get; set; }
        public int IdPedido { get; set; }

        public virtual Pedido IdPedidos { get; set; }


    }
}
