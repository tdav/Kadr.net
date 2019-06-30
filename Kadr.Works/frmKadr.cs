using Kadr.CommonControls;
using DevExpress.Data;
using DevExpress.XtraEditors;
using Kadr.Utils;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Kadr.GlobalVars;
using Apteka.Utils;
using Kadr.Database.Views;

namespace Kadr.Kadr
{
    public partial class frmKadrUZ : XtraForm
    {
        private dxErrorProvider ep;

        private TbMainTableAdapter tm = new TbMainTableAdapter();
        private TBFOTOTableAdapter tf = new TBFOTOTableAdapter();
        private TBGOSNAGRADITableAdapter tg = new TBGOSNAGRADITableAdapter();
        private TBATESTATIYATableAdapter ta = new TBATESTATIYATableAdapter();
        private TBPOVISHKVALTableAdapter tp = new TBPOVISHKVALTableAdapter();
        private TBUNIVERTableAdapter tu = new TBUNIVERTableAdapter();
        private TBMESTORABTableAdapter tr = new TBMESTORABTableAdapter();
        private TBQARINDOSHTableAdapter tq = new TBQARINDOSHTableAdapter();
        private TBDEPUTYTableAdapter td = new TBDEPUTYTableAdapter();




        private RecordState recordState;
        private string IdMain = "";



        private void peFoto_Properties_EditValueChanged(object sender, EventArgs e)
        {
            Image im = peFoto.Image;
            if (im != null)
            {
                tf.Insert(-1, IdMain, CImage.ImageToByte(im), DateTime.Now, Vars.UserId.ToInt(), 1);
            }
        }

        public frmKadrUZ(string mid, RecordState rs)
        {
            IdMain = mid;
            recordState = rs;
            InitializeComponent();

            SetSpTablesValue();
            Vars.ln.LoadUzbekKeyboardLayout();

            var txt = new PDateEdit();
            txt.ConvertDateEdit(edDDataRoj);
            txt.ConvertDateEdit(edDDatePrikaza);
            txt.ConvertDateEdit(edDProhojPP);

            ep = new dxErrorProvider();

            CLang.Init(this);

            try
            {
                #region Edit

                if (recordState == RecordState.rsEdit)
                {
                    var dt = tm.GetDataById(IdMain);
                    bsMain.DataSource = dt;

                    var df = tf.GetDataByMainId(IdMain);
                    bsFoto.DataSource = df;
                    //peFoto.Image = df.Rows[0]["FOTO"] != DBNull.Value
                    //    ? CImage.ByteArrayToImage(df.Rows[0]["FOTO"] as byte[])
                    //    : null;


                    var dg = tg.GetDataByMainId(IdMain);
                    bsGosNagradi.DataSource = dg;

                    var da = ta.GetDataByMainId(IdMain);
                    bsAtestaciya.DataSource = da;
                    var dp = tp.GetDataByMainId(IdMain);
                    bsPovisheniyaKVL.DataSource = dp;

                    var du = tu.GetDataByMainId(IdMain);
                    bsDiplom.DataSource = du;

                    var dr = tr.GetDataByMainId(IdMain);
                    bsMestoRaboti.DataSource = dr;

                    var dq = tq.GetDataByMainId(IdMain);
                    bsQarindosh.DataSource = dq;

                    var dd = td.GetDataByMainId(IdMain);
                    bsDeputy.DataSource = dd;

                }
                #endregion

                else
                #region Insert

                {
                    var dm = new Kadr.Data.KdnDataSet.TbMainDataTable();
                    var rm = dm.NewTbMainRow();
                    rm.ID = IdMain;

                    rm.ST_REGION = Vars.Oblast;
                    cbOblast.EditValue = Vars.Oblast;
                    rm.ST_RAYON = Vars.Rayon;
                    rm.ST_VIDUCHEREJDENIYA = Vars.Turi;
                    cbVidUcherejdeniya.EditValue = Vars.Turi;
                    // cbUcherejdeniya.Properties.DataSource = DicoDB.SelectSQL("select ID, NAME" + GlobalVars.Lang + " as NAME from  SA_KOLLEJ WHERE TURI =" + GlobalVars.Turi.ToStr());
                    rm.KOLORLIC = Vars.Ucherejdeniya;

                    dm.Rows.Add(rm);
                    bsMain.DataSource = dm;
                    var df = new Kadr.Data.KdnDataSet.TBFOTODataTable();
                    var drf = df.NewTBFOTORow();
                    df.Rows.Add(drf);
                    bsFoto.DataSource = df;

                    bsGosNagradi.DataSource = new Kadr.Data.KdnDataSet.TBGOSNAGRADIDataTable();
                    bsAtestaciya.DataSource = new Kadr.Data.KdnDataSet.TBATESTATIYADataTable();
                    bsPovisheniyaKVL.DataSource = new Kadr.Data.KdnDataSet.TBPOVISHKVALDataTable();
                    bsDiplom.DataSource = new Kadr.Data.KdnDataSet.TBUNIVERDataTable();
                    bsMestoRaboti.DataSource = new Kadr.Data.KdnDataSet.TBMESTORABDataTable();
                    bsQarindosh.DataSource = new Kadr.Data.KdnDataSet.TBQARINDOSHDataTable();
                    bsDeputy.DataSource = new Kadr.Data.KdnDataSet.TBDEPUTYDataTable();
                }

                #endregion
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());

            }
        }



        private void InitValidationRules()
        {
            dxValidation.SetValidationRule(edFam,
                dxValidation.RuleNotEmptyFioCir(edFam.Text, edFam.Text, edFam.Text));
            dxValidation.SetValidationRule(edIsmi,
                dxValidation.RuleNotEmptyFioCir(edIsmi.Text, edIsmi.Text, edIsmi.Text));
            dxValidation.SetValidationRule(edOtch,
                dxValidation.RuleNotEmptyFioCir(edOtch.Text, edOtch.Text, edOtch.Text));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetSpTablesValue()
        {
            cbVidUcherejdeniya.Properties.DataSource = DicoDB.dt_SA_VID_UCHEREJDENI;
            cbUcherejdeniya.Properties.DataSource = DicoDB.dt_SA_KOLLEJ;

            cbCITIZEN.Properties.DataSource = DicoDB.dt_SA_CITIZEN;
            cbOblast.Properties.DataSource = DicoDB.dt_SA_OBLAST;

            cbMesJitCountry.Properties.DataSource = DicoDB.dt_SA_COUNTRY;
            cbMesJitOblast.Properties.DataSource = DicoDB.dt_SA_OBLAST;

            cbMesRojCountry.Properties.DataSource = DicoDB.dt_SA_COUNTRY;
            cbMesRojObl.Properties.DataSource = DicoDB.dt_SA_OBLAST;
            cbMesRojObl.EditValueChanged += (ss, ee) =>
            {
                var cb = ss as DevExpress.XtraEditors.LookUpEdit;
                cbMesRojRayon.Properties.DataSource = DicoDB.SelectSQL(
                    string.Format("SELECT ID, NAME{0} NAME FROM {1} WHERE Obl = {2} ORDER BY NAME",
                        Vars.Lang, "SA_RAYON", cb.EditValue.ToStr()));
            };

            cbMalumoti.Properties.DataSource = DicoDB.dt_SA_OBRAZOVANIYA;
            cbImiyDaraja.Properties.DataSource = DicoDB.dt_SA_UCHENIY_STEPEN;
            cbHarbiyUnvoni.Properties.DataSource = DicoDB.dt_SA_HARBIY_UNVON;

            cbDoljnost.Properties.DataSource = DicoDB.dt_SA_DOLJNOST;
            cbGdeProhodolPP.Properties.DataSource = DicoDB.dt_SA_PROHODIL_YN;
            cbNat.Properties.DataSource = DicoDB.dt_SA_NAT;
            cbObjLang.Properties.DataSource = DicoDB.dt_SA_OBJLANG;

            cbVidPP_DpPredmet.Properties.DataSource = DicoDB.dt_SA_PEDAGOG_YN;
            cbVidPP_OsPredmet.Properties.DataSource = DicoDB.dt_SA_PEDAGOG_YN;

            cbPP_Dp.Properties.DataSource = DicoDB.dt_SA_SEX; ///////////////


            cbPP_Dp_Yazik.Properties.DataSource = DicoDB.dt_SA_LANGS;
            cbPP_Os_Yazik.Properties.DataSource = DicoDB.dt_SA_LANGS;

            cbPP_Os.Properties.DataSource = DicoDB.dt_SA_PREDMET;
            cbPP_Dp.Properties.DataSource = DicoDB.dt_SA_PREDMET;

            cbPP_Os_Spec.Properties.DataSource = DicoDB.dt_SA_SPECIALITY;
            cbPP_Dp_Spec.Properties.DataSource = DicoDB.dt_SA_SPECIALITY;

            cbPedObrazovanie.Properties.DataSource = DicoDB.dt_SA_PEDOBRAZOVANIE;
            cbPedPerepodgotovka.Properties.DataSource = DicoDB.dt_SA_PEDPEREPOD;
            cbPo_Statu.Properties.DataSource = DicoDB.dt_SA_PO_SHATATU;
            cbSemeyniyPolojeniya.Properties.DataSource = DicoDB.dt_SA_MARRIED;
            cbSex.Properties.DataSource = DicoDB.dt_SA_SEX;
            cbVZnanKomputer.Properties.DataSource = DicoDB.dt_SA_YESNO;
            cbVidObrazUcherejdeniya.DataSource = DicoDB.dt_SA_VID_UCHEREJDENI;

            cbVladetYazik.Properties.DataSource = DicoDB.dt_SA_LANGS;
            cbV_DannoyOP.Properties.DataSource = DicoDB.dt_SA_RABOTAET_YN;


            cbVidObrazovatelUcherejdeniya.DataSource = DicoDB.dt_SA_VID_UCHEREJDENI_DIPLO; //Тип обучения
            cbObrazovatelUcherejneniya.DataSource = DicoDB.dt_SA_VUZ; //Образовательного учереждения
            cbYesNo.DataSource = DicoDB.dt_SA_YESNO; //Профессиональное обучения
            cbVidObucheniya.DataSource = DicoDB.dt_SA_VID_OBUCHENIYA; //Вид обучения


            cbMestoProhojPK.DataSource = DicoDB.dt_SA_PROHODIL_YN; //Место прохождение ПК
            cbPedObrazovaniePK.DataSource = DicoDB.dt_SA_PEDOBRAZOVANIE; //Педагогическое образование

            cbPrivlichenKAtestat.DataSource = DicoDB.dt_SA_ATESTACIYA_YN; // Привлечение к аттестац
            cbAtestatRes.DataSource = DicoDB.dt_SA_ATESTACIYA_RES; //Резултат аттестации
            cbDoljnostPosAtestat.DataSource = DicoDB.dt_SA_DOLJNOST; //Должность после аттестации

            cbGosNagrada.DataSource = DicoDB.dt_SA_NAGRADA; //Государственные награды

            cbQarindoshligi.DataSource = DicoDB.dt_SA_RODSTVENNIK;
            cbDavlatQ.DataSource = DicoDB.dt_SA_COUNTRY;
            //cbDavlatQ.EditValueChanged +=(ss, ee)=>
            //{
            //    var cb = ss as DevExpress.XtraEditors.LookUpEdit;
            //    cbOblastQ.Properties.DataSource = DicoDB.SelectSQL(
            //     string.Format("SELECT ID, NAME{0} NAME FROM {1} WHERE COUNTRY_ID = {2} ORDER BY NAME",
            //         GlobalVars.Lang, "SA_OBLAST", cb.EditValue.ToStr()));
            //};
            cbOblastQ.DataSource = DicoDB.dt_SA_OBLAST;
            //cbOblastQ.EditValueChanged += (ss, ee) =>
            //{
            //    var cb = ss as DevExpress.XtraEditors.LookUpEdit;
            //    cbRayonQ.Properties.DataSource = DicoDB.SelectSQL(
            //     string.Format("SELECT ID, NAME{0} NAME FROM {1} WHERE Obl = {2} ORDER BY NAME",
            //         GlobalVars.Lang, "SA_RAYON", cb.EditValue.ToStr()));
            //};

        }

        private void frmTexp_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F9:
                    btnSave.PerformClick();
                    break;

                case Keys.F12:
                    btnClose.PerformClick();
                    break;

                default:
                    break;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            bsMain.EndEdit();
            Kadr.Data.KdnDataSet.TbMainDataTable dt = bsMain.DataSource as Kadr.Data.KdnDataSet.TbMainDataTable;
            tm.IU_DT(dt);

            bsFoto.EndEdit();
            DataRowView df = bsFoto.Current as DataRowView;
            if (df != null && df.DataView.Table.Rows.Count > 0)
            {
                DataRow dataRow = df.Row;
                if (dataRow.RowState == DataRowState.Added || dataRow.RowState == DataRowState.Modified)
                    tf.IU_DT(dataRow, IdMain);
            }

            bsGosNagradi.EndEdit();
            DataRowView dg = bsGosNagradi.Current as System.Data.DataRowView;
            if (dg != null)
                foreach (DataRow r in dg.DataView.Table.Rows)
                {
                    if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                    {
                        tg.IU_DT(r, IdMain);
                    }
                }

            bsAtestaciya.EndEdit();
            DataRowView da = bsAtestaciya.Current as DataRowView;
            if (da != null)
                foreach (DataRow r in da.DataView.Table.Rows)
                {
                    if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                    {
                        ta.IU_DT(r, IdMain);
                    }
                }


            bsPovisheniyaKVL.EndEdit();
            DataRowView dp = bsPovisheniyaKVL.Current as DataRowView;
            if (dp != null)
                foreach (DataRow r in dp.DataView.Table.Rows)
                {
                    if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                    {
                        tp.IU_DT(r, IdMain);
                    }
                }

            bsDiplom.EndEdit();
            DataRowView dd = bsDiplom.Current as DataRowView;
            if (dd != null)
                foreach (DataRow r in dd.DataView.Table.Rows)
                {
                    if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                    {
                        tu.IU_DT(r, IdMain);
                    }
                }

            bsMestoRaboti.EndEdit();
            DataRowView dm = bsMestoRaboti.Current as DataRowView;
            if (dm != null)
                foreach (DataRow r in dm.DataView.Table.Rows)
                {
                    if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                    {
                        tr.IU_DT(r, IdMain);
                    }
                }

            bsQarindosh.EndEdit();
            DataRowView dq = bsQarindosh.Current as DataRowView;
            if (dq != null)
                foreach (DataRow r in dq.DataView.Table.Rows)
                {
                    if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                    {
                        tq.IU_DT(r, IdMain);
                    }
                }


            bsDeputy.EndEdit();
            DataRowView ddr = bsDeputy.Current as DataRowView;
            if (ddr != null)
                foreach (DataRow r in ddr.DataView.Table.Rows)
                {
                    if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                    {
                        td.IU_DT(r, IdMain);
                    }
                }


            DialogResult = DialogResult.OK;
        }





        #region  gridView RowDeleting

        private void gridViewMestoRaboti_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewMestoRaboti.GetRow(e.RowHandle) as DataRowView;
            tr.TBMESTORAB_DEL(r["ID"].ToInt());
        }

        private void gridViewQarindosh_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewQarindosh.GetRow(e.RowHandle) as DataRowView;
            tq.TBQARINDOSH_DEL(r["ID"].ToInt());
        }

        private void gridViewDiplom_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewDiplom.GetRow(e.RowHandle) as DataRowView;
            tu.TBUNIVER_DEL(r["ID"].ToInt());
        }

        private void gridViewPovishKv_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewPovishKv.GetRow(e.RowHandle) as DataRowView;
            tp.TBPOVISHKVAL_DEL(r["ID"].ToInt());
        }

        private void gridViewAtestaciya_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewAtestaciya.GetRow(e.RowHandle) as DataRowView;
            ta.TBATESTATIYA_DEL(r["ID"].ToInt());
        }

        private void gridViewGosNagradi_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewGosNagradi.GetRow(e.RowHandle) as DataRowView;
            tg.TBGOSNAGRADI_DEL(r["ID"].ToInt());
        }

        private void gridView1_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewGosNagradi.GetRow(e.RowHandle) as DataRowView;
            tg.TBGOSNAGRADI_DEL(r["ID"].ToInt());
        }

        #endregion

        private void cbVidUcherejdeniya_EditValueChanged(object sender, EventArgs e)
        {
            cbUcherejdeniya.Properties.DataSource =
                DicoDB.SelectSQL("select ID, NAME" + Vars.Lang + " as NAME from  SA_KOLLEJ WHERE TURI =" +
                                 cbVidUcherejdeniya.EditValue.ToStr());
            cbUcherejdeniya.EditValue = null;
        }

        private void cbOblast_EditValueChanged(object sender, EventArgs e)
        {
            cbRayon.Properties.DataSource = DicoDB.SelectSQL(
                string.Format("SELECT ID, NAME{0} NAME FROM {1} WHERE Obl = {2} ORDER BY NAME",
                    Vars.Lang, "SA_RAYON", cbOblast.EditValue));

        }

        private void cbMesJitOblast_EditValueChanged(object sender, EventArgs e)
        {
            cbMesJitRayon.Properties.DataSource = DicoDB.SelectSQL(
                string.Format("SELECT ID, NAME{0} NAME FROM {1} WHERE Obl = {2} ORDER BY NAME",
                    Vars.Lang, "SA_RAYON", cbMesJitOblast.EditValue));
        }

        private void cbMesJitCountry_EditValueChanged(object sender, EventArgs e)
        {
            cbMesJitOblast.Properties.DataSource = DicoDB.SelectSQL(
                string.Format("SELECT ID, NAME{0} NAME FROM {1} WHERE COUNTRY_ID = {2} ORDER BY NAME",
                    Vars.Lang, "SA_OBLAST", cbMesJitCountry.EditValue));
        }

        private void OnEnterLat(object sender, EventArgs e)
        {
            Vars.ln.LoadEnglishKeyboardLayout();
        }

        private void OnEnterCir(object sender, EventArgs e)
        {
            Vars.ln.LoadUzbekKeyboardLayout();
        }

        private void cbObjLang_EditValueChanged(object sender, EventArgs e)
        {

            this.textEdit3.DataBindings.Clear();
            this.textEdit9.DataBindings.Clear();
            this.textEdit8.DataBindings.Clear();
            this.textEdit2.DataBindings.Clear();
            this.textEdit14.DataBindings.Clear();

            if (cbObjLang.EditValue.ToStr() == "1")
            {
                this.textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain,
                    "QISHLOQ_PROPISKA", true));
                this.textEdit9.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain,
                    "KUCHA_PROPISKA", true));
                this.textEdit8.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "UY_PROPISKA",
                    true));
                this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain,
                    "HONADON_PROPISKA", true));
                this.textEdit14.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "PRICHINA",
                    true));

                this.gridColumn4.FieldName = "PICHINA_NE_PRIVLICHENIYA";
                this.gridColumn6.FieldName = "NAZVANIE";
                this.gridColumn14.FieldName = "ISHJOYI";
                this.gridColumn15.FieldName = "LAVOZIM";
                this.gridColumn27.FieldName = "YASHASHJOYI";
                this.gridColumn23.FieldName = "ISHJOYI";
            }
            else
            {
                this.textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain,
                    "QISHLOQ_PROPISKA_RU", true));
                this.textEdit9.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain,
                    "KUCHA_PROPISKA_RU", true));
                this.textEdit8.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain,
                    "UY_PROPISKA_RU", true));
                this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain,
                    "HONADON_PROPISKA_RU", true));
                this.textEdit14.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain,
                    "PRICHINA_RU", true));

                this.gridColumn4.FieldName = "PICHINA_NE_PRIVLICHENIYA_RU";
                this.gridColumn6.FieldName = "NAZVANIE_RU";
                this.gridColumn14.FieldName = "ISHJOYI_RU";
                this.gridColumn15.FieldName = "LAVOZIM_RU";
                this.gridColumn27.FieldName = "YASHASHJOYI_RU";
                this.gridColumn23.FieldName = "ISHJOYI_RU";
            }
        }





        private void peFoto_ContextMenuStripChanged(object sender, EventArgs e)
        {

        }
    }

}
