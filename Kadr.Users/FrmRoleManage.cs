using Kadr.Models;
using Kadr.Models.Core;
using Kadr.Utils;
using Kadr.UtilsUI.GridFunctions;
using System.Linq;

namespace Kadr.Users
{
    public partial class FrmRoleManage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private IUnitOfWork db;
        private ReportGridForms ReportConfig;

        public FrmRoleManage()
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

            cbUser.DataSource = db.User.GetSp();
            gridControl1.DataSource = db.Role.GetAll().ToList();

            CLang.Init(this);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fu = new FrmUserAccess();
            if (fu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sel = gridView1.GetFocusedRow() as spRole;
            if (sel != null)
            {
                var fu = new FrmUserAccess(sel);
                if (fu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }
        
        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sel = gridView1.GetFocusedRow() as spRole;
            if (sel != null)
            {
                db.Role.Remove(sel);
                db.Complete();
            }
        }

        private void RefreshGrid()
        {
            gridControl1.BeginUpdate();
            gridControl1.DataSource = null;
            gridControl1.DataSource = db.Role.GetAll().ToList();
            gridControl1.EndUpdate();
        }

        private void gridView1_DoubleClick(object sender, System.EventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sel = gridView1.GetFocusedRow() as spRole;
            if (sel != null)
            {
                var u = db.Role.Get(sel.Id);
                if (u.Status == 0)
                    u.Status = 1;
                else
                    u.Status = 0;
                db.Complete();
                RefreshGrid();
            }
        }
    }
}