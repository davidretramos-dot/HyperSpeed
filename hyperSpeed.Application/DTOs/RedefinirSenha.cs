using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.DTOs
{
    public class RedefinirSenhaDTo
    {
        public string Email { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public string NovaSenha { get; set; } = string.Empty;

        public string ConfirmarNovaSenha { get; set; } = string.Empty;
    }
}
