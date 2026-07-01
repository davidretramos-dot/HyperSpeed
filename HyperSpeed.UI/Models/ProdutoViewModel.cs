using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto.")]
        [Display(Name = "Nome")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a descrição.")]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o preço.")]
        [Display(Name = "Preço")]
        [Range(0.01, 999999.99)]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade em estoque.")]
        [Display(Name = "Estoque")]
        [Range(0, int.MaxValue)]
        public int Estoque { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria.")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        // Upload da imagem
        [Display(Name = "Imagem")]
        public IFormFile? Imagem { get; set; }

        // Caminho salvo no banco
        public string? ImagemUrl { get; set; }

        // Lista de categorias para o Select
        public IEnumerable<SelectListItem>? Categorias { get; set; }
    }
}