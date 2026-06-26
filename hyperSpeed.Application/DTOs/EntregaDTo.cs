using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.DTOs
{
    public class EntregaDTo
    {
        public int Id { get; set; }
        public int CodigoRast { get; set; }
        public int DataEnvio { get; set; }
        public int DataEntrega { get; set; }
        public string Tranpotadora { get; set; } = string.Empty;
        public int IdPedido { get; set; }

    }
}
