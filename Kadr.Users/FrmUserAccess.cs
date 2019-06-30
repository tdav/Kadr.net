using System;
using System.Linq;
using System.Collections.Generic;
using Kadr.Utils;
using Kadr.UtilsUI;
using Kadr.Models.Core;
using Kadr.Models;
using Kadr.Database.Views;
using Kadr.GlobalVars;

namespace Kadr.Users
{
    public partial class FrmUserAccess : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork db;
        private spRole Role;

        private List<viSpList> dsDest;
        private List<viSpList> dsList;


        public FrmUserAccess()
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            dsList = db.AccessList.GetSp();
            lsList.DataSource = dsList;

            dsDest = new List<viSpList>();
            lsDest.DataSource = dsDest;

            CLang.Init(this);
        }

        public FrmUserAccess(spRole v)
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            dsList = db.AccessList.GetSp();
            lsList.DataSource = dsList;

            Role = v;
            SetData();

            CLang.Init(this);
        }

        private spRole GetData()
        {
            var sr = new spRole();
            var s = "";
            foreach (var item in dsDest)
            {
                s = s + item.Id.ToString() + ",";
            }

            sr.Name = edName.Text;
            sr.UserAccess = s.Substring(0, s.Length - 1);
            sr.CreateUser = Vars.UserId;
            sr.CreateDate = DateTime.Now;

            return sr;
        }

        private void SetData()
        {
            edName.Text = Role.Name;
            var s = Role.UserAccess;
            dsDest = db.AccessList.GetList(s);
            lsDest.DataSource = dsDest;

            foreach (var dl in dsDest)
            {
                var ii = dsList.Where(x => x.Id == dl.Id).FirstOrDefault();
                dsList.Remove(ii);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateValue())
            {
                if (Role == null)
                {
                    var u = GetData();
                    u.CreateUser = Vars.UserId;
                    db.Role.Add(u);
                }
                else
                {
                    var ts = GetData();
                    var v = db.Role.Get(Role.Id);
                    v.Name = ts.Name;
                    v.UserAccess = ts.UserAccess;
                    v.Status = Role.Status;
                    v.UpdateDate = DateTime.Now;
                    v.UpdateUser = Vars.UserId;
                }

                db.Complete();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool ValidateValue()
        {
            dx.ClearErrors();
            var isError = true;

            if (edName.Text == "")
            {
                dx.SetError(edName, "Значение должно быть более пустым.".ToLang(this.Name));
                isError = false;
            }

            if (dsDest.Count == 0)
            {
                AlertMessage.ShowError("Список не должен быть более пустым.".ToLang(this.Name));
                isError = false;
            }

            return isError;
        }

        private void InsAccess(object sender, EventArgs e)
        {
            var sel = lsList.SelectedItem as viSpList;
            if (sel != null)
            {
                dsDest.Add(sel);
                dsList.Remove(sel);

                lsDest.Refresh();
                lsList.Refresh();
            }
        }

        private void lsList_DoubleClick(object sender, EventArgs e)
        {
            btnInsAccess.PerformClick();
        }

        private void DelAccess(object sender, EventArgs e)
        {
            var sel = lsDest.SelectedItem as viSpList;
            if (sel != null)
            {
                dsList.Add(sel);
                dsDest.Remove(sel);

                lsList.Refresh();
                lsDest.Refresh();
            }
        }

        private void lsDest_DoubleClick(object sender, EventArgs e)
        {
            btnDelAccess.PerformClick();
        }
    }
}