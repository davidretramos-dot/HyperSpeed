using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.DTOs
{
    public class ProdutoDTo
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Preco { get; set; }
        public int Estoque { get; set; }
        public string ImagemUrl { get; set; } = string.Empty;
        public int IdCategoria { get; set; }

        public string NomeCategoria { get; set; } = string.Empty;
        public bool Destaque { get; set; }
        public DateTime CriacaoAt {  get; set; }
    }

    public class CriacaoProdutoDTo
    {
        public string NomeProduto { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Preco { get; set; }
        public int Estoque { get; set; }
        public string ImagemUrl { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public bool Destaque { get; set; }
    }

    public class AutualizacaoProdutoDTo
    {
        public string NomeProduto { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Preco { get; set; }
        public int Estoque { get; set; }
        public string ImagemUrl { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public bool Destaque { get; set; }
    }
}
