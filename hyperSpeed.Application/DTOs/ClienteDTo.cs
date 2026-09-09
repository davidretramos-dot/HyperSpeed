using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.DTOs
{
    public class ClienteDTo
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public string Senha { get; set; } = string.Empty;
        public string ConfirmarSenha { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty;
    }

    public class CriarClienteDTo
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string ConfirmarSenha { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty;
    }

    public class AutualizacaoClienteDTo
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Senha { get; set; }
        public string? ConfirmarSenha { get; set; }
        public string? Perfil { get; set; }
    }
}
