namespace Kadr.UtilsUI
{
    partial class FrmPing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param TB_NAMEUZ="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.meLog = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.meLog.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // meLog
            // 
            this.meLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meLog.EditValue = "vzxmcnbzmxncvmzxcv\r\nasdfasdfasdf";
            this.meLog.Location = new System.Drawing.Point(0, 0);
            this.meLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.meLog.Name = "meLog";
            this.meLog.Properties.AllowFocused = false;
            this.meLog.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.meLog.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.meLog.Properties.Appearance.ForeColor = System.Drawing.Color.Lime;
            this.meLog.Properties.Appearance.Options.UseBackColor = true;
            this.meLog.Properties.Appearance.Options.UseFont = true;
            this.meLog.Properties.Appearance.Options.UseForeColor = true;
            this.meLog.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Lime;
            this.meLog.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.meLog.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.meLog.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.meLog.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.meLog.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.meLog.Size = new System.Drawing.Size(706, 676);
            this.meLog.TabIndex = 0;
            this.meLog.Click += new System.EventHandler(this.meLog_Click);
            this.meLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.meLog_KeyDown);
            // 
            // FrmPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(706, 676);
            this.Controls.Add(this.meLog);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmPing";
            this.Opacity = 0.7D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проверка связи";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Shown += new System.EventHandler(this.frmPing_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPing_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.meLog.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit meLog;
    }
}