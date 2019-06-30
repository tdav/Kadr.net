using System;
using System.Linq;
using Apteka.Models.Core;
using Apteka.Models.Entity;
using Apteka.Utils;
using Apteka.UtilsUI;

namespace Apteka.Others
{
    public partial class FrmNewManufacturer : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork db;
        private spManufacturer value;

        public FrmNewManufacturer()
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            cbCountry.Properties.DataSource = db.Country.GetSp();

            CLang.Init(this);
        }

        public FrmNewManufacturer(spManufacturer v)
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            cbCountry.Properties.DataSource = db.Country.GetSp();
            value = v;
            SetData(value);
            CLang.Init(this);
        }

        private void SetData(spManufacturer cp)
        {
            cbCountry.EditValue = cp.CountryId;
            edName.Text = cp.Name;
        }

        public spManufacturer GetData()
        {            
            var cp = new spManufacturer();
            cp.Id = Guid.NewGuid();
            cp.CountryId = cbCountry.EditValue.ToInt();
            cp.Name = edName.Text;
            cp.Status = 1;
            cp.CreateDate = DateTime.Now;
            cp.CreateUser = Vars.UserId;

            return cp;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (value ==null)
            {
                var md = db.Manufacturer.FindNoTracking(x => x.Name == edName.Text).ToList();
                if (md.Count > 0)
                {
                    MessageBoxDev.ShowError("Таким заначеним Производитель уже есть".ToLang(this.Name));
                    DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }
                var d = GetData();
                db.Manufacturer.Add(d);
            }
            else
            {
                var cp = db.Manufacturer.Get(value.Id);
                cp.CountryId = cbCountry.EditValue.ToInt();
                cp.Name = edName.Text;
                cp.Status = 1;
                cp.UpdateDate = DateTime.Now;
                cp.UpdateUser = Vars.UserId;
                cp.Status = 1;
            }
                        
            db.Complete();
        }

        private void FrmNewManufacturer_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (this.DialogResult== System.Windows.Forms.DialogResult.OK && cbCountry.EditValue == null)
            {
                AlertMessage.ShowError("Выберете страну".ToLang(this.Name));
                e.Cancel = true;
            }
        }
    }
}