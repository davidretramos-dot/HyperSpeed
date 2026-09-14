// =============================================================================
// SenacGames.UI - Helpers/ApiCookieHandler.cs
// =============================================================================

using System.Net.Http.Headers;

namespace HyperSpeed.UI.Helpers
{
    /// <summary>
    /// Intercepta as requisições HTTP saindo da UI para a API e adiciona o
    /// cookie de autenticação da API, caso o usuário esteja logado.
    /// Isso garante que a API reconheça o usuário autenticado.
    /// </summary>
    public class ApiCookieHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiCookieHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null && httpContext.User?.Identity != null && httpContext.User.Identity.IsAuthenticated)
            {
                // Tentativa 1: Repasse via cookie do Request atual (mais simples quando a autenticação
                // da API compartilha o mesmo domínio). Ex.: cookie '.AspNetCore.Identity.Application'
                try
                {
                    // Concatena todos os cookies presentes no Request em um header "Cookie" válido
                    var cookieHeader = string.Join("; ", httpContext.Request.Cookies.Select(kvp => $"{kvp.Key}={kvp.Value}"));
                    if (!string.IsNullOrEmpty(cookieHeader))
                    {
                        request.Headers.Remove("Cookie");
                        request.Headers.Add("Cookie", cookieHeader);
                    }
                }
                catch
                {
                    // Se falhar, tentamos fallback para claim "ApiCookie" (compatibilidade)
                    var cookieClaim = httpContext.User.FindFirst("ApiCookie");
                    if (cookieClaim != null && !string.IsNullOrEmpty(cookieClaim.Value))
                    {
                        request.Headers.Remove("Cookie");
                        request.Headers.Add("Cookie", cookieClaim.Value);
                    }
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
