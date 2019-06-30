using Apteka.Models.Core;
using Apteka.Models.Entity;
using Apteka.Utils;
using System;

namespace Apteka.Others
{
    public partial class FrmNewDistributor : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork db;
        private spDistributor Distributor;

        public FrmNewDistributor()
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            cbRegion.Properties.DataSource = db.Region.GetSp();
            cbRegion.EditValueChanged += (s, e) =>
            {
                if (cbRegion.EditValue?.ToString() != "")
                    cbRayon.Properties.DataSource = db.District.GetSp(cbRegion.EditValue.ToStr());
            };

            CLang.Init(this);
        }

        public FrmNewDistributor(spDistributor value)
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            cbRegion.Properties.DataSource = db.Region.GetSp();
            cbRegion.EditValueChanged += (s, e) =>
            {
                if (cbRegion.EditValue?.ToString() != "")
                    cbRayon.Properties.DataSource = db.District.GetSp(cbRegion.EditValue.ToStr());
            };

            Distributor = value;
            SetData(Distributor);

            CLang.Init(this);
        }

        public spDistributor GetData()
        {
            var d = new spDistributor();
            d.PersonName = edPersonName.Text;
            d.OrganizationName = edOrganizationName.Text;
            d.CreateDate = DateTime.Now;
            d.CreateUser = Vars.UserId;
            d.Description = edDescription.Text;
            d.RegionId = cbRegion.EditValue.ToInt();
            d.DistrictId = cbRayon.EditValue.ToInt();
            d.Phone = edPhone.Text;
            d.Status = 1;
            d.Address = edAdress.Text;
            d.INN = edINN.Text;
            d.MFO = edMFO.Text;
            d.OKONH = edOKONX.Text;
            d.BankName = edBankName.Text;
            d.SettlementAccount = edSettlementAccount.Text;
            d.Fax = edFax.Text;
            d.Email = edEmail.Text;
            return d;
        }

        private void SetData(spDistributor d)
        {
            edPersonName.EditValue = d.PersonName;
            edOrganizationName.EditValue = d.OrganizationName;
            edDescription.Text = d.Description;
            cbRegion.EditValue = d.RegionId;
            cbRayon.EditValue = d.DistrictId;
            edPhone.Text = d.Phone;
            edAdress.Text = d.Address;
            edINN.Text = d.INN;
            edMFO.Text = d.MFO;
            edOKONX.Text = d.OKONH;
            edBankName.Text = d.BankName;
            edSettlementAccount.Text = d.SettlementAccount;
            edFax.Text = d.Fax;
            edEmail.Text = d.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Distributor == null)
            {
                spDistributor sp = GetData();
                sp.Id = Guid.NewGuid();
                db.Distributor.Add(sp);
            }
            else
            {
                var d = db.Distributor.Get(Distributor.Id);
                d.PersonName = edPersonName.Text;
                d.OrganizationName = edOrganizationName.Text;
                d.UpdateDate = DateTime.Now;
                d.UpdateUser = Vars.UserId;
                d.Description = edDescription.Text;
                d.RegionId = cbRegion.EditValue.ToInt();
                d.DistrictId = cbRayon.EditValue.ToInt();
                d.Phone = edPhone.Text;
                d.Status = 1;
                d.Address = edAdress.Text;
                d.INN = edINN.Text;
                d.MFO = edMFO.Text;
                d.OKONH = edOKONX.Text;
                d.BankName = edBankName.Text;
                d.SettlementAccount = edSettlementAccount.Text;
                d.Fax = edFax.Text;
                d.Email = edEmail.Text;
            }

            db.Complete();
            UtilsUI.AlertMessage.Show("Данные успешно сохранены".ToLang(this.Name));
        }
    }
}