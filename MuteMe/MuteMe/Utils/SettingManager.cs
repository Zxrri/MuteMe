using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
   using System.Text.Json;
    using MuteMe.Models;

namespace MuteMe.Utils
{

    public static class SettingsManager
    {
        private static string filePath = "settings.json";

        public static void Save(AppSettings settings)
        {
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static AppSettings Load()
        {
            if (!File.Exists(filePath)) return new AppSettings();
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
        }
    }
}
