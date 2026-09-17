using HyperSpeed.Desktop.DTOs;
using HyperSpeed.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text;
using System.Text.Json;

namespace HyperSpeed.Desktop.Services
{
    public class RecuperacaoSenhaApiService
    {
        private readonly HttpClient _httpClient;

        public RecuperacaoSenhaApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppConfig.ApiBaseUrl)
            };
        }

        public async Task<string> SolicitarTokenAsync(string email)
        {
            var dto = new EsqueciSenhaDto
            {
                Email = email
            };

            var json = JsonSerializer.Serialize(dto);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "api/auth/esqueci-senha",
                content
            );

            var resposta = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(resposta);
            }

            using var documento = JsonDocument.Parse(resposta);

            return documento.RootElement
                .GetProperty("token")
                .GetString() ?? string.Empty;
        }

        public async Task RedefinirSenhaAsync(
            string email,
            string token,
            string novaSenha,
            string confirmarNovaSenha)
        {
            var dto = new RedefinirSenhaDto
            {
                Email = email,
                Token = token,
                NovaSenha = novaSenha,
                ConfirmarNovaSenha = confirmarNovaSenha
            };

            var json = JsonSerializer.Serialize(dto);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "api/auth/redefinir-senha",
                content
            );

            var resposta = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(resposta);
            }
        }
    }
}
