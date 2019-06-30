namespace App
{
    partial class FrmTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTable));
            this.bsTable = new System.Windows.Forms.BindingSource(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.cbTables = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcTable = new DevExpress.XtraGrid.GridControl();
            this.gridViewTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.bsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTables.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.cbTables);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 431);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(890, 48);
            this.panelControl1.TabIndex = 1;
            this.panelControl1.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Таблица номи";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(637, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 37);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сақлаш";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(758, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 37);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Чиқиш";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbTables
            // 
            this.cbTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTables.EditValue = "";
            this.cbTables.Location = new System.Drawing.Point(176, 16);
            this.cbTables.Name = "cbTables";
            this.cbTables.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTables.Properties.DropDownRows = 14;
            this.cbTables.Properties.Items.AddRange(new object[] {
            "Давлат мукофотлари",
            "Ҳарбий унвон",
            "Вид учреждения",
            "Илмий даражаси",
            "Вид должности",
            "Национальность",
            "Район (город)",
            "Педагогическое образование",
            "Пол",
            "Родственик",
            "Повышения квалификации",
            "Семейны полжения",
            "Вузы",
            "Ученый степень",
            "Давлат",
            "Чет тиллари",
            "Маълумоти",
            "Тип обучения",
            "Спеециалность",
            "В данной отчетом периоде",
            "Категория",
            "Предмет",
            "Принят на работу",
            "Вид преподоваемого дополнительного предмет",
            "Партии",
            "Педагог",
            "Место прохождение ПК",
            "Коллеж",
            "Лицей",
            "Вид обучения",
            "Штат",
            "Привлечение к аттестац",
            "Резултат атестатции"});
            this.cbTables.Size = new System.Drawing.Size(379, 20);
            this.cbTables.TabIndex = 0;
            this.cbTables.SelectedValueChanged += new System.EventHandler(this.cbTable_SelectedValueChanged);
            // 
            // gcTable
            // 
            this.gcTable.DataMember = null;
            this.gcTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTable.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.gcTable.Location = new System.Drawing.Point(0, 0);
            this.gcTable.MainView = this.gridViewTable;
            this.gcTable.Name = "gcTable";
            this.gcTable.ShowOnlyPredefinedDetails = true;
            this.gcTable.Size = new System.Drawing.Size(890, 431);
            this.gcTable.TabIndex = 5;
            this.gcTable.UseEmbeddedNavigator = true;
            this.gcTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTable});
            // 
            // gridViewTable
            // 
            this.gridViewTable.GridControl = this.gcTable;
            this.gridViewTable.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tbJurnals.Ball", null, "(Summa ball = {0:c2})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "tbJurnals.Active", null, "(Active student = {0})")});
            this.gridViewTable.Name = "gridViewTable";
            this.gridViewTable.NewItemRowText = "Янги маълумот киритиш учун";
            this.gridViewTable.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewTable.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gridViewTable.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridViewTable.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridViewTable.OptionsView.ShowGroupPanel = false;
            // 
            // FrmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 479);
            this.Controls.Add(this.gcTable);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Қўшимча табалицалар";
            ((System.ComponentModel.ISupportInitialize)(this.bsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbTables.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.ComboBoxEdit cbTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsTable;
        private DevExpress.XtraGrid.GridControl gcTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTable;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}