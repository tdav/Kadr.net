using System;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraBars;

using Lcc.RFileClient.srvFileClient;
using Apteka.Utils;

namespace Lcc.RFileClient
{
    public partial class frmRFSMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public delegate void DelegateOnCloseChildForm(object sender);
        public event DelegateOnCloseChildForm OnCloseChildForm;

        public frmRFSMain()
        {
            InitializeComponent();
        }


        string CurDirLocal;
        string CurDirRemote;
        private bool IsRootPath = false;

        public int progres = 0;
        private Lcc.RFileClient.srvFileClient.FileTransferServiceClient rfs;

        void OnRfsGetDriveInfoCompleted(object sender, GetDriveInfoCompletedEventArgs e)
        {
            lvRemote.Clear();
            if (e.Error == null)
            {
                CurDirRemote = "root";
                
                var di = e.Result;
                SetRFSDriveInfo(lvRemote, di);
            }
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (OnCloseChildForm != null)
                OnCloseChildForm(this);
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                InitLocal();
                InitRFS();
                rfs.GetDriveInfoAsync();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void InitLocal()
        {
            DriveInfo[] di = DriveInfo.GetDrives();
            SetDriveInfo(lvLocal, di);
        }

        private void InitRFS()
        {
            InitClient();
            rfs.ListCompleted += OnListCompleted;
            rfs.GetDriveInfoCompleted += OnRfsGetDriveInfoCompleted;
        }

        private void InitClient()
        {
            if (rfs != null) rfs.Close();

            rfs = new FileTransferServiceClient();
        }

        private void AddItemLv(ListView lv, string test, int iconIndex, string tag)
        {
            ListViewItem li = lv.Items.Add(test);
            li.ImageIndex = iconIndex;
            li.Tag = tag;
        }

        private void SetDriveInfo(ListView lv, DriveInfo[] di)
        {
            lv.Clear();
            foreach (var i in di)
            {
                string dv = i.Name;

                switch (i.DriveType)
                {
                    case DriveType.CDRom:
                        AddItemLv(lv, dv, 4, i.Name);
                        break;
                    case DriveType.Fixed:
                        AddItemLv(lv, dv, 3, i.Name);
                        break;
                    case DriveType.Network:
                        AddItemLv(lv, dv, 3, i.Name);
                        break;
                    case DriveType.NoRootDirectory:
                        AddItemLv(lv, dv, 3, i.Name);
                        break;
                    case DriveType.Ram:
                        AddItemLv(lv, dv, 3, i.Name);
                        break;
                    case DriveType.Removable:
                        AddItemLv(lv, dv, 5, i.Name);
                        break;
                    case DriveType.Unknown:
                        AddItemLv(lv, dv, 3, i.Name);
                        break;
                }
            }
        }

        private void SetRFSDriveInfo(ListView lv, Lcc.RFileClient.srvFileClient.TbDivClass[] di)
        {
            lv.Clear();
            foreach (var i in di)
            {
                AddItemLv(lv, i.SpName, 0, i.SpId.ToStr());
            }
        }

        private void lvLocal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = "";
            if (lvLocal.SelectedItems.Count > 0)
                path = lvLocal.SelectedItems[0].Tag.ToString();
            CurDirLocal = path;

            GetListLocal(path);
        }

        private void GetListLocal(string path)
        {
            if (path == "root")
            {
                DriveInfo[] di = DriveInfo.GetDrives();
                SetDriveInfo(lvLocal, di);
            }
            else
            {
                lvLocal.Clear();

                DirectoryInfo di = Directory.GetParent(path);
                if (di != null)
                    AddItemLv(lvLocal, "..", 1, di.FullName);
                else
                    AddItemLv(lvLocal, "..", 1, "root");


                DirectoryInfo dirInfo = new DirectoryInfo(path);
                try
                {
                    foreach (var i in dirInfo.GetDirectories())
                    {
                        AddItemLv(lvLocal, Path.GetFileName(i.FullName), 0, i.FullName);
                    }

                    foreach (var i in dirInfo.GetFiles())
                    {
                        AddItemLv(lvLocal, Path.GetFileName(i.FullName), 2, i.FullName);
                    }
                }
                catch (Exception )
                {
                    MessageBox.Show("diskIsNotReady");

                }

            }
        }

        private void lvRemote_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = "";
            if (lvRemote.SelectedItems.Count > 0)
                path = lvRemote.SelectedItems[0].Tag.ToString();

            GetListRemote(path);
        }

        private void GetListRemote(string path)
        {
            CurDirRemote = path;

            if (path == "root")
            {
                rfs.GetDriveInfoAsync();
            }
            else
            {
                rfs.ListAsync(path, path);
            }
        }

        void OnListCompleted(object sender, Lcc.RFileClient.srvFileClient.ListCompletedEventArgs e)
        {
            lvRemote.Clear();

            if (e.UserState != null)
            {
                string path = e.UserState.ToString();

                //if (path == "00")
                //{
                //    path = "root";
                //    IsRootPath = true;
                //}
                //else
                //{   
                //    IsRootPath = false;
                //}


                AddItemLv(lvRemote, "..", 1, "root");
            }

            if (e.Error == null)
            {
                StorageFileInfo[] list = e.Result;
                foreach (var i in list)
                {
                    if (i.IsDirectory)
                        AddItemLv(lvRemote, Path.GetFileName(i.FileName), 0, i.Size.ToString());
                    else
                        AddItemLv(lvRemote, Path.GetFileName(i.FileName), 2, i.FileName);
                }
            }
        }

        void fc_OnProgressChanged(object sender, FileClient.FClient.ProgressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                switch (e.msgType)
                {
                    case 999:
                        {
                            stCurFilename.Caption = "";
                            ProgresBar.Visibility = BarItemVisibility.Never;
                            break;
                        };
                    case -1:
                        {
                            MessageBox.Show(e.SValue);
                            break;
                        };

                    case 22:
                        {
                            GetListLocal(CurDirLocal);
                            break;
                        }
                    case 33:
                        {
                            GetListRemote(CurDirRemote);
                            break;
                        }
                }

                stRemoteState.Caption = e.SValue;
                ProgresBar.EditValue = e.PValue;
            }));
        }

        private void btnCopyFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProgresBar.Visibility = BarItemVisibility.Always;
            string s1, s2;
            FileInfo fi;
            FileClient.FClient fc;

            if (lvLocal.SelectedItems.Count == 0) return;
            if (CurDirRemote == "root")
            {
                MessageBox.Show("Вилоят попкасини очиб файл юборинг...");
                return;
            }

            s1 = lvLocal.SelectedItems[0].Tag.ToString();
            s2 = CurDirRemote;

            fi = new FileInfo(s1);
            if (fi.Length > 20000000)
            {
                MessageBox.Show("Юбориладиган файл хажми 20мб катта...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProgresBar.Visibility = BarItemVisibility.Never;
                return;
            }

            stCurFilename.Caption = fi.Name;

            fc = new FileClient.FClient();
            fc.OnProgressChanged += fc_OnProgressChanged;
            fc.SendFile(s1, s2);

        }


        private void btnDownload_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProgresBar.Visibility = BarItemVisibility.Always;
            string s1, s2;
            FileInfo fi;
            FileClient.FClient fc;

            s1 = CurDirLocal;
            s2 = lvRemote.SelectedItems[0].Tag.ToString();

            fi = new FileInfo(s2);
            stCurFilename.Caption = fi.Name;

            fc = new FileClient.FClient();
            fc.OnProgressChanged += fc_OnProgressChanged;
            fc.DonwloadFile(s1, s2);


        }

        private void btnDel_ItemClick(object sender, ItemClickEventArgs e)
        {
            string path = "";

            if (lvLocal.Focused)
            {
                if (lvLocal.SelectedItems.Count > 0)
                    path = lvLocal.SelectedItems[0].Tag.ToString();

                if (path != "root")
                {
                    if (File.Exists(path))
                        File.Delete(path);
                    else
                        Directory.Delete(path);
                }

                GetListLocal(CurDirLocal);
            }
            else
            {
                FileClient.FClient fc = new FileClient.FClient();
                fc.OnProgressChanged += fc_OnProgressChanged;
                if (lvRemote.SelectedItems.Count == 0) return;
                path = lvRemote.SelectedItems[0].Tag.ToString();
                fc.DelFile(path);
                GetListRemote(CurDirRemote);
            }
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (lvLocal.Focused)
            {
                GetListLocal(CurDirLocal);
            }
            else
            {
                GetListRemote(CurDirRemote);
            }
        }

        private void btnRename_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (lvRemote.SelectedItems.Count == 0) return;

            string path = "";
            string NewName = lvRemote.SelectedItems[0].Text;
            string s1 = "Rename_file";
            string s2 = "New_filename";
            if (CControls.InputBox(s1, s2, ref NewName) == System.Windows.Forms.DialogResult.OK)
            {
                if (lvLocal.Focused)
                {
                    if (lvLocal.SelectedItems.Count > 0)
                        path = lvLocal.SelectedItems[0].Tag.ToString();

                    if (path != "root")
                    {
                        if (File.Exists(path))
                            File.Move(path, NewName);
                        else
                            Directory.Move(path, NewName);
                    }
                    GetListLocal(CurDirLocal);
                }
                else
                {
                    FileClient.FClient fc = new FileClient.FClient();
                    fc.OnProgressChanged += fc_OnProgressChanged;
                    if (lvRemote.SelectedItems.Count == 0) return;
                    path = lvRemote.SelectedItems[0].Tag.ToString();
                    fc.ReNameFile(path, NewName);
                    GetListRemote(CurDirRemote);
                }
            }
        }

        private void OnviStyle(object sender, ItemClickEventArgs e)
        {
            if (lvLocal.Focused == true)
            {
                switch (e.Item.Tag.ToInt())
                {
                    case 1:
                        lvLocal.View = View.LargeIcon;
                        return;
                    case 2:
                        lvLocal.View = View.List;
                        return;
                    case 3:
                        lvLocal.View = View.Tile;
                        return;
                }
            }
            else
            {
                switch (e.Item.Tag.ToInt())
                {
                    case 1:
                        lvRemote.View = View.LargeIcon;
                        return;
                    case 2:
                        lvRemote.View = View.List;
                        return;
                    case 3:
                        lvRemote.View = View.Tile;
                        return;
                }
            }
        }

        private void btnTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            rfs.ListAsync("NewData", "");
        }
    }
}