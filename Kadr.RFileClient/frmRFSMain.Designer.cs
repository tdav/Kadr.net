namespace Lcc.RFileClient
{
    partial class frmRFSMain
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
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "111"}, 1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Tahoma", 8.25F));
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "22"}, 2, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Tahoma", 8.25F));
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "33"}, 2, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Tahoma", 8.25F));
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "uuu"}, 2, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Tahoma", 8.25F));
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "iii"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Tahoma", 8.25F));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRFSMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvLocal = new System.Windows.Forms.ListView();
            this.chFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chExt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilLage = new System.Windows.Forms.ImageList(this.components);
            this.lvRemote = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilSmall = new System.Windows.Forms.ImageList(this.components);
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSend = new DevExpress.XtraBars.BarButtonItem();
            this.btnDel = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.stRemoteState = new DevExpress.XtraBars.BarStaticItem();
            this.ProgresBar = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.stCurFilename = new DevExpress.XtraBars.BarStaticItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnRename = new DevExpress.XtraBars.BarButtonItem();
            this.btnTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnList = new DevExpress.XtraBars.BarButtonItem();
            this.btnIcon = new DevExpress.XtraBars.BarButtonItem();
            this.btnDownload = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategoryCMdi = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPageMdi = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.butStopTotalCommander = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.btnTest = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 143);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvLocal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvRemote);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 412);
            this.splitContainer1.SplitterDistance = 570;
            this.splitContainer1.TabIndex = 4;
            // 
            // lvLocal
            // 
            this.lvLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFilename,
            this.chSize,
            this.chExt,
            this.chDate});
            this.lvLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLocal.GridLines = true;
            listViewItem8.Checked = true;
            listViewItem8.StateImageIndex = 1;
            this.lvLocal.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.lvLocal.LargeImageList = this.ilLage;
            this.lvLocal.Location = new System.Drawing.Point(0, 0);
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.Size = new System.Drawing.Size(570, 412);
            this.lvLocal.TabIndex = 1;
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            this.lvLocal.View = System.Windows.Forms.View.Tile;
            this.lvLocal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvLocal_MouseDoubleClick);
            // 
            // chFilename
            // 
            this.chFilename.Text = "Name";
            this.chFilename.Width = 180;
            // 
            // chSize
            // 
            this.chSize.Text = "Size";
            this.chSize.Width = 96;
            // 
            // chExt
            // 
            this.chExt.Text = "Type";
            this.chExt.Width = 75;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 103;
            // 
            // ilLage
            // 
            this.ilLage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilLage.ImageStream")));
            this.ilLage.TransparentColor = System.Drawing.Color.Transparent;
            this.ilLage.Images.SetKeyName(0, "Folder.png");
            this.ilLage.Images.SetKeyName(1, "up.png");
            this.ilLage.Images.SetKeyName(2, "Document.ico");
            this.ilLage.Images.SetKeyName(3, "Drive Main.png");
            this.ilLage.Images.SetKeyName(4, "CD.png");
            this.ilLage.Images.SetKeyName(5, "Drive USB.png");
            // 
            // lvRemote
            // 
            this.lvRemote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRemote.FullRowSelect = true;
            this.lvRemote.GridLines = true;
            this.lvRemote.LargeImageList = this.ilLage;
            this.lvRemote.Location = new System.Drawing.Point(0, 0);
            this.lvRemote.Name = "lvRemote";
            this.lvRemote.Size = new System.Drawing.Size(594, 412);
            this.lvRemote.SmallImageList = this.ilSmall;
            this.lvRemote.TabIndex = 2;
            this.lvRemote.UseCompatibleStateImageBehavior = false;
            this.lvRemote.VirtualListSize = 2;
            this.lvRemote.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvRemote_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date";
            this.columnHeader4.Width = 103;
            // 
            // ilSmall
            // 
            this.ilSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSmall.ImageStream")));
            this.ilSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.ilSmall.Images.SetKeyName(0, "Folder.png");
            this.ilSmall.Images.SetKeyName(1, "up.png");
            this.ilSmall.Images.SetKeyName(2, "Document.ico");
            this.ilSmall.Images.SetKeyName(3, "Drive Main.png");
            this.ilSmall.Images.SetKeyName(4, "CD.png");
            this.ilSmall.Images.SetKeyName(5, "Drive USB.png");
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnSend,
            this.btnDel,
            this.btnRefresh,
            this.stRemoteState,
            this.ProgresBar,
            this.stCurFilename,
            this.btnClose,
            this.btnRename,
            this.btnTable,
            this.btnList,
            this.btnIcon,
            this.btnDownload,
            this.btnTest});
            this.ribbon.LargeImages = this.ilLage;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 21;
            this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategoryCMdi});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(1168, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnSend
            // 
            this.btnSend.Caption = "Файл юбориш";
            this.btnSend.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSend.Glyph")));
            this.btnSend.Id = 1;
            this.btnSend.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSend.LargeGlyph")));
            this.btnSend.LargeImageIndex = 1;
            this.btnSend.Name = "btnSend";
            this.btnSend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopyFile_ItemClick);
            // 
            // btnDel
            // 
            this.btnDel.Caption = "Ўчириш";
            this.btnDel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDel.Glyph")));
            this.btnDel.Id = 2;
            this.btnDel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDel.LargeGlyph")));
            this.btnDel.LargeImageIndex = 12;
            this.btnDel.Name = "btnDel";
            this.btnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDel_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Рўйхатни янгилаш";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 3;
            this.btnRefresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.LargeGlyph")));
            this.btnRefresh.LargeImageIndex = 19;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // stRemoteState
            // 
            this.stRemoteState.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.stRemoteState.Id = 7;
            this.stRemoteState.Name = "stRemoteState";
            this.stRemoteState.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ProgresBar
            // 
            this.ProgresBar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.ProgresBar.Edit = this.repositoryItemProgressBar1;
            this.ProgresBar.EditWidth = 200;
            this.ProgresBar.Id = 8;
            this.ProgresBar.Name = "ProgresBar";
            this.ProgresBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.Step = 0;
            // 
            // stCurFilename
            // 
            this.stCurFilename.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.stCurFilename.Id = 9;
            this.stCurFilename.Name = "stCurFilename";
            this.stCurFilename.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Чиқиш";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 10;
            this.btnClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClose.LargeGlyph")));
            this.btnClose.LargeImageIndex = 17;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnRename
            // 
            this.btnRename.Caption = "Номини ўзгартириш";
            this.btnRename.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRename.Glyph")));
            this.btnRename.Id = 15;
            this.btnRename.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRename.LargeGlyph")));
            this.btnRename.LargeImageIndex = 18;
            this.btnRename.Name = "btnRename";
            this.btnRename.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRename_ItemClick);
            // 
            // btnTable
            // 
            this.btnTable.Caption = "Таблица";
            this.btnTable.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTable.Glyph")));
            this.btnTable.Id = 16;
            this.btnTable.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTable.LargeGlyph")));
            this.btnTable.Name = "btnTable";
            this.btnTable.Tag = 1;
            this.btnTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnviStyle);
            // 
            // btnList
            // 
            this.btnList.Caption = "Рўйхат";
            this.btnList.Glyph = ((System.Drawing.Image)(resources.GetObject("btnList.Glyph")));
            this.btnList.Id = 17;
            this.btnList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnList.LargeGlyph")));
            this.btnList.Name = "btnList";
            this.btnList.Tag = 2;
            this.btnList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnviStyle);
            // 
            // btnIcon
            // 
            this.btnIcon.Caption = "Оддий";
            this.btnIcon.Glyph = ((System.Drawing.Image)(resources.GetObject("btnIcon.Glyph")));
            this.btnIcon.Id = 18;
            this.btnIcon.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnIcon.LargeGlyph")));
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Tag = 3;
            this.btnIcon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnviStyle);
            // 
            // btnDownload
            // 
            this.btnDownload.Caption = "Файл қабул қилиш";
            this.btnDownload.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDownload.Glyph")));
            this.btnDownload.Id = 19;
            this.btnDownload.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDownload.LargeGlyph")));
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDownload_ItemClick);
            // 
            // ribbonPageCategoryCMdi
            // 
            this.ribbonPageCategoryCMdi.Color = System.Drawing.Color.Empty;
            this.ribbonPageCategoryCMdi.Name = "ribbonPageCategoryCMdi";
            this.ribbonPageCategoryCMdi.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageMdi});
            this.ribbonPageCategoryCMdi.Text = "Қўшимча";
            // 
            // ribbonPageMdi
            // 
            this.ribbonPageMdi.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPageMdi.Name = "ribbonPageMdi";
            this.ribbonPageMdi.Text = "Файллар билан ишлаш";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSend);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDownload);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDel, true, "", "", true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRename);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnTable);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnList);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnIcon);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Кўриниш";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnTest);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.stRemoteState);
            this.ribbonStatusBar.ItemLinks.Add(this.ProgresBar);
            this.ribbonStatusBar.ItemLinks.Add(this.stCurFilename);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 555);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1168, 31);
            // 
            // butStopTotalCommander
            // 
            this.butStopTotalCommander.Caption = "Stop";
            this.butStopTotalCommander.Id = 95;
            this.butStopTotalCommander.LargeImageIndex = 6;
            this.butStopTotalCommander.Name = "butStopTotalCommander";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Stop";
            this.barButtonItem7.Id = 95;
            this.barButtonItem7.LargeImageIndex = 6;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // btnTest
            // 
            this.btnTest.Caption = "Test";
            this.btnTest.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTest.Glyph")));
            this.btnTest.Id = 20;
            this.btnTest.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTest.LargeGlyph")));
            this.btnTest.Name = "btnTest";
            this.btnTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTest_ItemClick);
            // 
            // frmRFSMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 586);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRFSMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Файллар билан ишлаш";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageMdi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnSend;
        private DevExpress.XtraBars.BarButtonItem btnDel;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private System.Windows.Forms.ImageList ilLage;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chExt;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ColumnHeader chFilename;
        private System.Windows.Forms.ListView lvLocal;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvRemote;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private DevExpress.XtraBars.BarStaticItem stRemoteState;
        private DevExpress.XtraBars.BarEditItem ProgresBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarStaticItem stCurFilename;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem butStopTotalCommander;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategoryCMdi;
        private DevExpress.XtraBars.BarButtonItem btnRename;
        private DevExpress.XtraBars.BarButtonItem btnTable;
        private DevExpress.XtraBars.BarButtonItem btnList;
        private DevExpress.XtraBars.BarButtonItem btnIcon;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnDownload;
        private System.Windows.Forms.ImageList ilSmall;
        private DevExpress.XtraBars.BarButtonItem btnTest;
    }
}