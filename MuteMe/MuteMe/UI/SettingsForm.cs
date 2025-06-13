using System;
using System.Windows.Forms;
using MuteMe.Models;
using MuteMe.Utils;

namespace MuteMe.UI
{
    public partial class SettingsForm : Form
    {
        private AppSettings _settings;

        public SettingsForm(AppSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            numericIdleTimeout.Value = Math.Max(1, _settings.IdleTimeoutSeconds / 60);
            checkMuteSystem.Checked = _settings.MuteSystem;
            checkMuteMic.Checked = _settings.MuteMic;
            checkNotify.Checked = _settings.ShowNotifications;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.IdleTimeoutSeconds = (int)numericIdleTimeout.Value * 60;
            _settings.MuteSystem = checkMuteSystem.Checked;
            _settings.MuteMic = checkMuteMic.Checked;
            _settings.ShowNotifications = checkNotify.Checked;

            SettingsManager.Save(_settings);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
