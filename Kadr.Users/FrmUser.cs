using System;
using Apteka.Utils;
using Kadr.GlobalVars;
using Kadr.Models;
using Kadr.Models.Core;
using Kadr.Utils;

namespace Kadr.Users
{
    public partial class FrmUser : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork db;
        private tbUser User;

        public FrmUser()
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            cbStatus.Properties.DataSource = db.Status.GetSp();
            cbRole.Properties.DataSource = db.Role.GetSp();

            CLang.Init(this);
        }

        public FrmUser(tbUser v)
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            cbStatus.Properties.DataSource = db.Status.GetSp();
            cbRole.Properties.DataSource = db.Role.GetSp();

            User = v;
            SetData();

            CLang.Init(this);
        }

        private tbUser GetData()
        {
            var v = new tbUser();
            v.FirstName = edFirstName.Text;
            v.LastName = edLastName.Text;
            v.FatherName = edFatherName.Text;
            v.Email = edEmail.Text;
            v.Login = edLogin.Text;
            v.Password = edPassword1.Text;
            v.RoleId = cbRole.EditValue.ToInt();
            v.Status = cbStatus.EditValue.ToInt();
            return v;
        }

        private void SetData()
        {
            edFirstName.Text = User.FirstName;
            edLastName.Text = User.LastName;
            edFatherName.Text = User.FatherName;
            edEmail.Text = User.Email;
            edLogin.Text = User.Login;
            cbRole.EditValue = User.RoleId;
            cbStatus.EditValue = User.Status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateValue())
            {
                if (User == null)
                {
                    var u = GetData();
                    u.Id = Guid.NewGuid();
                    u.CreateUser = Vars.UserId;
                    db.User.Add(u);
                }
                else
                {
                    var v = db.User.Get(User.Id);
                    v.FirstName = edFirstName.Text;
                    v.LastName = edLastName.Text;
                    v.FatherName = edFatherName.Text;
                    v.Email = edEmail.Text;
                    v.Login = edLogin.Text;
                    v.RoleId = cbRole.EditValue.ToInt();
                    v.Status = cbStatus.EditValue.ToInt();
                    v.UpdateDate = DateTime.Now;
                    v.UpdateUser = Vars.UserId;

                    if (edPassword1.Text != "")
                    {
                        v.Password = CCrypt.EncryptRijndael(edPassword1.Text);
                    }
                }

                db.Complete();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool ValidateValue()
        {
            dx.ClearErrors();
            var isError = true;

            if (edPassword1.Text != "" || User == null)
            {

                if (edPassword1.Text != edPassword2.Text)
                {
                    dx.SetError(edPassword1, "Повторный пароль не совпадает первым.".ToLang(this.Name));
                    isError = false;
                }

                if (edPassword2.Text == "")
                {
                    dx.SetError(edPassword1, "Значения должны быть более пустыми.".ToLang(this.Name));
                    isError = false;

                }
            }

            if (cbRole.EditValue == null)
            {
                dx.SetError(cbRole, "Значения должны быть более пустыми.".ToLang(this.Name));
                isError = false;
            }

            if (edLogin.EditValue == null)
            {
                dx.SetError(edLogin, "Значения должны быть более пустыми.".ToLang(this.Name));
                isError = false;
            }

            if (edFirstName.EditValue == null)
            {
                dx.SetError(edFirstName, "Значения должны быть более пустыми.".ToLang(this.Name));
                isError = false;
            }

            if (edLastName.EditValue == null)
            {
                dx.SetError(edLastName, "Значения должны быть более пустыми.".ToLang(this.Name));
                isError = false;
            }

            if (edFatherName.EditValue == null)
            {
                dx.SetError(edFatherName, "Значения должны быть более пустыми.".ToLang(this.Name));
                isError = false;
            }

            return isError;
        }
    }
}