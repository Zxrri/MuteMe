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
                Thread.Sleep(3000); // Wait to ensure app is fully closed

                Console.WriteLine("Replacing old exe...");
                if (File.Exists(oldExe))
                    File.Delete(oldExe);

                File.Move(newExe, oldExe);

                Console.WriteLine("Launching updated app...");
                Process.Start(oldExe);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update failed: " + ex.Message);
            }
        }
    }
}
