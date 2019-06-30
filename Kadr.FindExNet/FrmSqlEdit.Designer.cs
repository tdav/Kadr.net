namespace Kadr.FindExNet
{
    partial class FrmSqlEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSqlEdit));
            this.edSql = new DevExpress.XtraEditors.MemoEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRun = new DevExpress.XtraEditors.SimpleButton();
            this.btnCount = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edSql.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // edSql
            // 
            this.edSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edSql.EditValue = "asdfasfasd";
            this.edSql.Location = new System.Drawing.Point(0, 0);
            this.edSql.Name = "edSql";
            this.edSql.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.edSql.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edSql.Properties.Appearance.ForeColor = System.Drawing.Color.Lime;
            this.edSql.Properties.Appearance.Options.UseBackColor = true;
            this.edSql.Properties.Appearance.Options.UseFont = true;
            this.edSql.Properties.Appearance.Options.UseForeColor = true;
            this.edSql.Size = new System.Drawing.Size(892, 456);
            this.edSql.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(741, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Чиқиш";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCount);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 55);
            this.panel1.TabIndex = 2;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRun.Appearance.Options.UseFont = true;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.Location = new System.Drawing.Point(596, 7);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(139, 40);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Хисоблаш";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnCount
            // 
            this.btnCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCount.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCount.Appearance.Options.UseFont = true;
            this.btnCount.Image = ((System.Drawing.Image)(resources.GetObject("btnCount.Image")));
            this.btnCount.Location = new System.Drawing.Point(449, 7);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(139, 40);
            this.btnCount.TabIndex = 1;
            this.btnCount.Text = "Натижа сони";
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // FrmSqlEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 511);
            this.Controls.Add(this.edSql);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSqlEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SqlEdit";
            ((System.ComponentModel.ISupportInitialize)(this.edSql.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Panel panel1;
        public DevExpress.XtraEditors.MemoEdit edSql;
        private DevExpress.XtraEditors.SimpleButton btnRun;
        private DevExpress.XtraEditors.SimpleButton btnCount;
    }
}