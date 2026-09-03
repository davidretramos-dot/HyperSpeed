using System;
using HyperSpeed.Domain.Entities;

namespace HyperSpeed.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public decimal Preco { get; set; }

        public int Estoque { get; set; }

        public string Imagem { get; set; } = string.Empty;

        public int IdCategoria { get; set; }

        public Categorias? Categoria { get; set; }

        public DateTime CriacaoAt { get; set; }

        public bool Destaque { get; set; }
    }
}