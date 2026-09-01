using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace HyperSpeed.Desktop.Helpers
{
    public static class ApiEndPointResolver
    {
        private static string? _resolvedUrl;
        private static bool _resolved = false;
        private const string ApiProjectName = "HyperSpeed.API";

        private const string LaunchSettingsRelativePath = $"{ApiProjectName}/Properties/launchSettings.json";

        private static readonly string[] PreferredProfiles = new[] { "http", "https", "IIS Express" };

        public static string? Resolve()
        {
            if (_resolved) return _resolvedUrl;
            _resolved = true;

            var fromLaunchSettings = TryResolveFromLaunchSettings();
            if (fromLaunchSettings != null)
            {
                _resolvedUrl = fromLaunchSettings;
                Log($"Api localizada em: {_resolvedUrl}");
                Log($"Origem: launchSettings.json do {ApiProjectName}");
                return _resolvedUrl;
            }

            var fromAppSettings = TryResolveFromAppSettings();
            if (fromAppSettings != null)
            {
                _resolvedUrl = fromAppSettings;
                Log($"Api localizada em: {_resolvedUrl}");
                Log($"   Origem: appsettings.json (configuração manual)");
                return _resolvedUrl;
            }

            // ── PRIORIDADE 3: não encontrado ──────────────────────────────────
            Log("❌ URL da API não foi localizada.");
            Log("   Verifique se SenacGames.API/Properties/launchSettings.json existe");
            Log("   ou configure manualmente em appsettings.json → ApiSettings.BaseUrl");
            _resolvedUrl = null;
            return null;
        }
        public static void Reset()
        {
            _resolved = false;
            _resolvedUrl = null;
        }

        private static string? TryResolveFromLaunchSettings()
        {
            var candidates = BuildLaunchSettingsCandidatePaths();

            foreach (var candidate in candidates)
            {
                Log($"   🔍 Testando: {candidate}");

                if (!File.Exists(candidate)) continue;

                Log($"   📄 launchSettings.json encontrado em: {candidate}");

                var url = ParseLaunchSettings(candidate);
                if (url != null) return url;
            }

            return null;
        }
        private static List<string> BuildLaunchSettingsCandidatePaths()
        {
            var paths = new List<string>();
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var relativeLevels = new[] { 4, 5, 3, 6 };

            foreach (var levels in relativeLevels)
            {
                var dir = GoUpDirectories(baseDir, levels);
                if (dir != null)
                {
                    paths.Add(Path.Combine(dir, LaunchSettingsRelativePath));
                }
            }
            var solutionDir = Environment.GetEnvironmentVariable("SolutionDir");
            if (!string.IsNullOrEmpty(solutionDir))
            {
                paths.Add(Path.Combine(solutionDir, LaunchSettingsRelativePath));
            }

            // Caminho relativo ao diretório de trabalho atual
            paths.Add(Path.Combine(
                Directory.GetCurrentDirectory(),
                LaunchSettingsRelativePath));

            return paths;
        }

        private static string? ParseLaunchSettings(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

           
                if (!root.TryGetProperty("profiles", out var profiles))
                {
                    Log("   ⚠ launchSettings.json não contém seção 'profiles'");
                    return null;
                }
                foreach (var profileName in PreferredProfiles)
                {
                    if (!profiles.TryGetProperty(profileName, out var profile))
                        continue;

                    if (!profile.TryGetProperty("applicationUrl", out var urlProp))
                        continue;

                    var applicationUrl = urlProp.GetString();
                    if (string.IsNullOrWhiteSpace(applicationUrl))
                        continue;

                  
                    var url = ExtractBestUrl(applicationUrl, profileName);
                    if (url != null)
                    {
                        Log($"   ✓ Perfil '{profileName}' → applicationUrl: {applicationUrl}");
                        Log($"   ✓ URL selecionada: {url}");
                        return url;
                    }
                }

                Log("   ⚠ Nenhum perfil com applicationUrl válida encontrado");
                return null;
            }
            catch (JsonException ex)
            {
                Log($"   ⚠ Erro ao parsear launchSettings.json: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Log($"   ⚠ Erro ao ler launchSettings.json: {ex.Message}");
                return null;
            }
        }

        private static string? ExtractBestUrl(string applicationUrl, string profileName)
        {
            var urls = applicationUrl
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(u => u.Trim())
                .Where(u => !string.IsNullOrEmpty(u))
                .ToList();

            if (urls.Count == 0) return null;

            if (profileName == "http")
            {
                var httpUrl = urls.FirstOrDefault(u =>
                    u.StartsWith("http://", StringComparison.OrdinalIgnoreCase));
                return httpUrl ?? urls[0];
            }

            var httpsUrl = urls.FirstOrDefault(u =>
                u.StartsWith("https://", StringComparison.OrdinalIgnoreCase));
            return httpsUrl ?? urls[0];
        }

        private static string? TryResolveFromAppSettings()
        {
            try
            {
                var path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "appsettings.json");

                if (!File.Exists(path))
                {
                    Log("   ⚠ appsettings.json não encontrado");
                    return null;
                }

                var json = File.ReadAllText(path);
                // Remove comentários de linha (// ...) que não são JSON padrão
                json = RemoveJsonComments(json);

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                // Formato novo: ApiSettings.BaseUrl
                if (root.TryGetProperty("ApiSettings", out var apiSettings))
                {
                    if (apiSettings.TryGetProperty("BaseUrl", out var baseUrl))
                    {
                        var url = baseUrl.GetString();
                        if (!string.IsNullOrWhiteSpace(url))
                        {
                            Log($"   ✓ appsettings.json → ApiSettings.BaseUrl: {url}");
                            return url;
                        }
                    }
                }

                // Formato legado: ApiBaseUrl (compatibilidade retroativa)
                if (root.TryGetProperty("ApiBaseUrl", out var legacyUrl))
                {
                    var url = legacyUrl.GetString();
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        Log($"   ✓ appsettings.json → ApiBaseUrl (legado): {url}");
                        return url;
                    }
                }

                Log("   ⚠ appsettings.json não contém ApiSettings.BaseUrl nem ApiBaseUrl");
                return null;
            }
            catch (Exception ex)
            {
                Log($"   ⚠ Erro ao ler appsettings.json: {ex.Message}");
                return null;
            }
        }

        private static string? GoUpDirectories(string path, int levels)
        {
            var dir = new DirectoryInfo(path);
            for (int i = 0; i < levels; i++)
            {
                dir = dir.Parent;
                if (dir == null) return null;
            }
            return dir.FullName;
        }

        private static string RemoveJsonComments(string json)
        {
            var lines = json.Split('\n');
            var result = new System.Text.StringBuilder();
            foreach (var line in lines)
            {
                var trimmed = line.TrimStart();
                // Pula linhas que são apenas comentários
                if (trimmed.StartsWith("//")) continue;
                // Remove comentário inline após código válido
                var commentIndex = line.IndexOf("//", StringComparison.Ordinal);
                if (commentIndex > 0)
                {
                    result.AppendLine(line[..commentIndex]);
                }
                else
                {
                    result.AppendLine(line);
                }
            }
            return result.ToString();
        }
        private static void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine($"[ApiEndpointResolver] {message}");
            // Também no console (útil quando rodado fora do VS)
            Console.WriteLine($"[ApiEndpointResolver] {message}");
        }

    }    
}

