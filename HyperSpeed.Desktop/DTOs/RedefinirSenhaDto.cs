using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Desktop.DTOs
{
    public class RedefinirSenhaDto
    {
        public string Email { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public string NovaSenha { get; set; } = string.Empty;

        public string ConfirmarNovaSenha { get; set; } = string.Empty;
    }
}
