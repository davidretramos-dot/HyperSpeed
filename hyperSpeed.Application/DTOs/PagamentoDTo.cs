using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.DTOs
{
    internal class PagamentoDTo
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public string StatusPagamento { get; set; } = string.Empty;
        public int IdProduto { get; set; }
    }
}
