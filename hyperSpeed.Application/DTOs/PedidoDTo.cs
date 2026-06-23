using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.DTOs
{
    public class PedidoDTo
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public int Valor { get; set; }
    }


}
