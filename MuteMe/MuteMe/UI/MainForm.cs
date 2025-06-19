using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MuteMe.Models;
using MuteMe.Utils;
using MuteMe.UI;
using MuteMe.Services;
using System.Diagnostics;

namespace MuteMe
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon;
        private System.Windows.Forms.Timer idleCheckTimer;
        private AppSettings settings;
        private bool isMuted = false;

        private static readonly string[] mediaKeywords = new[]
        {
            "YouTube", "Netflix", "Twitch", "Spotify", "Vimeo", "Prime Video", "Disney+"
        };

        private static readonly string[] supportedBrowsers = new[]
        {
            "chrome", "msedge", "firefox", "opera", "brave"
        };

        private static readonly string[] mediaApps = new[]
        {
            "Spotify", "vlc", "wmplayer", "Music.UI", "Netflix", "AmazonVideo.PrimeVideo", 
        };
        public MainForm()
        {
            InitializeComponent();

            settings = SettingsManager.Load();

            ////FOR TESTING ONLY(10s timeout)
            //settings.IdleTimeoutSeconds = 10;

            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await Task.Delay(300); 

            trayIcon = new NotifyIcon
            {
                Icon = new Icon("Resources/mute_icon.ico"),
                Visible = true,
                Text = "MuteMe - Running",
                ContextMenuStrip = new ContextMenuStrip()
            };
            var versionItem = new ToolStripMenuItem($"Version {VersionHelper.GetVersionString()}");
            versionItem.Enabled = false;
            trayIcon.ContextMenuStrip.Items.Add(versionItem);

            trayIcon.ContextMenuStrip.Items.Add("Settings", null, OnSettingsClick);
            trayIcon.ContextMenuStrip.Items.Add("Exit", null, (s, ev) => this.Close());

            idleCheckTimer = new System.Windows.Forms.Timer { Interval = 2000 };
            idleCheckTimer.Tick += CheckIdle;
            idleCheckTimer.Start();
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Hide(); 
        }

        private bool IsMediaPlaying()
        {
            try
            {
                foreach (string browser in supportedBrowsers)
                {
                    var procs = Process.GetProcessesByName(browser);
                    foreach (var p in procs)
                    {
                        string title = p.MainWindowTitle;
                        if (!string.IsNullOrWhiteSpace(title))
                        {
                            foreach (var keyword in mediaKeywords)
                            {
                                if (title.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                                    return true;
                            }
                        }
                    }
                }

                foreach (string app in mediaApps)
                {
                    var procs = Process.GetProcessesByName(app);
                    foreach (var p in procs)
                    {
                        if (!string.IsNullOrWhiteSpace(p.MainWindowTitle))
                            return true; // Running and has a UI
                    }
                }
            }
            catch
            {
                // Ignore exceptions silently
            }

            return false;
        }


        private void CheckIdle(object sender, EventArgs e)
        {
            int idleMs = IdleWatcher.GetIdleTimeMs();

            bool isMediaPlaying = IsMediaPlaying();

            if (idleMs >= settings.IdleTimeoutSeconds * 1000 && !isMuted && !isMediaPlaying)
            {
                if (settings.MuteSystem) AudioController.MuteSystemAudio(true);
                if (settings.MuteMic) AudioController.MuteMic(true);
                isMuted = true;

                if (settings.ShowNotifications)
                    trayIcon.ShowBalloonTip(1000, "MuteMe", "System muted due to inactivity.", ToolTipIcon.Info);
            }
            else if ((idleMs < settings.IdleTimeoutSeconds * 1000 || isMediaPlaying) && isMuted)
            {
                if (settings.MuteSystem) AudioController.MuteSystemAudio(false);
                if (settings.MuteMic) AudioController.MuteMic(false);
                isMuted = false;

                if (settings.ShowNotifications)
                    trayIcon.ShowBalloonTip(1000, "MuteMe", "System unmuted � activity detected.", ToolTipIcon.Info);
            }
        }


        private void OnSettingsClick(object? sender, EventArgs e)
        {
            using var settingsForm = new SettingsForm(settings);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                settings = SettingsManager.Load(); // Reload settings
                idleCheckTimer.Stop();
                idleCheckTimer.Start();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (trayIcon != null)
            {
                trayIcon.Visible = false;
                trayIcon.Dispose();
                trayIcon = null;
            }

            base.OnFormClosing(e);
        }

    }
}
