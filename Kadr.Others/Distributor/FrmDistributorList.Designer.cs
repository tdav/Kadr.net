namespace Apteka.Others
{
    partial class FrmDistributorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDistributorList));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDel = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnFind = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bandedGridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbRegion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbDistrict = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn51 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn52 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn55 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbUser1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bandedGridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbUser2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDistrict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUser1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUser2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnEdit,
            this.btnNew,
            this.barButtonItem3,
            this.btnDel,
            this.btnClose,
            this.btnFind});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1478, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Изменить";
            this.btnEdit.Id = 1;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.LargeImage")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Новый-F1";
            this.btnNew.Id = 2;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.LargeImage")));
            this.btnNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Добавить в список";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // btnDel
            // 
            this.btnDel.Caption = "Изменить состояние";
            this.btnDel.Id = 4;
            this.btnDel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.ImageOptions.Image")));
            this.btnDel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDel.ImageOptions.LargeImage")));
            this.btnDel.Name = "btnDel";
            this.btnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDel_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Закрыть";
            this.btnClose.Id = 5;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.LargeImage")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCloseItemClick);
            // 
            // btnFind
            // 
            this.btnFind.Caption = "Поиск-F7";
            this.btnFind.Id = 8;
            this.btnFind.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.ImageOptions.Image")));
            this.btnFind.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFind.ImageOptions.LargeImage")));
            this.btnFind.Name = "btnFind";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Список дистрибьюторов";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDel);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Основные операции";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Выход";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 549);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1478, 31);
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl.EmbeddedNavigator.TextStringFormat = " {0} дан {1}";
            this.gridControl.Location = new System.Drawing.Point(0, 143);
            this.gridControl.MainView = this.gridView1;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbUser1,
            this.cbUser2,
            this.cbRegion,
            this.cbDistrict});
            this.gridControl.Size = new System.Drawing.Size(1478, 406);
            this.gridControl.TabIndex = 12;
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.bandedGridColumn49,
            this.bandedGridColumn50,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn5,
            this.bandedGridColumn51,
            this.gridColumn14,
            this.gridColumn13,
            this.gridColumn12,
            this.gridColumn11,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn16,
            this.gridColumn15,
            this.bandedGridColumn52,
            this.bandedGridColumn53,
            this.bandedGridColumn55,
            this.gridColumn3,
            this.bandedGridColumn56,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4});
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.GroupPanelText = "Перетащите поле для группировки";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // bandedGridColumn49
            // 
            this.bandedGridColumn49.Caption = "Название";
            this.bandedGridColumn49.FieldName = "OrganizationName";
            this.bandedGridColumn49.Name = "bandedGridColumn49";
            this.bandedGridColumn49.Visible = true;
            this.bandedGridColumn49.VisibleIndex = 0;
            this.bandedGridColumn49.Width = 121;
            // 
            // bandedGridColumn50
            // 
            this.bandedGridColumn50.Caption = "Ответственный лицо";
            this.bandedGridColumn50.FieldName = "PersonName";
            this.bandedGridColumn50.Name = "bandedGridColumn50";
            this.bandedGridColumn50.Visible = true;
            this.bandedGridColumn50.VisibleIndex = 1;
            this.bandedGridColumn50.Width = 156;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Область";
            this.gridColumn7.ColumnEdit = this.cbRegion;
            this.gridColumn7.FieldName = "RegionId";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 100;
            // 
            // cbRegion
            // 
            this.cbRegion.AutoHeight = false;
            this.cbRegion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbRegion.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.cbRegion.DisplayMember = "Name";
            this.cbRegion.KeyMember = "Id";
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.NullText = "";
            this.cbRegion.ShowFooter = false;
            this.cbRegion.ShowHeader = false;
            this.cbRegion.ValueMember = "Id";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Район";
            this.gridColumn6.ColumnEdit = this.cbDistrict;
            this.gridColumn6.FieldName = "DistrictId";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 100;
            // 
            // cbDistrict
            // 
            this.cbDistrict.AutoHeight = false;
            this.cbDistrict.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDistrict.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name3")});
            this.cbDistrict.DisplayMember = "Name";
            this.cbDistrict.KeyMember = "Id";
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.ShowFooter = false;
            this.cbDistrict.ShowHeader = false;
            this.cbDistrict.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbDistrict.ValueMember = "Id";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Адрес";
            this.gridColumn5.FieldName = "Address";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 100;
            // 
            // bandedGridColumn51
            // 
            this.bandedGridColumn51.Caption = "Телефон";
            this.bandedGridColumn51.FieldName = "Phone";
            this.bandedGridColumn51.Name = "bandedGridColumn51";
            this.bandedGridColumn51.Visible = true;
            this.bandedGridColumn51.VisibleIndex = 5;
            this.bandedGridColumn51.Width = 99;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Факс";
            this.gridColumn14.FieldName = "Fax";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
            this.gridColumn14.Width = 103;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Email";
            this.gridColumn13.FieldName = "Email";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 7;
            this.gridColumn13.Width = 105;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "ИНН";
            this.gridColumn12.FieldName = "INN";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            this.gridColumn12.Width = 100;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "МФО";
            this.gridColumn11.FieldName = "MFO";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 112;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "ОКОНХ";
            this.gridColumn10.FieldName = "OKONH";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            this.gridColumn10.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Банк";
            this.gridColumn9.FieldName = "BankName";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 11;
            this.gridColumn9.Width = 100;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Расчетный счет";
            this.gridColumn8.FieldName = "SettlementAccount";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 13;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Дп. инфо";
            this.gridColumn16.FieldName = "Description";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 12;
            this.gridColumn16.Width = 100;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Расположение карты";
            this.gridColumn15.FieldName = "Location";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Width = 50;
            // 
            // bandedGridColumn52
            // 
            this.bandedGridColumn52.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumn52.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumn52.Caption = "Дата создания";
            this.bandedGridColumn52.FieldName = "CreateDate";
            this.bandedGridColumn52.Name = "bandedGridColumn52";
            this.bandedGridColumn52.Visible = true;
            this.bandedGridColumn52.VisibleIndex = 14;
            this.bandedGridColumn52.Width = 100;
            // 
            // bandedGridColumn53
            // 
            this.bandedGridColumn53.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumn53.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumn53.Caption = "Дата изменения";
            this.bandedGridColumn53.FieldName = "UpdateDate";
            this.bandedGridColumn53.Name = "bandedGridColumn53";
            this.bandedGridColumn53.Visible = true;
            this.bandedGridColumn53.VisibleIndex = 15;
            this.bandedGridColumn53.Width = 100;
            // 
            // bandedGridColumn55
            // 
            this.bandedGridColumn55.Caption = "Отправлено";
            this.bandedGridColumn55.FieldName = "Send";
            this.bandedGridColumn55.Name = "bandedGridColumn55";
            this.bandedGridColumn55.Visible = true;
            this.bandedGridColumn55.VisibleIndex = 16;
            this.bandedGridColumn55.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Пользователь (создаль)";
            this.gridColumn3.ColumnEdit = this.cbUser1;
            this.gridColumn3.FieldName = "CreateUser";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 19;
            this.gridColumn3.Width = 100;
            // 
            // cbUser1
            // 
            this.cbUser1.AutoHeight = false;
            this.cbUser1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUser1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.cbUser1.DisplayMember = "Name";
            this.cbUser1.KeyMember = "Id";
            this.cbUser1.Name = "cbUser1";
            this.cbUser1.NullText = "";
            this.cbUser1.ShowFooter = false;
            this.cbUser1.ShowHeader = false;
            this.cbUser1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbUser1.ValueMember = "Id";
            // 
            // bandedGridColumn56
            // 
            this.bandedGridColumn56.Caption = "Пользователь (изменил)";
            this.bandedGridColumn56.ColumnEdit = this.cbUser2;
            this.bandedGridColumn56.FieldName = "UpdateUser";
            this.bandedGridColumn56.Name = "bandedGridColumn56";
            this.bandedGridColumn56.Visible = true;
            this.bandedGridColumn56.VisibleIndex = 20;
            this.bandedGridColumn56.Width = 100;
            // 
            // cbUser2
            // 
            this.cbUser2.AutoHeight = false;
            this.cbUser2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUser2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.cbUser2.DisplayMember = "Name";
            this.cbUser2.KeyMember = "Id";
            this.cbUser2.Name = "cbUser2";
            this.cbUser2.NullText = "";
            this.cbUser2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbUser2.ValueMember = "Id";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Статус";
            this.gridColumn1.FieldName = "Status";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 17;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Версия";
            this.gridColumn2.FieldName = "Version";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 18;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Рег№";
            this.gridColumn4.FieldName = "Id";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 100;
            // 
            // FrmDistributorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 580);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmDistributorList";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Список дистрибьюторов";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDistrict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUser1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUser2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem btnDel;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnFind;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbUser1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbUser2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn49;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn50;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn51;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn52;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn53;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn55;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn56;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbRegion;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbDistrict;
    }
}