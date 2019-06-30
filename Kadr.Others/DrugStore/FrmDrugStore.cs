using Apteka.Models.Core;
using Apteka.Models.Entity;
using Apteka.Utils;
using Apteka.UtilsUI;
using System;

namespace Apteka.Others
{
    public partial class FrmDrugStore : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork db;
        private spDrugStore value;


        public FrmDrugStore()
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

        public FrmDrugStore(spDrugStore v)
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

            value = v;
            SetData(value);

            CLang.Init(this);
        }

        private void SetData(spDrugStore d)
        {
            edName.Text = d.Name;
            edPhone.Text = d.Phone;
            edFax.Text = d.Fax;
            edINN.Text = d.INN;
            edMFO.Text = d.MFO;
            edOKONX.Text = d.OKONH;
            edBankName.Text = d.BankName;
            edSettlementAccount.Text = d.SettlementAccount;
            edExtraChargeDefault.EditValue = d.ExtraChargeDefault;
            cbRegion.EditValue = d.RegionId;
            cbRayon.EditValue = d.DistrictId;
            edAdress.Text = d.Address;
            edAddressCheck.Text = d.AddressCheck;
        }

        public spDrugStore GetData()
        {
            var d = new spDrugStore();
            d.Name = edName.Text;
            d.Phone = edPhone.Text;
            d.Fax = edFax.Text;
            d.INN = edINN.Text;
            d.MFO = edMFO.Text;
            d.OKONH = edOKONX.Text;
            d.BankName = edBankName.Text;
            d.SettlementAccount = edSettlementAccount.Text;
            d.ExtraChargeDefault = edExtraChargeDefault.EditValue.ToDecimal(); ;
            d.RegionId = cbRegion.EditValue.ToInt();
            d.DistrictId = cbRayon.EditValue.ToInt();
            d.Address = edAdress.Text;
            d.AddressCheck = edAddressCheck.Text;
            d.Status = 1;
            d.CreateDate = DateTime.Now;
            d.CreateUser = Vars.UserId;
            return d;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                WaitFormManager.Show();

                if (value == null)
                {
                    var sp = GetData();
                    sp.Id = Guid.NewGuid();
                    db.DrugStore.Add(sp);
                }
                else
                {
                    var d = db.DrugStore.Get(value.Id);
                    d.Name = edName.Text;
                    d.Phone = edPhone.Text;
                    d.Fax = edFax.Text;
                    d.INN = edINN.Text;
                    d.MFO = edMFO.Text;
                    d.OKONH = edOKONX.Text;
                    d.BankName = edBankName.Text;
                    d.SettlementAccount = edSettlementAccount.Text;
                    d.ExtraChargeDefault = edExtraChargeDefault.EditValue.ToDecimal(); 
                    d.RegionId = cbRegion.EditValue.ToInt();
                    d.DistrictId = cbRayon.EditValue.ToInt();
                    d.Address = edAdress.Text;
                    d.AddressCheck = edAddressCheck.Text;
                    d.Status = 1;
                    d.UpdateDate = DateTime.Now;
                    d.UpdateUser = Vars.UserId;
                }

                db.Complete();
                AlertMessage.Show("Данные успешно сохранены".ToLang(this.Name));
            }
            finally
            {
                WaitFormManager.Close();
            }
        }

        private void edAddressCheck_Enter(object sender, EventArgs e)
        {
            var s = $"{cbRegion.Text} {cbRayon.Text} {edAdress.Text}";
            edAddressCheck.Text = s.ToLower();
        }
    }
}