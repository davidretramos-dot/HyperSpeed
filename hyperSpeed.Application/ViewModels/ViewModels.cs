using hyperSpeed.Application.DTOs;
using HyperSpeed.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace hyperSpeed.Application.ViewModels
{
    public class HomeViewModels
    {
        public IEnumerable<ProdutoDTo> ProdutosDestaque {  get; set; } = new List<ProdutoDTo>();
        public IEnumerable<CategoriasDTo> Categorias {  get; set; } = new List<CategoriasDTo>();
        public IEnumerable<ProdutoDTo> Produtos { get; set; } = new List<ProdutoDTo>();
    }

    // -------------------------------------------------------------------

    public class ProdutoDetailsViewModel
    {
        public ProdutoDTo Produto;
        public object RelatedProdutos;

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

    // -------------------------------------------------------------------

    public class DashboardViewModel
    {
        public int TotalProdutos { get; set; }
        public int TotalCategorias { get; set; }
        public IEnumerable<ProdutoDTo> RecentProdutos { get; set; } = new List<ProdutoDTo>();
    }

    // -------------------------------------------------------------------

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

    // -------------------------------------------------------------------

    public class ProdutoListViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; } = new List<Produto>();

        public string? Pesquisa { get; set; }

        public int? CategoriaId { get; set; }

        public string? CategoriaNome { get; set; }
    }

    // -------------------------------------------------------------------
    // ViewModel base acima
    // -------------------------------------------------------------------
    // Adicional abaixo
    // -------------------------------------------------------------------
    public class PerfilViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }

    // -------------------------------------------------------------------

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    // -------------------------------------------------------------------

    public class RegistroViewModel
    {
        [Required(ErrorMessage = "Informe o nome completo.")]
        [Display(Name = "Nome Completo")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CPF.")]
        [Display(Name = "CPF")]
        [StringLength(14)]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o telefone.")]
        [Display(Name = "Telefone")]
        [Phone(ErrorMessage = "Informe um telefone válido.")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [StringLength(100, MinimumLength = 6,
            ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirme a senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmarSenha { get; set; } = string.Empty;
    }

    // -------------------------------------------------------------------

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    // -------------------------------------------------------------------

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
        public int Preco { get; set; }

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

    // -------------------------------------------------------------------

    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria.")]
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "A descrição pode ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        [Display(Name = "Categoria Pai")]
        public int? CategoriaPaiId { get; set; }

        // Lista para preencher o DropDown das categorias
        public IEnumerable<SelectListItem>? CategoriasPai { get; set; }
    }
}
