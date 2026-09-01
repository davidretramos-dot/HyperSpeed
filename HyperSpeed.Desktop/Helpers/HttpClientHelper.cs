using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;


namespace HyperSpeed.Desktop.Helpers
{
    public sealed class HttpClientHelper
    {
        private static readonly Lazy<HttpClientHelper> _instance = new(()=> new HttpClientHelper());
        public static HttpClientHelper Instance => _instance.Value;
        private readonly CookieContainer _cookieContainer;
        private readonly HttpClientHandler _handler;
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private HttpClientHelper()
        {
            _cookieContainer = new CookieContainer();
            _handler = new HttpClientHandler
            {
                CookieContainer = _cookieContainer,
                UseCookies = true,
                AllowAutoRedirect = false,
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var baseUrl = AppConfig.ApiBaseUrl;
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                _client = new HttpClient(_handler)
                {
                    Timeout = TimeSpan.FromSeconds(AppConfig.Timeout)
                };
            }
            else
            {
                if (!baseUrl.EndsWith('/'))baseUrl += "/";
                _client = new HttpClient(_handler)
                {
                    BaseAddress = new Uri(baseUrl),
                    Timeout = TimeSpan.FromSeconds(AppConfig.Timeout)
                };
            }
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<(bool IsAvailable, string ErrorMessage)> PingApiAsync()
        {
            if (_client.BaseAddress == null)
            {
                return (false, "URL da API não configurada. Verifique o lauchSettings.json" +
                    "do projeto HyperSpeed.API ou o appsettings.json do Desktop.");
            }
            try
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                var response = await _client.GetAsync("/api/games", cts.Token);
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, CategorizeConnectionError(ex, _client.BaseAddress?.ToString() ?? ""));
            }
        }

        public async Task<T?>GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await _client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
                }
                return default;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[GET] Erro em {endpoint}: {ex.Message}");
                throw;
            }
        }

        public async Task<(bool Success, T? Data, string ErrorMessage)> PostAsync<T>(
            string endpoint, object body)
        {
            try
            {
                var json = JsonSerializer.Serialize(body);
                System.Diagnostics.Debug.WriteLine($"[POST {endpoint}] JSON Enviado: {json}");  // 👈 NOVO LOG

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(endpoint, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var data = JsonSerializer.Deserialize<T>(responseBody, _jsonOptions);
                    return (true, data, string.Empty);
                }

                var error = TryExtractErrorMessage(responseBody);
                return (false, default, error);
            }
            catch (Exception ex)
            {
                var friendly = CategorizeConnectionError(ex, endpoint);
                return (false, default, friendly);
            }
        }

        public async Task<(bool Success, T? Data, string ErrorMessage)> PutAsync<T>(
            string endpoint, object body)
        {
            try
            {
                var json = JsonSerializer.Serialize(body);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PutAsync(endpoint, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var data = JsonSerializer.Deserialize<T>(responseBody, _jsonOptions);
                    return (true, data, string.Empty);
                }

                var error = TryExtractErrorMessage(responseBody);
                return (false, default, error);
            }
            catch (Exception ex)
            {
                var friendly = CategorizeConnectionError(ex, endpoint);
                return (false, default, friendly);
            }
        }

        public async Task<(bool Success, string ErrorMessage)> DeleteAsync(string endpoint)
        {
            try
            {
                var response = await _client.DeleteAsync(endpoint);

                if (response.IsSuccessStatusCode)
                    return (true, string.Empty);

                var body = await response.Content.ReadAsStringAsync();
                return (false, TryExtractErrorMessage(body));
            }
            catch (Exception ex)
            {
                return (false, CategorizeConnectionError(ex, endpoint));
            }
        }

        public async Task<(bool Success, string ErrorMessage)> PostEmptyAsync(string endpoint)
        {
            try
            {
                var response = await _client.PostAsync(endpoint, null);

                if (response.IsSuccessStatusCode)
                    return (true, string.Empty);

                var body = await response.Content.ReadAsStringAsync();
                return (false, TryExtractErrorMessage(body));
            }
            catch (Exception ex)
            {
                return (false, CategorizeConnectionError(ex, endpoint));
            }
        }
        public void ClearCookies()
        {
            var baseUri = _client.BaseAddress;
            if (baseUri != null)
            {
                var cookies = _cookieContainer.GetCookies(baseUri);
                foreach (Cookie cookie in cookies)
                    cookie.Expired = true;
            }
        }
        private string TryExtractErrorMessage(string json)
        {
            try
            {
                var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("message", out var msg))
                    return msg.GetString() ?? "Erro desconhecido.";
                if (doc.RootElement.TryGetProperty("title", out var title))
                    return title.GetString() ?? "Erro desconhecido.";
            }
            catch { }

            return string.IsNullOrEmpty(json) ? "Erro desconhecido." : json;
        }

        private string CategorizeConnectionError(Exception ex, string endpoint)
        {
            System.Diagnostics.Debug.WriteLine(
                $"[HttpClientHelper] Erro em '{endpoint}': {ex.GetType().Name} — {ex.Message}");

            // ── Timeout ──────────────────────────────────────────────────────
            if (ex is TaskCanceledException or OperationCanceledException)
            {
                return "⏱ A requisição excedeu o tempo limite.\n" +
                       "Verifique se a API está respondendo normalmente.";
            }

            if (ex is HttpRequestException httpEx)
            {
                var msg = httpEx.Message.ToLowerInvariant();

                // ── Conexão recusada (API desligada) ─────────────────────────
                if (msg.Contains("connection refused") ||
                    msg.Contains("actively refused") ||
                    msg.Contains("no connection could be made"))
                {
                    var apiUrl = _client.BaseAddress?.ToString() ?? "URL não configurada";
                    return $"❌ A API não está em execução.\n\n" +
                           $"URL configurada: {apiUrl}\n\n" +
                           $"Verifique se o projeto HyperSpeed.API está rodando no Visual Studio.";
                }

                // ── SSL / Certificado ─────────────────────────────────────────
                if (msg.Contains("ssl") || msg.Contains("certificate") ||
                    msg.Contains("https"))
                {
                    return "🔒 Erro de conexão SSL.\n\n" +
                           "Tente usar HTTP em vez de HTTPS.\n" +
                           "No launchSettings.json, selecione o perfil 'http'.";
                }

                // ── DNS / Host não encontrado ─────────────────────────────────
                if (msg.Contains("name or service not known") ||
                    msg.Contains("no such host") ||
                    msg.Contains("getaddrinfo"))
                {
                    return $"🌐 Host não encontrado.\n\n" +
                           $"Verifique a URL da API: {_client.BaseAddress}";
                }

                // ── Erro HTTP genérico ────────────────────────────────────────
                return $"⚠ Erro de comunicação com a API:\n{httpEx.Message}";
            }

            // ── URL inválida ──────────────────────────────────────────────────
            if (ex is UriFormatException or InvalidOperationException)
            {
                return "⚠ URL da API inválida.\n\n" +
                       "Verifique o appsettings.json → ApiSettings.BaseUrl\n" +
                       "ou o launchSettings.json do projeto HyperSpeed.API.";
            }

            // ── Erro genérico ─────────────────────────────────────────────────
            return $"⚠ Erro inesperado:\n{ex.Message}";
        }
    }
}
