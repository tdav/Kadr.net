namespace Kadr.Users
{
    partial class FrmUserAccess
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserAccess));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.dx = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.lsList = new DevExpress.XtraEditors.ListBoxControl();
            this.lsDest = new DevExpress.XtraEditors.ListBoxControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edName = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDelAccess = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsAccess = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsDest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 431);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(614, 47);
            this.panelControl1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(560, 6);
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.TabStop = false;
            this.btnClose.ToolTip = "Выход";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(516, 6);
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.ToolTip = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dx
            // 
            this.dx.ContainerControl = this;
            // 
            // lsList
            // 
            this.lsList.DisplayMember = "Name";
            this.lsList.Location = new System.Drawing.Point(7, 59);
            this.lsList.Name = "lsList";
            this.lsList.Size = new System.Drawing.Size(277, 367);
            this.lsList.TabIndex = 17;
            this.lsList.TabStop = false;
            this.lsList.ValueMember = "Id";
            this.lsList.DoubleClick += new System.EventHandler(this.lsList_DoubleClick);
            // 
            // lsDest
            // 
            this.lsDest.DisplayMember = "Name";
            this.lsDest.Location = new System.Drawing.Point(334, 59);
            this.lsDest.Name = "lsDest";
            this.lsDest.Size = new System.Drawing.Size(279, 367);
            this.lsDest.TabIndex = 18;
            this.lsDest.TabStop = false;
            this.lsDest.ValueMember = "Id";
            this.lsDest.DoubleClick += new System.EventHandler(this.lsDest_DoubleClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.edName);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(614, 50);
            this.panelControl2.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(23, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 18);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Наименование";
            // 
            // edName
            // 
            this.edName.Location = new System.Drawing.Point(129, 12);
            this.edName.Name = "edName";
            this.edName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edName.Properties.Appearance.Options.UseFont = true;
            this.edName.Size = new System.Drawing.Size(477, 24);
            this.edName.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDelAccess);
            this.panelControl3.Controls.Add(this.btnInsAccess);
            this.panelControl3.Location = new System.Drawing.Point(284, 59);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(50, 367);
            this.panelControl3.TabIndex = 20;
            // 
            // btnDelAccess
            // 
            this.btnDelAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelAccess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelAccess.ImageOptions.Image")));
            this.btnDelAccess.Location = new System.Drawing.Point(7, 198);
            this.btnDelAccess.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelAccess.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDelAccess.Name = "btnDelAccess";
            this.btnDelAccess.Size = new System.Drawing.Size(38, 35);
            this.btnDelAccess.TabIndex = 8;
            this.btnDelAccess.TabStop = false;
            this.btnDelAccess.ToolTip = "Выход";
            this.btnDelAccess.Click += new System.EventHandler(this.DelAccess);
            // 
            // btnInsAccess
            // 
            this.btnInsAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsAccess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInsAccess.ImageOptions.Image")));
            this.btnInsAccess.Location = new System.Drawing.Point(6, 157);
            this.btnInsAccess.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnInsAccess.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnInsAccess.Name = "btnInsAccess";
            this.btnInsAccess.Size = new System.Drawing.Size(38, 35);
            this.btnInsAccess.TabIndex = 7;
            this.btnInsAccess.TabStop = false;
            this.btnInsAccess.ToolTip = "Выход";
            this.btnInsAccess.Click += new System.EventHandler(this.InsAccess);
            // 
            // FrmUserAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(618, 480);
            this.ControlBox = false;
            this.Controls.Add(this.lsList);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.lsDest);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FrmUserAccess";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Доступ пользователя";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsDest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dx;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.ListBoxControl lsDest;
        private DevExpress.XtraEditors.ListBoxControl lsList;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edName;
        private DevExpress.XtraEditors.SimpleButton btnDelAccess;
        private DevExpress.XtraEditors.SimpleButton btnInsAccess;
    }
}