using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HyperSpeed.Desktop.DTOs
{
    public class LoginRequestDto
    {
        // ✅ Sincronizado com API: LoginDto usa Email e Senha
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("senha")]
        public string Senha { get; set; } = string.Empty;
    }

    public class RegisterRequestDto 
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("senha")]
        public string Senha { get; set; } = string.Empty;

        [JsonPropertyName("confirmarSenha")]
        public string ConfirmarSenha { get; set; } = string.Empty;
    }

    public class UserResponseDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("regras")]
        public List<string> Regras { get; set; } = new();

        public bool IsAdmin => Regras.Contains("Admin");
    }
}