using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Updater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: Updater.exe <oldExe> <newExe>");
                return;
            }

            string oldExe = args[0];
            string newExe = args[1];

            try
            {
                Console.WriteLine("Waiting for app to exit...");
                Thread.Sleep(3000); 

                Console.WriteLine("Replacing old exe...");
                if (File.Exists(oldExe))
                    File.Delete(oldExe);

                File.Move(newExe, oldExe);

                Console.WriteLine("Launching updated app...");
                var startInfo = new ProcessStartInfo
                {
                    FileName = oldExe,
                    UseShellExecute = true,
                    WorkingDirectory = Path.GetDirectoryName(oldExe) ?? ""
                };
                Process.Start(startInfo);

                // Cleanup
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string zipPath = Path.Combine(baseDir, "update.zip");
                string extractPath = Path.Combine(baseDir, "update_extract");

                if (File.Exists(zipPath))
                    File.Delete(zipPath);

                if (Directory.Exists(extractPath))
                    Directory.Delete(extractPath, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update failed: " + ex.Message);
            }
        }
    }
}
