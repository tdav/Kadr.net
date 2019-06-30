namespace Kadr.Users
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.sbExit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.edLogin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edPasw = new DevExpress.XtraEditors.TextEdit();
            this.lbVer = new DevExpress.XtraEditors.LabelControl();
            this.lbIp = new DevExpress.XtraEditors.LabelControl();
            this.btnSetIpDatabase = new DevExpress.XtraEditors.SimpleButton();
            this.lbRegistrationInfo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edPasw.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbExit
            // 
            this.sbExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sbExit.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.sbExit.Appearance.ForeColor = System.Drawing.Color.Black;
            this.sbExit.Appearance.Options.UseFont = true;
            this.sbExit.Appearance.Options.UseForeColor = true;
            this.sbExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.sbExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbExit.ImageOptions.Image")));
            this.sbExit.Location = new System.Drawing.Point(468, 210);
            this.sbExit.Name = "sbExit";
            this.sbExit.Size = new System.Drawing.Size(122, 38);
            this.sbExit.TabIndex = 3;
            this.sbExit.Text = "Закрыть";
            this.sbExit.Click += new System.EventHandler(this.sbExit_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl7.Appearance.Options.UseBackColor = true;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelControl7.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.labelControl7.Location = new System.Drawing.Point(338, 333);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(298, 18);
            this.labelControl7.TabIndex = 30;
            this.labelControl7.Text = "тел. (+998 71) 1234567    (+998 71) 1234567";
            this.labelControl7.UseMnemonic = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(346, 83);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(98, 20);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "Пользователь";
            // 
            // sbOK
            // 
            this.sbOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sbOK.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.sbOK.Appearance.ForeColor = System.Drawing.Color.Black;
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Appearance.Options.UseForeColor = true;
            this.sbOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.sbOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbOK.ImageOptions.Image")));
            this.sbOK.Location = new System.Drawing.Point(337, 210);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(122, 38);
            this.sbOK.TabIndex = 2;
            this.sbOK.Text = "Вход";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(26, 57);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.OptionsMask.MaskType = DevExpress.XtraEditors.Controls.PictureEditMaskType.RoundedRect;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Size = new System.Drawing.Size(288, 256);
            this.pictureEdit1.TabIndex = 29;
            // 
            // edLogin
            // 
            this.edLogin.EditValue = "";
            this.edLogin.EnterMoveNextControl = true;
            this.edLogin.Location = new System.Drawing.Point(338, 107);
            this.edLogin.Name = "edLogin";
            this.edLogin.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edLogin.Properties.Appearance.Options.UseFont = true;
            this.edLogin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.edLogin.Size = new System.Drawing.Size(298, 26);
            this.edLogin.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(348, 147);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 20);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Парол";
            // 
            // edPasw
            // 
            this.edPasw.EditValue = "";
            this.edPasw.EnterMoveNextControl = true;
            this.edPasw.Location = new System.Drawing.Point(338, 169);
            this.edPasw.Name = "edPasw";
            this.edPasw.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edPasw.Properties.Appearance.Options.UseFont = true;
            this.edPasw.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.edPasw.Properties.PasswordChar = '@';
            this.edPasw.Size = new System.Drawing.Size(298, 26);
            this.edPasw.TabIndex = 1;
            // 
            // lbVer
            // 
            this.lbVer.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbVer.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbVer.Appearance.Options.UseFont = true;
            this.lbVer.Appearance.Options.UseForeColor = true;
            this.lbVer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbVer.Location = new System.Drawing.Point(22, 332);
            this.lbVer.Name = "lbVer";
            this.lbVer.Size = new System.Drawing.Size(165, 18);
            this.lbVer.TabIndex = 30;
            this.lbVer.Text = "Аптека        v0.0.1";
            // 
            // lbIp
            // 
            this.lbIp.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbIp.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbIp.Appearance.Options.UseFont = true;
            this.lbIp.Appearance.Options.UseForeColor = true;
            this.lbIp.Appearance.Options.UseTextOptions = true;
            this.lbIp.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbIp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbIp.Location = new System.Drawing.Point(314, 309);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(322, 18);
            this.lbIp.TabIndex = 30;
            this.lbIp.Text = "Аптека        v0.0.1";
            // 
            // btnSetIpDatabase
            // 
            this.btnSetIpDatabase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSetIpDatabase.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSetIpDatabase.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSetIpDatabase.Appearance.Options.UseFont = true;
            this.btnSetIpDatabase.Appearance.Options.UseForeColor = true;
            this.btnSetIpDatabase.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSetIpDatabase.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSetIpDatabase.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSetIpDatabase.ImageOptions.Image")));
            this.btnSetIpDatabase.Location = new System.Drawing.Point(596, 210);
            this.btnSetIpDatabase.Name = "btnSetIpDatabase";
            this.btnSetIpDatabase.Size = new System.Drawing.Size(40, 38);
            this.btnSetIpDatabase.TabIndex = 3;
            this.btnSetIpDatabase.TabStop = false;
            this.btnSetIpDatabase.Click += new System.EventHandler(this.btnSetIpDatabase_Click);
            // 
            // lbRegistrationInfo
            // 
            this.lbRegistrationInfo.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbRegistrationInfo.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbRegistrationInfo.Appearance.Options.UseFont = true;
            this.lbRegistrationInfo.Appearance.Options.UseForeColor = true;
            this.lbRegistrationInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbRegistrationInfo.Location = new System.Drawing.Point(22, 12);
            this.lbRegistrationInfo.Name = "lbRegistrationInfo";
            this.lbRegistrationInfo.Size = new System.Drawing.Size(422, 18);
            this.lbRegistrationInfo.TabIndex = 30;
            this.lbRegistrationInfo.Text = "Аптека        v0.0.1";
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.sbOK;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.sbExit;
            this.ClientSize = new System.Drawing.Size(654, 363);
            this.Controls.Add(this.edPasw);
            this.Controls.Add(this.edLogin);
            this.Controls.Add(this.btnSetIpDatabase);
            this.Controls.Add(this.sbExit);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbRegistrationInfo);
            this.Controls.Add(this.lbVer);
            this.Controls.Add(this.lbIp);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.sbOK);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Darkroom";
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Opacity = 0.94D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация ойнаси";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.Shown += new System.EventHandler(this.FrmLogin_ShownAsync);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edPasw.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbExit;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.TextEdit edLogin;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit edPasw;
        private DevExpress.XtraEditors.LabelControl lbVer;
        private DevExpress.XtraEditors.LabelControl lbIp;
        private DevExpress.XtraEditors.SimpleButton btnSetIpDatabase;
        private DevExpress.XtraEditors.LabelControl lbRegistrationInfo;
    }
}