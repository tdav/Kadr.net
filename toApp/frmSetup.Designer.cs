namespace App
{
    partial class frmSetup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetup));
            this.vGridControl = new DevExpress.XtraVerticalGrid.VGridControl();
            this.bsRes = new System.Windows.Forms.BindingSource(this.components);
            this.cbObl = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cbRayon = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cbTuri = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cbKol = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Obl = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Rayon = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Turi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.KolLic = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbObl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRayon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTuri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKol)).BeginInit();
            this.SuspendLayout();
            // 
            // vGridControl
            // 
            this.vGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGridControl.DataSource = this.bsRes;
            this.vGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.vGridControl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vGridControl.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGridControl.Location = new System.Drawing.Point(0, 0);
            this.vGridControl.Name = "vGridControl";
            this.vGridControl.OptionsBehavior.UseEnterAsTab = true;
            this.vGridControl.RecordWidth = 138;
            this.vGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbObl,
            this.cbRayon,
            this.cbTuri,
            this.cbKol});
            this.vGridControl.RowHeaderWidth = 62;
            this.vGridControl.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.Obl,
            this.Rayon,
            this.Turi,
            this.KolLic});
            this.vGridControl.Size = new System.Drawing.Size(450, 135);
            this.vGridControl.TabIndex = 0;
            this.vGridControl.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.vGridControl_CellValueChanged);
            // 
            // cbObl
            // 
            this.cbObl.AutoHeight = false;
            this.cbObl.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbObl.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Имя5", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cbObl.DisplayMember = "NAME";
            this.cbObl.Name = "cbObl";
            this.cbObl.NullText = "";
            this.cbObl.ShowHeader = false;
            this.cbObl.ValueMember = "ID";
            // 
            // cbRayon
            // 
            this.cbRayon.AutoHeight = false;
            this.cbRayon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbRayon.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Имя6", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cbRayon.DisplayMember = "NAME";
            this.cbRayon.Name = "cbRayon";
            this.cbRayon.NullText = "";
            this.cbRayon.ShowHeader = false;
            this.cbRayon.ValueMember = "ID";
            // 
            // cbTuri
            // 
            this.cbTuri.AutoHeight = false;
            this.cbTuri.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTuri.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Имя2", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cbTuri.DisplayMember = "NAME";
            this.cbTuri.Name = "cbTuri";
            this.cbTuri.NullText = "";
            this.cbTuri.ShowHeader = false;
            this.cbTuri.ValueMember = "ID";
            // 
            // cbKol
            // 
            this.cbKol.AutoHeight = false;
            this.cbKol.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbKol.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Имя1", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cbKol.DisplayMember = "NAME";
            this.cbKol.Name = "cbKol";
            this.cbKol.NullText = "";
            this.cbKol.ShowHeader = false;
            this.cbKol.ValueMember = "ID";
            // 
            // Obl
            // 
            this.Obl.Height = 27;
            this.Obl.Name = "Obl";
            this.Obl.Properties.Caption = "Вилоят";
            this.Obl.Properties.FieldName = "Oblast";
            this.Obl.Properties.RowEdit = this.cbObl;
            // 
            // Rayon
            // 
            this.Rayon.Height = 31;
            this.Rayon.Name = "Rayon";
            this.Rayon.Properties.Caption = "Район";
            this.Rayon.Properties.FieldName = "Rayon";
            this.Rayon.Properties.RowEdit = this.cbRayon;
            // 
            // Turi
            // 
            this.Turi.Height = 31;
            this.Turi.Name = "Turi";
            this.Turi.Properties.Caption = "Вид учереждения";
            this.Turi.Properties.FieldName = "Turi";
            this.Turi.Properties.ReadOnly = false;
            this.Turi.Properties.RowEdit = this.cbTuri;
            // 
            // KolLic
            // 
            this.KolLic.Height = 28;
            this.KolLic.Name = "KolLic";
            this.KolLic.Properties.Caption = "Номи";
            this.KolLic.Properties.FieldName = "Ucherejdeniya";
            this.KolLic.Properties.RowEdit = this.cbKol;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(316, 142);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 39);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Чиқиш";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(186, 142);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 39);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сақлаш";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 187);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.vGridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Созлаш";
            this.Load += new System.EventHandler(this.FrmSetup_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbObl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRayon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTuri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vGridControl;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Obl;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Rayon;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Turi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow KolLic;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbObl;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbRayon;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbTuri;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbKol;
        private System.Windows.Forms.BindingSource bsRes;
    }
}