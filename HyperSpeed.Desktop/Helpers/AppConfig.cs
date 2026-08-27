using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace HyperSpeed.Desktop.Helpers
{
    public static class AppConfig
    {
        private static JsonDocument? _config;

        public static string ApiBaseUrl => ApiEndPointResolver.Resolve() ?? string.Empty;

        public static string AppName => GetNestedValue("AppSettings", "AppName") ?? "HyperSpeed Desktop";
        public static string Version => GetNestedValue("AppSettings", "Version") ?? "1.0.0";

        public static int Timeout
        {
            get
            {
                var raw = GetNestedValue("AppSettings", "Timeout");
                return int.TryParse(raw, out var t) ? t : 30;
            }
        }

        private static JsonDocument GetConfig()
        {
            if (_config != null) return _config;
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "appsettings.json");

                if (File.Exists(path))
                {
                    var json = File.ReadAllText(path);
                    json = RemoveJsonComments(json);
                    _config = JsonDocument.Parse(json);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[AppConfig] Erro ao ler appsettings.json: {ex.Message}");
            }
            return _config ?? JsonDocument.Parse("{}");
        }

        private static string? GetNestedValue(string section, string key)
        {
            try
            {
                var config = GetConfig();
                if (config.RootElement.TryGetProperty(section, out var sectionEl))
                    if (sectionEl.TryGetProperty(key, out var value))
                        return value.GetString() ?? value.ToString();
            }
            catch { }
            return null;
        }

        private static string RemoveJsonComments(string json)
        {
            var lines = json.Split('\n');
            var sb = new System.Text.StringBuilder();
            foreach (var line in lines)
            {
                var trimmed = line.TrimStart();
                if (trimmed.StartsWith("//")) continue;
                var commentIdx = line.IndexOf("//", StringComparison.Ordinal);
                sb.AppendLine(commentIdx > 0 ? line[..commentIdx] : line);
            }
            return sb.ToString();
        }
    }
}
