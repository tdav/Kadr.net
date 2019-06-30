using System;
using Apteka.Models.Core;
using Apteka.Models.Entity;
using Apteka.Others;
using Apteka.Utils;

namespace Apteka.Others
{
    public partial class FrmComingProducts : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork db;

        public FrmComingProducts()
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            cbDistributors.Properties.DataSource = db.Distributor.GetSp();
            cbDrugStore.Properties.DataSource = db.DrugStore.GetSp();
            cbDrugStore.EditValue = Vars.DrugStoreId;
            edDate.EditValue = DateTime.Now;

            CLang.Init(this);
        }

        public tbComingProducts GetData()
        {
            var res = new tbComingProducts();

            res.Id = Guid.NewGuid();
            res.CreateDate = DateTime.Now;
            res.CreateUser = Vars.UserId;
            res.DistributorId = cbDistributors.EditValue.ToGuid();
            res.DrugStoreId = cbDrugStore.EditValue.ToGuid();
            res.DocumentNo = edDocumentNo.Text;
            res.Status = 0;

            return res;
        }


        private void OnBtnSpListAdd(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Index == 1)
                {
                    int i = e.Button.Tag.ToInt();
                    switch (i)
                    {
                        case 1:
                            var f = new FrmNewDistributor();
                            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                cbDistributors.Properties.DataSource = db.Distributor.GetSp();
                            f.Dispose();
                            break;

                        case 2:
                            var fd = new FrmDrugStore();
                            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                cbDrugStore.Properties.DataSource = db.DrugStore.GetSp();
                            fd.Dispose();
                            break;
                    }
                }
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Others",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "FrmProductList.OnBtnSpListAdd"
                };
                CLogJson.Write(li);
                UtilsUI.AlertMessage.ShowError("Ошибка при сохранении".ToLang(this.Name));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}