using System;
using Apteka.Models.Core;
using Apteka.Models.Entity;
using Apteka.Utils;

namespace Apteka.Others
{
    public partial class FrmNewCustomer : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork db;
        private tbCustomer Customer;

        public FrmNewCustomer()
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            CLang.Init(this);
        }

        public FrmNewCustomer(tbCustomer tb)
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            Customer = tb;
            SetData(tb);

            CLang.Init(this);
        }

        public tbCustomer GetData()
        {
            var d = new tbCustomer();
            d.Address = edAdress.Text;
            d.FIO = edFIO.Text;
            d.Phone = edPhone.Text;
            d.Email = "";
            d.CreateDate = DateTime.Now;
            d.CreateUser = Vars.UserId;
            d.Status = 1;
            return d;
        }

        public void SetData(tbCustomer d)
        {
            edAdress.EditValue = d.Address;
            edFIO.EditValue = d.FIO;
            edPhone.EditValue = d.Phone;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Customer == null)
            {
                tbCustomer sp = GetData();
                sp.Id = Guid.NewGuid();
                db.Customer.Add(sp);
            }
            else
            {
                var d = db.Customer.Get(Customer.Id);
                d.Address = edAdress.Text;
                d.FIO = edFIO.Text;
                d.Phone = edPhone.Text;
                d.Email = "";
                d.UpdateDate = DateTime.Now;
                d.UpdateUser = Vars.UserId;
                d.Status = 1;
            }

            db.Complete();
            UtilsUI.AlertMessage.Show("Данные успешно сохранены".ToLang(this.Name));
        }
    }
}