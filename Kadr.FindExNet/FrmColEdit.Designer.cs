namespace Kadr.FindExNet
{
    partial class FrmColEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmColEdit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDefalt = new DevExpress.XtraEditors.SimpleButton();
            this.btnRun = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridCol = new DevExpress.XtraGrid.GridControl();
            this.gridViewCol = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCol)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDefalt);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 511);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 55);
            this.panel1.TabIndex = 3;
            // 
            // btnDefalt
            // 
            this.btnDefalt.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDefalt.Appearance.Options.UseFont = true;
            this.btnDefalt.Image = ((System.Drawing.Image)(resources.GetObject("btnDefalt.Image")));
            this.btnDefalt.Location = new System.Drawing.Point(11, 7);
            this.btnDefalt.Name = "btnDefalt";
            this.btnDefalt.Size = new System.Drawing.Size(178, 40);
            this.btnDefalt.TabIndex = 1;
            this.btnDefalt.Text = "Олдинга холати";
            this.btnDefalt.Click += new System.EventHandler(this.btnDefalt_Click);
            // 
            // btnRun
            // 
            this.btnRun.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRun.Appearance.Options.UseFont = true;
            this.btnRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.Location = new System.Drawing.Point(321, 7);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(140, 40);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Сақлаш";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(467, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Бекор қилиш";
            // 
            // gridCol
            // 
            this.gridCol.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCol.Location = new System.Drawing.Point(0, 0);
            this.gridCol.MainView = this.gridViewCol;
            this.gridCol.Name = "gridCol";
            this.gridCol.Size = new System.Drawing.Size(619, 511);
            this.gridCol.TabIndex = 4;
            this.gridCol.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCol});
            // 
            // gridViewCol
            // 
            this.gridViewCol.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewCol.GridControl = this.gridCol;
            this.gridViewCol.Name = "gridViewCol";
            this.gridViewCol.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCol.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCol.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.gridViewCol.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewCol.OptionsCustomization.AllowGroup = false;
            this.gridViewCol.OptionsSelection.MultiSelect = true;
            this.gridViewCol.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Кўриниш";
            this.gridColumn1.FieldName = "Visible";
            this.gridColumn1.MaxWidth = 70;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 56;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Номи";
            this.gridColumn2.FieldName = "FieldName";
            this.gridColumn2.MaxWidth = 150;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 150;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Рўйхатдаги номи";
            this.gridColumn3.FieldName = "DisplayName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 395;
            // 
            // FrmColEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 566);
            this.Controls.Add(this.gridCol);
            this.Controls.Add(this.panel1);
            this.Name = "FrmColEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Экспорт қилинадиган руйхат";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnRun;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCol;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        public DevExpress.XtraGrid.GridControl gridCol;
        private DevExpress.XtraEditors.SimpleButton btnDefalt;
    }
}