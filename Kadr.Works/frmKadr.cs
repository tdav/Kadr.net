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
using Kadr.Models.Core;
using Kadr.Models;
using System.Collections.Generic;

namespace Kadr.Kadr
{
    public partial class frmKadrUZ : XtraForm
    {
        /*
            private TbMainTableAdapter tm = new TbMainTableAdapter();
            private TBFOTOTableAdapter tf = new TBFOTOTableAdapter();
            private TBGOSNAGRADITableAdapter tg = new TBGOSNAGRADITableAdapter();
            private TBATESTATIYATableAdapter ta = new TBATESTATIYATableAdapter();
            private TBPOVISHKVALTableAdapter tp = new TBPOVISHKVALTableAdapter();
            private TBUNIVERTableAdapter tu = new TBUNIVERTableAdapter();
            private TBMESTORABTableAdapter tr = new TBMESTORABTableAdapter();
            private TBQARINDOSHTableAdapter tq = new TBQARINDOSHTableAdapter();
            private TBDEPUTYTableAdapter td = new TBDEPUTYTableAdapter();
        */


        private IUnitOfWork db;
        private dxErrorProvider ep;

        private RecordState recordState;
        private int IdMain;

        private tbMain curMain;

        private void FrmKadrUZ_Load(object sender, EventArgs e)
        {
            db = new UnitOfWork();
        }

        private void peFoto_Properties_EditValueChanged(object sender, EventArgs e)
        {
            Image im = peFoto.Image;
            if (im != null)
            {
                var foto = new tbPhoto();
                foto.Mainid = IdMain;
                foto.Foto = CImage.ImageToByte(im);
                foto.Editdate = DateTime.Now;
                foto.Edituser = Vars.UserId;
                foto.Active = 1;
                db.Photo.Add(foto);
            }
        }

        public frmKadrUZ(int mid, RecordState rs)
        {
            IdMain = mid;
            recordState = rs;
            InitializeComponent();

            SetSpTablesValue();
            Vars.KeyboardLang.LoadUzbekKeyboardLayout();

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
                    curMain = db.Main.Get(IdMain);
                    bsMain.DataSource = curMain;

                    bsFoto.DataSource = curMain.Photo;
                    bsGosNagradi.DataSource = curMain.GosnagradiList;
                    bsAtestaciya.DataSource = curMain.AtestatiyaList;
                    bsPovisheniyaKVL.DataSource = curMain.PovishkvalList;
                    bsDiplom.DataSource = curMain.UniverList;
                    bsMestoRaboti.DataSource = curMain.MestorabList;
                    bsQarindosh.DataSource = curMain.QarindoshList;
                    bsDeputy.DataSource = curMain.DeputyList;

                }
                #endregion

                else
                #region Insert

                {
                    curMain = new tbMain();
                    curMain.Id = IdMain;
                    curMain.StRegion = Vars.Oblast;
                    cbOblast.EditValue = Vars.Oblast;
                    curMain.StRayon= Vars.Rayon;
                    curMain.StViducherejdeniya= Vars.Turi;
                    cbVidUcherejdeniya.EditValue = Vars.Turi;
                    curMain.Kolorlic= Vars.Ucherejdeniya;

                    bsMain.DataSource = curMain;
                    curMain.Photo = new tbPhoto();
                    bsFoto.DataSource = curMain.Photo;

                    curMain.GosnagradiList = new List<tbGosnagradi>();
                    curMain.AtestatiyaList = new List<tbAtestatiya>();
                    curMain.PovishkvalList = new List<tbPovishkval>();
                    curMain.MestorabList     = new List<tbMestorab>();
                    curMain.QarindoshList = new List<tbQarindosh>();
                    curMain.DeputyList       = new List<tbDeputy>();
                    curMain.UniverList       = new List<tbUniver>();

                    bsGosNagradi.DataSource = curMain.GosnagradiList;
                    bsAtestaciya.DataSource = curMain.AtestatiyaList;
                    bsPovisheniyaKVL.DataSource = curMain.PovishkvalList;
                    bsDiplom.DataSource = curMain.UniverList;
                    bsMestoRaboti.DataSource = curMain.MestorabList;
                    bsQarindosh.DataSource = curMain.QarindoshList;
                    bsDeputy.DataSource = curMain.DeputyList;
                    
                    // cbUcherejdeniya.Properties.DataSource = DicoDB.SelectSQL("select ID, NAME" + GlobalVars.Lang + " as NAME from  SA_KOLLEJ WHERE TURI =" + GlobalVars.Turi.ToStr());
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

            if (recordState == RecordState.rsNew)
            {
                db.Main.Add(curMain);
            }

            db.Complete();
            DialogResult = DialogResult.OK;
        }





        #region  gridView RowDeleting

        private void gridViewMestoRaboti_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewMestoRaboti.GetRow(e.RowHandle) as tbMestorab;
            curMain.MestorabList.Remove(r);
        }

        private void gridViewQarindosh_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewQarindosh.GetRow(e.RowHandle) as tbQarindosh;
            curMain.QarindoshList.Remove(r);
        }

        private void gridViewDiplom_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewDiplom.GetRow(e.RowHandle) as tbUniver;
            curMain.UniverList.Remove(r);
        }

        private void gridViewPovishKv_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewPovishKv.GetRow(e.RowHandle) as tbPovishkval;
            curMain.PovishkvalList.Remove(r);
        }

        private void gridViewAtestaciya_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewAtestaciya.GetRow(e.RowHandle) as tbAtestatiya;
            curMain.AtestatiyaList.Remove(r);
        }

        private void gridViewGosNagradi_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewGosNagradi.GetRow(e.RowHandle) as tbGosnagradi;
            curMain.GosnagradiList.Remove(r);
        }

        private void gridViewDeputy_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            var r = gridViewGosNagradi.GetRow(e.RowHandle) as tbDeputy;
            curMain.DeputyList.Remove(r);
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
            Vars.KeyboardLang.LoadEnglishKeyboardLayout();
        }

        private void OnEnterCir(object sender, EventArgs e)
        {
            Vars.KeyboardLang.LoadUzbekKeyboardLayout();
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
