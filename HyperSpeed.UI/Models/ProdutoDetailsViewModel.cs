using hyperSpeed.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.ViewModels
{
    public class ProdutoDetailsViewModel
    {
        internal ProdutoDTo Produto;
        internal object RelatedProdutos;

        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Preco { get; set; }

        [Display(Name = "Estoque")]
        public int Estoque { get; set; }

        [Display(Name = "Categoria")]
        public string Categoria { get; set; } = string.Empty;

        [Display(Name = "Imagem")]
        public string? ImagemUrl { get; set; }

        public bool Disponivel => Estoque > 0;
    }
}