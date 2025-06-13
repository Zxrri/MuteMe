namespace MuteMe.UI
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        private NumericUpDown numericIdleTimeout;
        private CheckBox checkMuteSystem;
        private CheckBox checkMuteMic;
        private CheckBox checkNotify;
        private Button btnSave;
        private Button btnCancel;
        private Label lblIdleTimeout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.numericIdleTimeout = new NumericUpDown();
            this.checkMuteSystem = new CheckBox();
            this.checkMuteMic = new CheckBox();
            this.checkNotify = new CheckBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lblIdleTimeout = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericIdleTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIdleTimeout
            // 
            this.lblIdleTimeout.AutoSize = true;
            this.lblIdleTimeout.Location = new System.Drawing.Point(12, 15);
            this.lblIdleTimeout.Name = "lblIdleTimeout";
            this.lblIdleTimeout.Size = new System.Drawing.Size(180, 15);
            this.lblIdleTimeout.TabIndex = 0;
            this.lblIdleTimeout.Text = "Idle timeout (minutes before mute):";
            // 
            // numericIdleTimeout
            // 
            this.numericIdleTimeout.Location = new System.Drawing.Point(220, 12);
            this.numericIdleTimeout.Maximum = new decimal(new int[] {
            60, 0, 0, 0});
            this.numericIdleTimeout.Minimum = new decimal(new int[] {
            1, 0, 0, 0});
            this.numericIdleTimeout.Name = "numericIdleTimeout";
            this.numericIdleTimeout.Size = new System.Drawing.Size(60, 23);
            this.numericIdleTimeout.TabIndex = 1;
            this.numericIdleTimeout.Value = new decimal(new int[] {
            2, 0, 0, 0});
            // 
            // checkMuteSystem
            // 
            this.checkMuteSystem.AutoSize = true;
            this.checkMuteSystem.Location = new System.Drawing.Point(15, 50);
            this.checkMuteSystem.Name = "checkMuteSystem";
            this.checkMuteSystem.Size = new System.Drawing.Size(119, 19);
            this.checkMuteSystem.TabIndex = 2;
            this.checkMuteSystem.Text = "Mute System Audio";
            this.checkMuteSystem.UseVisualStyleBackColor = true;
            // 
            // checkMuteMic
            // 
            this.checkMuteMic.AutoSize = true;
            this.checkMuteMic.Location = new System.Drawing.Point(15, 75);
            this.checkMuteMic.Name = "checkMuteMic";
            this.checkMuteMic.Size = new System.Drawing.Size(74, 19);
            this.checkMuteMic.TabIndex = 3;
            this.checkMuteMic.Text = "Mute Mic";
            this.checkMuteMic.UseVisualStyleBackColor = true;
            // 
            // checkNotify
            // 
            this.checkNotify.AutoSize = true;
            this.checkNotify.Location = new System.Drawing.Point(15, 100);
            this.checkNotify.Name = "checkNotify";
            this.checkNotify.Size = new System.Drawing.Size(128, 19);
            this.checkNotify.TabIndex = 4;
            this.checkNotify.Text = "Show Notifications";
            this.checkNotify.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 175);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkNotify);
            this.Controls.Add(this.checkMuteMic);
            this.Controls.Add(this.checkMuteSystem);
            this.Controls.Add(this.numericIdleTimeout);
            this.Controls.Add(this.lblIdleTimeout);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "MuteMe Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericIdleTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
