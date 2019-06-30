using Apteka.Models.Core;
using Apteka.Models.Entity;
using Apteka.Utils;
using Apteka.UtilsUI.GridFunctions;
using DevExpress.XtraGrid;
using System.Drawing;

namespace Apteka.Others
{
    public partial class FrmProductList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private IUnitOfWork db;
        public ReportGridForms ReportConfig { get; private set; }

        public FrmProductList()
        {
            InitializeComponent();

            db = new UnitOfWork();

            gridControl.ForceInitialize();
            gridControl.DataSource = db.Drugs.GetViDrugListForGrid();
            var conStyle = new DevExpress.XtraGrid.StyleFormatCondition();
            conStyle.Appearance.BackColor = Color.Linen;
            conStyle.Appearance.Options.UseBackColor = true;
            conStyle.Condition = FormatConditionEnum.Expression;
            conStyle.Expression = "[Status] == 0";
            conStyle.Enabled = true;
            conStyle.ApplyToRow = true;
            gridView1.FormatConditions.Add(conStyle);


            FormClosed += (s, e) =>
            {
                ReportConfig?.Save(gridView1);
                db.Dispose();
            };

            ReportConfig = new ReportGridForms();
            ReportConfig.Load(gridView1, $"{this.Name}@{gridView1.Name}");

            CLang.Init(this);
        }

        private void btnCloseItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void ShowForm(string id)
        {
            spDrug drug = null;
            if (!string.IsNullOrWhiteSpace(id))
                drug = db.Drugs.GetById(id.ToString());

            var index = gridView1.FocusedRowHandle;

            var f = new FrmNewDrug(drug);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gridControl.DataSource = null;
                gridControl.DataSource = db.Drugs.GetViDrugListForGrid();
                gridView1.FocusedRowHandle = index;
            }
            f.Dispose();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(null);
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as viDrugListForGrid;

            ShowForm(row.Id.ToString());
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilsUI.WaitFormManager.Show();
            var row = gridView1.GetFocusedRow() as viDrugListForGrid;
            var it = db.Drugs.Get(row.Id);
            it.Send = 0;
            it.Version = it.Version + 1;
            it.Status = it.Status == 1 ? 0 : 1;
            db.Complete();
            gridControl.DataSource = db.Drugs.GetViDrugListForGrid();
            UtilsUI.WaitFormManager.Close();
        }

        private void gridControl_DoubleClick(object sender, System.EventArgs e)
        {
            btnEdit.PerformClick();
        }
    }
}