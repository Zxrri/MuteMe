using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Updater
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MessageBox.Show("Updater launched.");

            File.AppendAllText("debug.log", $"Updater started at {DateTime.Now}\n");

            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length != 2)
            {
                MessageBox.Show("Usage: Updater.exe <oldExePath> <newExePath>", "Updater", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldExe = args[0];
            string newExe = args[1];

            try
            {
                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update.log");
                File.AppendAllText(logPath, $"[{DateTime.Now}] Update started.\n");

                Thread.Sleep(3000); // Ensure app is closed

                if (File.Exists(oldExe))
                {
                    File.Delete(oldExe);
                    File.AppendAllText(logPath, "Old EXE deleted.\n");
                }

                File.Move(newExe, oldExe);
                File.AppendAllText(logPath, "New EXE moved.\n");

                Process.Start(oldExe);
                File.AppendAllText(logPath, "New EXE launched.\n");

                // Optional: delete extracted update folder if needed
                string updateFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update_extract");
                if (Directory.Exists(updateFolder))
                {
                    Directory.Delete(updateFolder, true);
                    File.AppendAllText(logPath, "Update extract folder deleted.\n");
                }

                File.AppendAllText(logPath, "Update finished.\n");
            }
            catch (Exception ex)
            {
                string errorMsg = $"Update failed: {ex.Message}";
                File.AppendAllText("update.log", $"[{DateTime.Now}] {errorMsg}\n{ex}\n");
                MessageBox.Show(errorMsg, "Updater Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
