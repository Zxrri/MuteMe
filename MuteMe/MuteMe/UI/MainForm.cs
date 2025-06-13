using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MuteMe.Services;

namespace MuteMe
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon;
        private System.Windows.Forms.Timer idleCheckTimer;
        private bool isMuted = false;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;

            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                Text = "MuteMe - Running",
                ContextMenuStrip = new ContextMenuStrip()
            };

            trayIcon.ContextMenuStrip.Items.Add("Exit", null, (s, ev) => Application.Exit());

            idleCheckTimer = new System.Windows.Forms.Timer { Interval = 5000 };
            idleCheckTimer.Tick += CheckIdle;
            idleCheckTimer.Start();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Hide(); 
        }

        private void CheckIdle(object sender, EventArgs e)
        {
            int idleMs = IdleWatcher.GetIdleTimeMs();

            if (idleMs > 2 * 60 * 1000 && !isMuted)
            {
                AudioController.MuteSystemAudio(true);
                AudioController.MuteMic(true);
                isMuted = true;
                trayIcon.Text = "Muted due to inactivity";
                trayIcon.ShowBalloonTip(1000, "MuteMe", "System muted due to inactivity.", ToolTipIcon.Info);
            }
            else if (idleMs <= 2 * 60 * 1000 && isMuted)
            {
                AudioController.MuteSystemAudio(false);
                AudioController.MuteMic(false);
                isMuted = false;
                trayIcon.Text = "MuteMe - Running";
                trayIcon.ShowBalloonTip(1000, "MuteMe", "System unmuted – activity detected.", ToolTipIcon.Info);
            }
        }
    }
}
