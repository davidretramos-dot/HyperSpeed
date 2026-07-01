using hyperSpeed.Application.DTOs;

namespace HyperSpeed.UI.Models
{
    internal class ProdutoListViewModel
    {
        public IEnumerable<CategoriasDTo> Categorias { get; set; }
        public int? SelectedIdCategoria { get; set; }
    }
}