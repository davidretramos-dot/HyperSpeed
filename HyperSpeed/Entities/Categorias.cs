using System.Collections.Generic;

namespace HyperSpeed.Domain.Entities
{
    public class Categorias
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        // Uma categoria possui vários produtos
        public ICollection<Produto> Produtos { get; set; }
            = new List<Produto>();
    }
}