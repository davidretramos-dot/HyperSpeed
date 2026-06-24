using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco {  get; set; } 
        public int Estoque { get; set; }

        public int IdCategoria { get; set; }

        
        public ICollection<Categorias> Categorias { get; set; } = new List<Categorias>();
    }
}
