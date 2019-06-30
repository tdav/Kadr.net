namespace Apteka.Others
{
    partial class FrmCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerList));
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
            this.bandedGridColumn51 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.ribbon.Size = new System.Drawing.Size(1051, 143);
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
            this.ribbonPage1.Text = "Cписок клиентов";
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
            this.ribbonStatusBar.Size = new System.Drawing.Size(1051, 31);
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
            this.cbUser2});
            this.gridControl.Size = new System.Drawing.Size(1051, 406);
            this.gridControl.TabIndex = 12;
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl.DoubleClick += new System.EventHandler(this.gridControl_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.bandedGridColumn49,
            this.bandedGridColumn50,
            this.bandedGridColumn51,
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
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn49
            // 
            this.bandedGridColumn49.Caption = "Фамилии Имя Отчество";
            this.bandedGridColumn49.FieldName = "FIO";
            this.bandedGridColumn49.Name = "bandedGridColumn49";
            this.bandedGridColumn49.Visible = true;
            this.bandedGridColumn49.VisibleIndex = 0;
            this.bandedGridColumn49.Width = 112;
            // 
            // bandedGridColumn50
            // 
            this.bandedGridColumn50.Caption = "Адрес";
            this.bandedGridColumn50.FieldName = "Address";
            this.bandedGridColumn50.Name = "bandedGridColumn50";
            this.bandedGridColumn50.Visible = true;
            this.bandedGridColumn50.VisibleIndex = 1;
            this.bandedGridColumn50.Width = 134;
            // 
            // bandedGridColumn51
            // 
            this.bandedGridColumn51.Caption = "Телефон";
            this.bandedGridColumn51.FieldName = "Phone";
            this.bandedGridColumn51.Name = "bandedGridColumn51";
            this.bandedGridColumn51.Visible = true;
            this.bandedGridColumn51.VisibleIndex = 2;
            this.bandedGridColumn51.Width = 138;
            // 
            // bandedGridColumn52
            // 
            this.bandedGridColumn52.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumn52.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumn52.Caption = "Дата создания";
            this.bandedGridColumn52.FieldName = "CreateDate";
            this.bandedGridColumn52.Name = "bandedGridColumn52";
            this.bandedGridColumn52.Visible = true;
            this.bandedGridColumn52.VisibleIndex = 3;
            this.bandedGridColumn52.Width = 92;
            // 
            // bandedGridColumn53
            // 
            this.bandedGridColumn53.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumn53.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumn53.Caption = "Дата изменения";
            this.bandedGridColumn53.FieldName = "UpdateDate";
            this.bandedGridColumn53.Name = "bandedGridColumn53";
            this.bandedGridColumn53.Visible = true;
            this.bandedGridColumn53.VisibleIndex = 4;
            this.bandedGridColumn53.Width = 118;
            // 
            // bandedGridColumn55
            // 
            this.bandedGridColumn55.Caption = "Отправлено";
            this.bandedGridColumn55.FieldName = "Send";
            this.bandedGridColumn55.Name = "bandedGridColumn55";
            this.bandedGridColumn55.Visible = true;
            this.bandedGridColumn55.VisibleIndex = 7;
            this.bandedGridColumn55.Width = 82;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Пользователь (создаль)";
            this.gridColumn3.ColumnEdit = this.cbUser1;
            this.gridColumn3.FieldName = "CreateUser";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
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
            this.bandedGridColumn56.VisibleIndex = 6;
            this.bandedGridColumn56.Width = 105;
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
            this.gridColumn1.VisibleIndex = 9;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Версия";
            this.gridColumn2.FieldName = "Version";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 8;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Рег№";
            this.gridColumn4.FieldName = "Id";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // FrmCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 580);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmCustomerList";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Cписок клиентов";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn49;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn50;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn51;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn52;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn53;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn55;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn56;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraBars.BarButtonItem btnFind;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbUser1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbUser2;
    }
}