using Kadr.GlobalVars;
using Kadr.Models;
using Kadr.Models.Core;
using Kadr.Utils;
using Kadr.UtilsUI;
using Kadr.UtilsUI.GridFunctions;
using System.Linq;

namespace Kadr.Users
{
    public partial class FrmUserManage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private IUnitOfWork db;
        private ReportGridForms ReportConfig;

        public FrmUserManage()
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) =>
            {
                ReportConfig?.Save(gridView1);
                db.Dispose();
            };
            ReportConfig = new ReportGridForms();
            ReportConfig.Load(gridView1, $"{this.Name}@{gridView1.Name}");

            cbRole.DataSource = db.Role.GetSp();
            cbUser.DataSource = db.User.GetSp();
            gridControl1.DataSource = db.User.GetAll().ToList();

            CLang.Init(this);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fu = new FrmUser();
            if (fu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sel = gridView1.GetFocusedRow() as tbUser;
            if (sel != null)
            {
                var fu = new FrmUser(sel);
                if (fu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void RefreshGrid()
        {
            gridControl1.BeginUpdate();
            gridControl1.DataSource = null;
            gridControl1.DataSource = db.User.GetAll().ToList();
            gridControl1.EndUpdate();
        }

        private void gridView1_DoubleClick(object sender, System.EventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sel = gridView1.GetFocusedRow() as tbUser;
            if (sel != null)
            {
                var u = db.User.Get(sel.Id);
                if (u.Status == 0)
                    u.Status = 1;
                else
                    u.Status = 0;
                db.Complete();
                RefreshGrid();
            }
        }

        private void btnUserAccess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Vars.CheckAccess(124))
            {
                MessageBoxDev.ShowError("Доступ закрыт".ToLang(this.Name));
                return;
            }

            WaitFormManager.Show();
            var frm = new FrmRoleManage();
            frm.MdiParent = Vars.CurMainForm;

            frm.Shown += (s, d) =>
            {
                WaitFormManager.Close();
            };

            frm.FormClosed += (s, d) => { };
            frm.Show();
        }
    }
}