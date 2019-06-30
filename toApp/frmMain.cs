using Kadr.FindExNet;
using Kadr.Kadr;
using Kadr.PluginManager;
using Kadr.Reports;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Lcc.RFileClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Kadr.Shtat;
using Kadr.Utils;
using Kadr.Database.Views;
using Kadr.UtilsUI;
using Apteka.Utils;
using Kadr.GlobalVars;

namespace App
{
    public partial class frmMain : XtraForm
    {
        private FrmFind frmFind;
        private FrmRdmReport FrmRdReports;
        private frmRFSMain FrmRFSMain;
        private frmKadrList FrmKadrList;
        private frmShtatList FrmShtat;

        public frmMain()
        {
            InitializeComponent();

            this.Text = "Версия: " + Vars.Version + "  -  " + Text;
            InitSkinGallery();

            try
            {
                UserLookAndFeel.Default.SetSkinStyle(Vars.Skin);

                if (SplashScreenManager.Default == null)
                    SplashScreenManager.ShowForm(typeof(SplashScreen1));

                //SplashScreenManager.Default.SendCommand(SplashScreenCommand.sscSetup, null);

                #region GlobalVars Init
                Vars.CurMainForm = this;
                Vars.CurMainRibbon = ribbonControl;
                #endregion


                //SplashScreenManager.Default.SendCommand(SplashScreenCommand.sscSp, null);
                DicoDB.InitSpTablesValueAsync();


                //GlobalVars.UserInfo = GlobalVars.DivisionId + " " + GlobalVars.KeyDivisionStr + "    фойдаланувчи - " +
                //                      GlobalVars.UserName;
                //txtStatusbar.Caption = GlobalVars.UserInfo;


                CLang.Init(this);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.GetAllMessages(), "Хато", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitRdmReportList()
        {
            //var val = new string[53];
            //val[0] = "1";

            //var dt = ClassOnlineWorks.GetProcedureDataTable(val, "TEXP.FORM_WORKS.GetReportList", false);
            //if (dt.Rows.Count > 0)
            //{
            //    foreach (DataRow rw in dt.Rows)
            //    {
            //        var btn = new BarButtonItem();
            //        btn.Caption = rw["TB_NAME0"].ToStr();
            //        btn.Hint = rw["HINT"].ToStr();
            //        btn.LargeImageIndex = 34;
            //        btn.Tag = rw["SPNAME"].ToStr() + "@" + rw["ARGUMENTS"].ToStr() + "@" + rw["HINT"].ToStr();
            //        btn.ItemClick += OnRdmReportClick;
            //        rpPluginReports.ItemLinks.Add(btn);
            //    }
            //}
        }

        private void OnRdmReportClick(object sender, ItemClickEventArgs e)
        {
            var prs = e.Item.Tag.ToStr();

            FrmRdReports = new FrmRdmReport(prs) { Icon = Icon, MdiParent = this };
            FrmRdReports.OnCloseChildForm += se =>
            {
                FrmRdReports.Dispose();
                FrmRdReports = null;
            };

            FrmRdReports.Show();

            if (FrmRdReports.Ribbon.PageCategories[0].Pages.Count > 0)
                ribbonControl.SelectedPage = FrmRdReports.Ribbon.PageCategories[0].Pages[0];
        }



        private void btnBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            // CBackupAll.Run("");
        }

        private void btnTexPasport_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (!GlobalVars.CheckAccsess(e.Item.Tag.ToStr()))
            //{
            //    MessageBox.Show("Сизга берилган ваколат кам...", "Хато", MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (FrmKadrList != null)
            {
                FrmKadrList.Activate();
                return;
            }

            FrmKadrList = new frmKadrList { Icon = Icon, MdiParent = this };
            FrmKadrList.OnCloseChildForm += se =>
            {
                FrmKadrList.Dispose();
                FrmKadrList = null;
            };

            FrmKadrList.gridViewStyle = Vars.GrivView;
            FrmKadrList.Show();

            if (FrmKadrList.Ribbon.PageCategories[0].Pages.Count > 0)
                ribbonControl.SelectedPage = FrmKadrList.Ribbon.PageCategories[0].Pages[0];
        }



        private void btnReportTemplate_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (!GlobalVars.CheckAccsess(e.Item.Tag.ToStr()))
            //{
            //    MessageBox.Show("Сизга берилган ваколат кам...", "Хато", MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);
            //    return;
            //}

            //var FrmTemplateCreate = new FrmTemplateCreate { Icon = Icon };
            //FrmTemplateCreate.ShowDialog();
            //FrmTemplateCreate.Dispose();
        }

      
        private void btnPing_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmPing())
            {
                f.ShowDialog();
            }
        }

        private void btnAdFind_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Vars.CheckAccsess(e.Item.Tag.ToStr()))
            {
                MessageBox.Show("Сизга берилган ваколат кам...", "Хато", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (frmFind != null) return;

            frmFind = new FrmFind { Icon = Icon, MdiParent = this };
            frmFind.OnCloseChildForm += se =>
            {
                frmFind.Dispose();
                frmFind = null;
            };

            frmFind.Show();

            if (frmFind.Ribbon.PageCategories[0].Pages.Count > 0)
                ribbonControl.SelectedPage = frmFind.Ribbon.PageCategories[0].Pages[0];
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (SplashScreenManager.Default != null)
            {
                SplashScreenManager.CloseForm();
            }

            if (Vars.IsOnline)
            {
                var trr = new Thread(InitRdmReportList);
                trr.Start();
            }


            var t = new Thread(LoadPlugins);
            t.Start();
        }

        private void btnText_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRdReports = new FrmRdmReport("") { Icon = Icon, MdiParent = this };
            FrmRdReports.OnCloseChildForm += se =>
            {
                FrmRdReports.Dispose();
                FrmRdReports = null;
            };

            FrmRdReports.Show();

            if (FrmRdReports.Ribbon.PageCategories[0].Pages.Count > 0)
                ribbonControl.SelectedPage = FrmRdReports.Ribbon.PageCategories[0].Pages[0];
        }

        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            //using (FrmAboutBox box = new FrmAboutBox())
            //{
            //    box.ShowDialog(this);
            //}
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //using (var box = new FrmAboutBox())
            //{
            //    box.ShowDialog(this);
            //}
        }


        #region SplashScreen

        private bool m_bLayoutCalled;

        private void frmMain_Layout(object sender, LayoutEventArgs e)
        {
            if (m_bLayoutCalled == false)
            {
                m_bLayoutCalled = true;
                Activate();
            }
        }

        #endregion

        #region   Plugin Skin init load

        [ImportMany("Reports", typeof(IPlugin))]
        internal IEnumerable<IPlugin> myPlugins { get; set; }


        private void LoadPlugins()
        {
            try
            {
                var catalog = new DirectoryCatalog(@".\", "Kadr.plg.*.dll");
                var container = new CompositionContainer(catalog);
                var batch = new CompositionBatch();
                batch.AddPart(this);
                container.Compose(batch);


                foreach (var pl in myPlugins)
                {
                    var btn = pl.Initialize(this, "") as BarButtonItem;
                    btn.LargeImageIndex = 20;
                    rpPluginReports.ItemLinks.Add(btn);
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var sb = new StringBuilder();
                foreach (var exSub in ex.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    var exFileNotFound = exSub as FileNotFoundException;
                    if (exFileNotFound != null)
                    {
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                var errorMessage = sb.ToString();

                CLog.Write(errorMessage);
            }
        }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        private void rgbiSkins_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            Vars.Skin = e.Item.Tag.ToStr();
            Vars.SaveSkin();
        }

        #endregion

        #region Ribbon Control

        private void ribbonControl_Merge(object sender, RibbonMergeEventArgs e)
        {
            var parentRRibbon = sender as RibbonControl;
            var childRibbon = e.MergedChild;
            parentRRibbon.StatusBar.MergeStatusBar(childRibbon.StatusBar);
        }

        private void ribbonControl_UnMerge(object sender, RibbonMergeEventArgs e)
        {
            var parentRRibbon = sender as RibbonControl;
            parentRRibbon.StatusBar.UnMergeStatusBar();
        }

        private void ribbonControl_SelectedPageChanging(object sender, RibbonPageChangingEventArgs e)
        {
            // splitContainerControl.Visible = e.Page.Category.Name == "ribbonPageCategoryCMdi" ? false : true;
        }

        #endregion

        #region Setup



        private void btnSetup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Vars.CheckAccsess(e.Item.Tag.ToStr()))
            {
                MessageBox.Show("Сизга берилган ваколат кам...", "Хато", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var frm = new frmSetup();
            frm.Icon = Icon;
            frm.ShowDialog();
            frm.Dispose();
        }

        #endregion

        private void btnSendFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FrmRFSMain != null)
            {
                FrmRFSMain.Activate();
                return;
            }

            FrmRFSMain = new frmRFSMain { Icon = Icon, MdiParent = this };
            FrmRFSMain.Show();
            FrmRFSMain.OnCloseChildForm += se =>
            {
                FrmRFSMain.Dispose();
                FrmRFSMain = null;
            };

            if (FrmRFSMain.Ribbon.PageCategories[0].Pages.Count > 0)
                ribbonControl.SelectedPage = FrmRFSMain.Ribbon.PageCategories[0].Pages[0];
        }

        private void btnSpTables_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmTable f = new FrmTable())
            {
                f.ShowDialog();
            }
        }



        private void btnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmExport f = new FrmExport())
            {
                f.ShowDialog();
            }
        }

        private void btnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmImport f = new FrmImport())
            {
                f.ShowDialog();
            }
        }

        private void btnShtat_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (FrmShtat != null)
            {
                FrmShtat.Activate();
                return;
            }

            FrmShtat = new frmShtatList { Icon = Icon, MdiParent = this };
            FrmShtat.FormClosed += (s, ey) =>
            {
                FrmShtat.Dispose();
                FrmShtat = null;
            };

            FrmShtat.Show();

            if (FrmShtat.Ribbon.PageCategories[0].Pages.Count > 0)
                ribbonControl.SelectedPage = FrmShtat.Ribbon.PageCategories[0].Pages[0];
        }


    }
}