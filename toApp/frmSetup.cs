using System;
using DevExpress.XtraEditors;
using Kadr.Database.Views;
using Kadr.Models;
using Kadr.Models.Core;
using System.Linq;
using Kadr.GlobalVars;

namespace App
{
    public partial class frmSetup : XtraForm
    {
        private tbSetup sl;

        public frmSetup()
        {
            InitializeComponent(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sl = bsRes.Current as tbSetup;

            Vars.Oblast = sl.Oblast;
            Vars.Rayon = sl.Rayon;
            Vars.Turi = sl.Turi;
            Vars.Ucherejdeniya = sl.Ucherejdeniya;

            using (var db = new UnitOfWork())
            {
                var it = db.Setup.Find(x => x.Id == sl.Id).FirstOrDefault();
                if (it != null)
                {
                    db.Setup.Update(it);
                }
                else
                {
                    db.Setup.Add(it);
                }

                db.Complete();
                Close();
            }
        }
        
        private void vGridControl_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {

            //TODO 1
            if (e.Row.Index == 0)
            {
                cbRayon.DataSource = DicoDB.SelectSQL(
                    string.Format("SELECT ID, NAME{0} NAME FROM {1} WHERE Obl = {2} ORDER BY NAME",
                        Vars.Lang, "SA_RAYON", e.Value));
            }

            if (e.Row.Index == 2)
            {
                cbKol.DataSource = DicoDB.SelectSQL(
                    string.Format("select ID, name{2} NAME from sa_kollej t where t.turi ={0}  and t.obl = {1}",
                        sl.Turi, sl.Oblast, Vars.Lang));
            }
        }

        private async void FrmSetup_LoadAsync(object sender, EventArgs e)
        {
            using (var db = new UnitOfWork())
            {
                cbObl.DataSource = await db.Sps.GetSpAsync("SA_OBLAST", Vars.Lang);
                cbTuri.DataSource = await db.Sps.GetSpAsync("SA_VID_UCHEREJDENI", Vars.Lang);
                sl = db.Setup.GetAll().FirstOrDefault();

                if (sl == null)
                {
                    sl = new tbSetup();
                    sl.Id = -1;
                }
                bsRes.DataSource = sl;
            }
        }
    }
}