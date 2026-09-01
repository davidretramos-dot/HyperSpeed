using HyperSpeed.Desktop.DTOs;
using HyperSpeed.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Desktop.Services
{
    public class AuthApiService
    {
        private readonly HttpClientHelper _http;

        public AuthApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        public async Task<(bool Success, UserResponseDto? User, string ErrorMessage)>
     LoginAsync(string email, string password)
        {
            // ✅ Normaliza o email para MAIÚSCULAS (compatível com ASP.NET Identity)
            var normalizedEmail = email?.ToUpperInvariant() ?? string.Empty;

            System.Diagnostics.Debug.WriteLine($"[AUTH SERVICE] Email recebido: '{email}'");
            System.Diagnostics.Debug.WriteLine($"[AUTH SERVICE] Email normalizado: '{normalizedEmail}'");

            var loginDto = new LoginRequestDto
            {
                Email = normalizedEmail,      // ✅ Sincronizado com API
                Senha = password              // ✅ Sincronizado com API (Senha, não Password)
            };

            var (success, data, error) = await _http.PostAsync<UserResponseDto>(
                "/api/auth/login", loginDto);

            return (success, data, error);
        }

        public async Task<(bool Success, string ErrorMessage)> LogoutAsync()
        {
            var result = await _http.PostEmptyAsync("/api/auth/logout");

            return result;
        }

        public async Task<UserResponseDto?> GetCurrentUserAsync()
        {
            return await _http.GetAsync<UserResponseDto>("/api/auth/current");
        }

        public async Task<(bool Success, string ErrorMessage)> RegisterAsync(
            string email, string password, string confirmPassword)
        {
            var registerDto = new RegisterRequestDto
            {
                Email = email,
                Senha = password,
                ConfirmarSenha = confirmPassword
            };
            var (success, _, error) = await _http.PostAsync<object>(
                "/api/auth/register", registerDto);
            return (success, error);
        }
    }
}
