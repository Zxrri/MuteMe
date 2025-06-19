using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MuteMe.Utils
{
    internal class UpdateChecker
    {
        public static async Task<(bool updateAvailable, string exeUrl, string version)> CheckForUpdateAsync()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("MuteMeUpdater");

            var json = await client.GetStringAsync("https://api.github.com/repos/Zxrri/MuteMe/releases/latest");
            using var doc = JsonDocument.Parse(json);

            string tag = doc.RootElement.GetProperty("tag_name").GetString() ?? "0.0.0";
            string exeUrl = doc.RootElement
                .GetProperty("assets")[0]
                .GetProperty("browser_download_url").GetString() ?? "";

            Version latest = Version.Parse(ExtractVersion(tag));
            Version current = VersionHelper.GetVersion();

            if (latest <= current)
                return (false, exeUrl, tag);

            return (true, exeUrl, tag);
        }
        private static string ExtractVersion(string input)
        {
            return new string(input
                .SkipWhile(c => !char.IsDigit(c))
                .TakeWhile(c => char.IsDigit(c) || c == '.')
                .ToArray());
        }
    }
}
