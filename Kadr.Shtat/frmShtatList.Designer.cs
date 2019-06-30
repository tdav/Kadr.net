namespace Kadr.Shtat
{
    partial class frmShtatList
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
                components.Dispose();                              }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShtatList));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnDel = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.cbOblastbe = new DevExpress.XtraBars.BarEditItem();
            this.cbOblast = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cbRayonbe = new DevExpress.XtraBars.BarEditItem();
            this.cbRayon = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cbKolejbe = new DevExpress.XtraBars.BarEditItem();
            this.cbKolej = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ribbonPageCategoryCMdi = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.cbGrdUcherej = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cbGrdDoljnost = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cbGrdOblast = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cbGrdRayon = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource();
            this.kdnDataSet1 = new Kadr.Data.KdnDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOBLAST = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbOblastgr = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRAYON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbRayongr = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colKOLEJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbUcherejgr = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colKOL_CHAS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDOLJNOST = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbDoljnostgr = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colPREDMET = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbFangr = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEDITDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbshatTableAdapter1 = new Kadr.Data.KdnDataSetTableAdapters.TBSHATTableAdapter();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOblast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRayon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKolej)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrdUcherej)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrdDoljnost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrdOblast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrdRayon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdnDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOblastgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRayongr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUcherejgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoljnostgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFangr)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnNew,
            this.btnDel,
            this.btnClose,
            this.cbOblastbe,
            this.cbRayonbe,
            this.cbKolejbe,
            this.btnEdit});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategoryCMdi});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbOblast,
            this.cbRayon,
            this.cbKolej});
            this.ribbon.Size = new System.Drawing.Size(912, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Янги";
            this.btnNew.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNew.Glyph")));
            this.btnNew.Id = 1;
            this.btnNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNew.LargeGlyph")));
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnDel
            // 
            this.btnDel.Caption = "Ўчириш";
            this.btnDel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDel.Glyph")));
            this.btnDel.Id = 2;
            this.btnDel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDel.LargeGlyph")));
            this.btnDel.Name = "btnDel";
            this.btnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDel_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Чиқиш";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 3;
            this.btnClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClose.LargeGlyph")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // cbOblastbe
            // 
            this.cbOblastbe.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
            this.cbOblastbe.Caption = "Вилият            ";
            this.cbOblastbe.Edit = this.cbOblast;
            this.cbOblastbe.EditWidth = 300;
            this.cbOblastbe.Id = 4;
            this.cbOblastbe.Name = "cbOblastbe";
            this.cbOblastbe.EditValueChanged += new System.EventHandler(this.cbOblastbe_EditValueChanged);
            // 
            // cbOblast
            // 
            this.cbOblast.AutoHeight = false;
            this.cbOblast.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbOblast.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 200, "Имя1")});
            this.cbOblast.DisplayMember = "NAME";
            this.cbOblast.DropDownRows = 15;
            this.cbOblast.Name = "cbOblast";
            this.cbOblast.NullText = "";
            this.cbOblast.ShowHeader = false;
            this.cbOblast.ValueMember = "ID";
            // 
            // cbRayonbe
            // 
            this.cbRayonbe.Caption = "Туман              ";
            this.cbRayonbe.Edit = this.cbRayon;
            this.cbRayonbe.EditWidth = 300;
            this.cbRayonbe.Id = 5;
            this.cbRayonbe.Name = "cbRayonbe";
            // 
            // cbRayon
            // 
            this.cbRayon.AutoHeight = false;
            this.cbRayon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbRayon.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 200, "Имя2")});
            this.cbRayon.DisplayMember = "NAME";
            this.cbRayon.DropDownRows = 15;
            this.cbRayon.Name = "cbRayon";
            this.cbRayon.NullText = "";
            this.cbRayon.ShowHeader = false;
            this.cbRayon.ValueMember = "ID";
            // 
            // cbKolejbe
            // 
            this.cbKolejbe.Caption = "Ўқув муассаса";
            this.cbKolejbe.Edit = this.cbKolej;
            this.cbKolejbe.EditWidth = 300;
            this.cbKolejbe.Id = 6;
            this.cbKolejbe.Name = "cbKolejbe";
            this.cbKolejbe.EditValueChanged += new System.EventHandler(this.cbKolejbe_EditValueChanged);
            // 
            // cbKolej
            // 
            this.cbKolej.AutoHeight = false;
            this.cbKolej.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbKolej.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 200, "Имя3")});
            this.cbKolej.DisplayMember = "NAME";
            this.cbKolej.DropDownRows = 15;
            this.cbKolej.Name = "cbKolej";
            this.cbKolej.NullText = "";
            this.cbKolej.ShowHeader = false;
            this.cbKolej.ValueMember = "ID";
            // 
            // ribbonPageCategoryCMdi
            // 
            this.ribbonPageCategoryCMdi.Name = "ribbonPageCategoryCMdi";
            this.ribbonPageCategoryCMdi.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonPageCategoryCMdi.Text = "Қўшимча";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Штат";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDel);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.cbOblastbe);
            this.ribbonPageGroup2.ItemLinks.Add(this.cbRayonbe);
            this.ribbonPageGroup2.ItemLinks.Add(this.cbKolejbe);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Излаш шартлари";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 582);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(912, 31);
            // 
            // cbGrdUcherej
            // 
            this.cbGrdUcherej.AutoHeight = false;
            this.cbGrdUcherej.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGrdUcherej.DisplayMember = "NAME";
            this.cbGrdUcherej.Name = "cbGrdUcherej";
            this.cbGrdUcherej.NullText = "";
            this.cbGrdUcherej.ValueMember = "ID";
            // 
            // cbGrdDoljnost
            // 
            this.cbGrdDoljnost.AutoHeight = false;
            this.cbGrdDoljnost.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGrdDoljnost.DisplayMember = "NAME";
            this.cbGrdDoljnost.Name = "cbGrdDoljnost";
            this.cbGrdDoljnost.NullText = "";
            this.cbGrdDoljnost.ValueMember = "ID";
            // 
            // cbGrdOblast
            // 
            this.cbGrdOblast.AutoHeight = false;
            this.cbGrdOblast.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGrdOblast.DisplayMember = "NAME";
            this.cbGrdOblast.Name = "cbGrdOblast";
            this.cbGrdOblast.NullText = "";
            this.cbGrdOblast.ValueMember = "ID";
            // 
            // cbGrdRayon
            // 
            this.cbGrdRayon.AutoHeight = false;
            this.cbGrdRayon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGrdRayon.DisplayMember = "NAME";
            this.cbGrdRayon.Name = "cbGrdRayon";
            this.cbGrdRayon.NullText = "";
            this.cbGrdRayon.ValueMember = "ID";
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource1;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 143);
            this.gridControl.MainView = this.gridView1;
            this.gridControl.MenuManager = this.ribbon;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbOblastgr,
            this.cbRayongr,
            this.cbDoljnostgr,
            this.cbUcherejgr,
            this.cbFangr});
            this.gridControl.Size = new System.Drawing.Size(912, 439);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "TBSHAT";
            this.bindingSource1.DataSource = this.kdnDataSet1;
            this.bindingSource1.Sort = "";
            // 
            // kdnDataSet1
            // 
            this.kdnDataSet1.DataSetName = "KdnDataSet";
            this.kdnDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOBLAST,
            this.colRAYON,
            this.colKOLEJ,
            this.colKOL_CHAS,
            this.colDOLJNOST,
            this.colPREDMET,
            this.colEDITDATE});
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKOL_CHAS, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colOBLAST
            // 
            this.colOBLAST.Caption = "Вилоят";
            this.colOBLAST.ColumnEdit = this.cbOblastgr;
            this.colOBLAST.FieldName = "OBLAST";
            this.colOBLAST.Name = "colOBLAST";
            this.colOBLAST.Visible = true;
            this.colOBLAST.VisibleIndex = 0;
            this.colOBLAST.Width = 167;
            // 
            // cbOblastgr
            // 
            this.cbOblastgr.AutoHeight = false;
            this.cbOblastgr.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbOblastgr.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 200, "Name1")});
            this.cbOblastgr.DisplayMember = "NAME";
            this.cbOblastgr.DropDownRows = 15;
            this.cbOblastgr.Name = "cbOblastgr";
            this.cbOblastgr.NullText = "";
            this.cbOblastgr.ShowHeader = false;
            this.cbOblastgr.ValueMember = "ID";
            // 
            // colRAYON
            // 
            this.colRAYON.Caption = "Туман";
            this.colRAYON.ColumnEdit = this.cbRayongr;
            this.colRAYON.FieldName = "RAYON";
            this.colRAYON.Name = "colRAYON";
            this.colRAYON.Visible = true;
            this.colRAYON.VisibleIndex = 1;
            this.colRAYON.Width = 167;
            // 
            // cbRayongr
            // 
            this.cbRayongr.AutoHeight = false;
            this.cbRayongr.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbRayongr.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 200, "Name2")});
            this.cbRayongr.DisplayMember = "NAME";
            this.cbRayongr.DropDownRows = 15;
            this.cbRayongr.Name = "cbRayongr";
            this.cbRayongr.NullText = "";
            this.cbRayongr.ShowHeader = false;
            this.cbRayongr.ValueMember = "ID";
            // 
            // colKOLEJ
            // 
            this.colKOLEJ.Caption = "Уқув муассаса";
            this.colKOLEJ.ColumnEdit = this.cbUcherejgr;
            this.colKOLEJ.FieldName = "KOLEJ";
            this.colKOLEJ.Name = "colKOLEJ";
            this.colKOLEJ.Visible = true;
            this.colKOLEJ.VisibleIndex = 2;
            this.colKOLEJ.Width = 348;
            // 
            // cbUcherejgr
            // 
            this.cbUcherejgr.AutoHeight = false;
            this.cbUcherejgr.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUcherejgr.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 200, "Name4")});
            this.cbUcherejgr.DisplayMember = "NAME";
            this.cbUcherejgr.DropDownRows = 15;
            this.cbUcherejgr.Name = "cbUcherejgr";
            this.cbUcherejgr.NullText = "";
            this.cbUcherejgr.ShowHeader = false;
            this.cbUcherejgr.ValueMember = "ID";
            // 
            // colKOL_CHAS
            // 
            this.colKOL_CHAS.Caption = "Соат";
            this.colKOL_CHAS.FieldName = "KOL_CHAS";
            this.colKOL_CHAS.Name = "colKOL_CHAS";
            this.colKOL_CHAS.Visible = true;
            this.colKOL_CHAS.VisibleIndex = 5;
            this.colKOL_CHAS.Width = 55;
            // 
            // colDOLJNOST
            // 
            this.colDOLJNOST.Caption = "Лавозимлар";
            this.colDOLJNOST.ColumnEdit = this.cbDoljnostgr;
            this.colDOLJNOST.FieldName = "DOLJNOST";
            this.colDOLJNOST.Name = "colDOLJNOST";
            this.colDOLJNOST.Visible = true;
            this.colDOLJNOST.VisibleIndex = 3;
            this.colDOLJNOST.Width = 146;
            // 
            // cbDoljnostgr
            // 
            this.cbDoljnostgr.AutoHeight = false;
            this.cbDoljnostgr.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDoljnostgr.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 200, "Name3")});
            this.cbDoljnostgr.DisplayMember = "NAME";
            this.cbDoljnostgr.DropDownRows = 15;
            this.cbDoljnostgr.Name = "cbDoljnostgr";
            this.cbDoljnostgr.NullText = "";
            this.cbDoljnostgr.ShowHeader = false;
            this.cbDoljnostgr.ValueMember = "ID";
            // 
            // colPREDMET
            // 
            this.colPREDMET.Caption = " Фанлар ва йўналишлар номи";
            this.colPREDMET.ColumnEdit = this.cbFangr;
            this.colPREDMET.FieldName = "PREDMET";
            this.colPREDMET.Name = "colPREDMET";
            this.colPREDMET.Visible = true;
            this.colPREDMET.VisibleIndex = 4;
            this.colPREDMET.Width = 212;
            // 
            // cbFangr
            // 
            this.cbFangr.AutoHeight = false;
            this.cbFangr.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbFangr.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 200, "Name5")});
            this.cbFangr.DisplayMember = "NAME";
            this.cbFangr.DropDownRows = 15;
            this.cbFangr.Name = "cbFangr";
            this.cbFangr.NullText = "";
            this.cbFangr.ShowHeader = false;
            this.cbFangr.ValueMember = "ID";
            // 
            // colEDITDATE
            // 
            this.colEDITDATE.Caption = "Сана";
            this.colEDITDATE.FieldName = "EDITDATE";
            this.colEDITDATE.Name = "colEDITDATE";
            this.colEDITDATE.Visible = true;
            this.colEDITDATE.VisibleIndex = 6;
            this.colEDITDATE.Width = 80;
            // 
            // tbshatTableAdapter1
            // 
            this.tbshatTableAdapter1.ClearBeforeFill = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Ўзгартириш";
            this.btnEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEdit.Glyph")));
            this.btnEdit.Id = 7;
            this.btnEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEdit.LargeGlyph")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // frmShtatList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 613);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmShtatList";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Штат";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOblast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRayon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKolej)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrdUcherej)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrdDoljnost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrdOblast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrdRayon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdnDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOblastgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRayongr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUcherejgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoljnostgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFangr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategoryCMdi;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnDel;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbGrdUcherej;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbGrdDoljnost;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbGrdOblast;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbGrdRayon;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Data.KdnDataSet kdnDataSet1;
        private DevExpress.XtraGrid.Columns.GridColumn colOBLAST;
        private DevExpress.XtraGrid.Columns.GridColumn colRAYON;
        private DevExpress.XtraGrid.Columns.GridColumn colKOLEJ;
        private DevExpress.XtraGrid.Columns.GridColumn colKOL_CHAS;
        private DevExpress.XtraGrid.Columns.GridColumn colDOLJNOST;
        private DevExpress.XtraGrid.Columns.GridColumn colPREDMET;
        private DevExpress.XtraGrid.Columns.GridColumn colEDITDATE;
        private Data.KdnDataSetTableAdapters.TBSHATTableAdapter tbshatTableAdapter1;
        private DevExpress.XtraBars.BarEditItem cbOblastbe;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbOblast;
        private DevExpress.XtraBars.BarEditItem cbRayonbe;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbRayon;
        private DevExpress.XtraBars.BarEditItem cbKolejbe;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbKolej;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbOblastgr;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbRayongr;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbDoljnostgr;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbUcherejgr;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbFangr;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}