using hyperSpeed.Application.DTOs;

namespace HyperSpeed.UI.Models
{
    public class ProdutoFormViewModel
    {
        public int? Id { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Preco { get; set; }
        public int Estoque { get; set; }
        public string ImagemUrl { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public bool Destaque { get; set; }
        public IEnumerable<CategoriasDTo> Categorias { get; set; } = Enumerable.Empty<CategoriasDTo>();
    }
}
