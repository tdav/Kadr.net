﻿using System;
using System.Data;
using System.Windows.Forms;
using Apteka.Utils;
using DevExpress.XtraBars;
using Kadr.Database.Views;
using Kadr.GlobalVars;

namespace Kadr.Shtat
{
    public partial class frmShtatList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       private TBSHATTableAdapter ta = new TBSHATTableAdapter();
        public frmShtatList()
        {
            InitializeComponent();

            // This line of code is generated by Data Source Configuration Wizard

            cbOblastgr.DataSource = DicoDB.dt_SA_OBLAST;
            cbRayongr.DataSource = DicoDB.dt_SA_RAYON_All;
            cbDoljnostgr.DataSource = DicoDB.dt_SA_DOLJNOST;
            cbUcherejgr.DataSource = DicoDB.dt_SA_KOLLEJ;
            cbFangr.DataSource = DicoDB.dt_SA_PREDMET;

            tbshatTableAdapter1.Fill(kdnDataSet1.TBSHAT);

            cbKolej.DataSource = DicoDB.dt_SA_KOLLEJ;

            cbOblast.DataSource = DicoDB.dt_SA_OBLAST;
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ts = kdnDataSet1.TBSHAT.NewTBSHATRow();
            ts.BeginEdit();
            ts.KOLEJ = Vars.Ucherejdeniya;
            ts.OBLAST = Vars.Oblast;
            ts.RAYON = Vars.Rayon;
            ts.DOLJNOST = -1;
            ts.EDITDATE = DateTime.Today;
            ts.KOL_CHAS = 0;
            ts.PREDMET = -1;
            ts.STATE = -1;

            using (frmShtat f = new frmShtat())
            {
                f.bsMain.DataSource = ts;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ts.EndEdit();
                    ta.IU_DT(f.bsMain.Current as DataRow); 
                    tbshatTableAdapter1.Fill(kdnDataSet1.TBSHAT);
                }
                else
                {
                    ts.CancelEdit();
                }
            }
        }

        private void btnDel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var iii = GetSelectedIndex();
            if (iii >= 0)
            {
                var rec = GetSelectedRow(iii);
                ta.TBSHAT_DEL(rec["ID"].ToInt());
                tbshatTableAdapter1.Fill(kdnDataSet1.TBSHAT);
            }
        }
        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var iii = GetSelectedIndex();
            if (iii >= 0)
            {
                var ts = GetSelectedRow(iii);
                using (frmShtat f = new frmShtat())
                {
                    f.bsMain.DataSource = ts;
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        ts.EndEdit();
                        ta.IU_DT((f.bsMain.Current as DataRowView).Row); 
                        tbshatTableAdapter1.Fill(kdnDataSet1.TBSHAT);
                    }
                    else
                    {
                        ts.CancelEdit();
                    }
                }
            }
        }

        private DataRowView GetSelectedRow(int i)
        {
            return gridView1.GetRow(i) as DataRowView;
        }

        private int GetSelectedIndex()
        {
            return gridView1.FocusedRowHandle;
        }

        private void cbOblastbe_EditValueChanged(object sender, EventArgs e)
        {
            cbRayon.DataSource = DicoDB.SelectSQL(
               string.Format("SELECT ID, NAME{0} NAME FROM {1} WHERE Obl = {2} ORDER BY NAME",
                   Vars.Lang, "SA_RAYON", cbOblastbe.EditValue));

            cbKolej.DataSource = DicoDB.SelectSQL("select ID, NAME" + Vars.Lang +
                " as NAME from  SA_KOLLEJ WHERE OBL =" + cbRayonbe.EditValue.ToStr());
        }


        private void cbKolejbe_EditValueChanged(object sender, EventArgs e)
        {
            cbKolej.DataSource = DicoDB.SelectSQL("select ID, NAME" + Vars.Lang +
               " as NAME from  SA_KOLLEJ WHERE id =" + cbKolejbe.EditValue.ToStr());
        }



    }
}