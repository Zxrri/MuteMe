using System.Reflection;

namespace MuteMe.Utils
{
    public static class VersionHelper
    {
        public static string GetVersionString(bool includePrefix = true)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return (includePrefix ? "v" : "") + (version?.ToString() ?? "unknown");
        }
    }
}
