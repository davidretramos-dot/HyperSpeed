using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.ViewModels
{
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
}