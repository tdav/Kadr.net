using Apteka.Models.Core;
using Apteka.Models.Entity;
using Apteka.Utils;
using Apteka.UtilsUI.GridFunctions;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;
using System.Linq;

namespace Apteka.Others
{
    public partial class FrmCustomerList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private IUnitOfWork db;
        public ReportGridForms ReportConfig { get; private set; }

        public FrmCustomerList()
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) =>
            {
                ReportConfig?.Save(gridView1);
                db.Dispose();
            };

            gridControl.ForceInitialize();
            gridControl.DataSource = db.Customer.GetAll().ToList();


            var conStyle = new DevExpress.XtraGrid.StyleFormatCondition();
            conStyle.Appearance.BackColor = Color.Linen;
            conStyle.Appearance.Options.UseBackColor = true;
            conStyle.Condition = FormatConditionEnum.Expression;
            conStyle.Expression = "[Status] == 0";
            conStyle.Enabled = true;
            conStyle.ApplyToRow = true;
            gridView1.FormatConditions.Add(conStyle);

            cbUser1.DataSource = db.User.GetSp();
            cbUser2.DataSource = db.User.GetSp();

            ReportConfig = new ReportGridForms();
            ReportConfig.Load(gridView1, $"{this.Name}@{gridView1.Name}");

            CLang.Init(this);
        }

        private void btnCloseItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void ShowForm(bool IsNew)
        {
            FrmNewCustomer f;
            int index = -1;
            if (IsNew)
            {
                f = new FrmNewCustomer();
            }
            else
            {
                index = gridView1.FocusedRowHandle;
                var row = gridView1.GetFocusedRow() as tbCustomer;
                f = new FrmNewCustomer(row);
            }

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                db.Dispose();
                db = new UnitOfWork();

                gridControl.DataSource = null;
                gridControl.DataSource = db.Customer.GetAll().ToList();
                gridView1.FocusedRowHandle = index;
            }
            f.Dispose();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(true);
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(false);
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilsUI.WaitFormManager.Show();
            var row = gridView1.GetFocusedRow() as tbCustomer;
            var it = db.Customer.Get(row.Id);
            it.Status = it.Status == 1 ? 0 : 1;
            it.Send = 0;
            it.Version = it.Version + 1;
            db.Complete();
            gridControl.DataSource = db.Customer.GetAll().ToList();
            UtilsUI.WaitFormManager.Close();
        }

        private void gridControl_DoubleClick(object sender, System.EventArgs e)
        {
            btnEdit.PerformClick();
        }
    }
}