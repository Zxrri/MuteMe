using System;
using System.Reflection;

namespace MuteMe.Utils
{
    public static class VersionHelper
    {
        public static string GetVersionString(bool includePrefix = true)
        {
            var version = GetVersion();
            return (includePrefix ? "v" : "") + version.ToString();
        }

        public static Version GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version ?? new Version(0, 0, 0);
        }
    }
}
