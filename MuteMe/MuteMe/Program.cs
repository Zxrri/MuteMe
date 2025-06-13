namespace MuteMe
{
    using System.Threading;

    static class Program
    {
        [STAThread]
        static void Main()
        {
            bool createdNew;
            using var mutex = new Mutex(true, "MuteMeAppMutex", out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("MuteMe is already running.", "MuteMe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }

}