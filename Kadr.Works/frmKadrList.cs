using Kadr.CommonControls;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using Kadr.Utils;
using Kadr.Database.Views;
using Kadr.GlobalVars;
using Apteka.Utils;
using Kadr.Models;
using Kadr.Models.Core;
using Kadr.Template;

namespace Kadr.Kadr
{
    public partial class frmKadrList : RibbonForm
    {
        public delegate void DelegateOnCloseChildForm(object sender);
        public string gridViewStyle = "";
        private int GridShowArm = 1; //Texp=1 Pasp=2, localTexp=3
        private IUnitOfWork db;

        public frmKadrList()
        {
            InitializeComponent();


            CLang.Init(this);

            db = new UnitOfWork();

            var txt = new PDateEdit();
            txt.ConvertDateEdit(edTugDate1);
            txt.ConvertDateEdit(edTugDate2);

            try
            {
                cbViloyat.Properties.DataSource = DicoDB.dt_SA_OBLAST;
                cbSex.Properties.DataSource = DicoDB.dt_SA_SEX;
                cbVidUcherejdeniya.Properties.DataSource = DicoDB.dt_SA_VID_UCHEREJDENI;
                cbUchOblast.Properties.DataSource = DicoDB.dt_SA_OBLAST; cbUcherejdeniya.Properties.DataSource = DicoDB.dt_SA_KOLLEJ;
                cbNat.Properties.DataSource = DicoDB.dt_SA_NAT; cbSemPolojeniya.Properties.DataSource = DicoDB.dt_SA_MARRIED;

                cbGrdDoljnost.DataSource = DicoDB.dt_SA_DOLJNOST;
                cbGrdOblast.DataSource = DicoDB.dt_SA_OBLAST;
                cbGrdRayon.DataSource = DicoDB.dt_SA_RAYON_All;
                cbGrdUcherej.DataSource = DicoDB.dt_SA_KOLLEJ;
                cbGridStatus.DataSource = DicoDB.dt_SA_RABOTAET_YN;

            }
            catch (Exception err)
            {
                CEventLog.Write(string.Format("frmTexpList_Shown() -> {0}", err));
            }
        }

        public event DelegateOnCloseChildForm OnCloseChildForm;

        private void OnEnterAndToLat(object sender, EventArgs e)
        {
            Vars.KeyboardLang.LoadEnglishKeyboardLayout();
        }

        private void OnEnterAndToRus(object sender, EventArgs e)
        {
            Vars.KeyboardLang.LoadUzbekKeyboardLayout();
        }

        private bool IsTexpGridState()
        {
            var res = true;
            if (gridControl.MainView == grKadrCard)
            {
                res = true;
            }
            if (gridControl.MainView == grKadrList)
            {
                res = true;
            }
            if (gridControl.MainView == grKadrSimple)
            {
                res = true;
            }

            if (gridControl.MainView == grPaspList)
            {
                res = false;
            }

            if (gridControl.MainView == grPaspCard)
            {
                res = false;
            }
            return res;
        }

        private int GetSelectedIndex()
        {
            if (gridControl.MainView == grKadrCard)
            {
                return grKadrCard.FocusedRowHandle;
            }
            if (gridControl.MainView == grKadrList)
            {
                return grKadrList.FocusedRowHandle;
            }
            if (gridControl.MainView == grKadrSimple)
            {
                return grKadrSimple.FocusedRowHandle;
            }

            if (gridControl.MainView == grPaspList)
            {
                return grPaspList.FocusedRowHandle;
            }

            if (gridControl.MainView == grPaspCard)
            {
                return grPaspCard.FocusedRowHandle;
            }

            return -1;
        }

        private DataRowView GetTexpSelectedRow(int i)
        {
            if (gridControl.MainView == grKadrCard)
            {
                return grKadrCard.GetRow(i) as DataRowView;
            }
            if (gridControl.MainView == grKadrList)
            {
                return grKadrList.GetRow(i) as DataRowView;
            }

            if (gridControl.MainView == grKadrSimple)
            {
                return grKadrSimple.GetRow(i) as DataRowView;
            }
            return null;
        }
        
        private string GetFindExp()
        {
            var val = new List<string>();

            if (edFam.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "FIRSTNAME like " + edFam.Text.Replace('*', '%').ToQuote());
            if (edImya.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "LASTNAME like " + edImya.Text.Replace('*', '%').ToQuote());
            if (edOtch.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "PATRONYMIC like " + edOtch.Text.Replace('*', '%').ToQuote());
            if (cbViloyat.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "REGION_PROPISKA = " + cbViloyat.EditValue.ToStr());
            if (cbTuman.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "RAYON_PROPISKA = " + cbTuman.EditValue.ToStr());
            if (edKishlak.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "QISHLOQ_PROPISKA like " + edKishlak.Text.Replace('*', '%').ToQuote());
            if (edKucha.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "KUCHA_PROPISKA like " + edKucha.Text.Replace('*', '%').ToQuote());
            if (edUy.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "UY_PROPISKA like " + edUy.Text.Replace('*', '%').ToQuote());
            if (edHonadon.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "HONADON_PROPISKA like " + edHonadon.Text.Replace('*', '%').ToQuote());
            if (edPaspSer.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "PASS_SERIES like " + edPaspSer.Text.Replace('*', '%').ToQuote());
            if (edPaspNum.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "PASS_NUMBER like " + edPaspNum.Text.Replace('*', '%').ToQuote());
            if (edKartNum.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "HOMEPHONE like " + edKartNum.Text.Replace('*', '%').ToQuote());
            if (cbSex.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "SEX = " + cbSex.EditValue.ToStr());


            if (cbUchOblast.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "ST_REGION = " + cbUchOblast.EditValue.ToStr());
            if (cbUchRayon.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "ST_RAYON = " + cbUchRayon.EditValue.ToStr());


            if (cbVidUcherejdeniya.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "ST_VIDUCHEREJDENIYA = " + cbVidUcherejdeniya.EditValue.ToStr());
            if (cbUcherejdeniya.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "KOLORLIC = " + cbUcherejdeniya.EditValue.ToStr());
            if (cbNat.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "NATIONALITY = " + cbNat.EditValue.ToStr()); if (cbSemPolojeniya.Text != "")
                val.Add((val.Count > 0 ? " and " : "") + "MARRIED = " + cbSemPolojeniya.EditValue.ToStr());

            if (!edRegDate1.Text.IsEmpty())
                val.Add((val.Count > 0 ? " and " : "") + "createdate >=" + edRegDate1.Text.ToQuote());
            if (!edRegDate2.Text.IsEmpty())
                val.Add((val.Count > 0 ? " and " : "") + "createdate <=" + edRegDate2.Text.ToQuote());

            if (!edTugDate1.Text.IsEmpty())
                val.Add((val.Count > 0 ? " and " : "") + "BIRTHDATE >=" + edTugDate1.Text.ToQuote());
            if (!edTugDate2.Text.IsEmpty())
                val.Add((val.Count > 0 ? " and " : "") + "BIRTHDATE <=" + edTugDate2.Text.ToQuote());


            return (val.Count > 0 ? " Where " : "") + String.Join(Environment.NewLine, val.ToArray());
        }

        private void SetGridViewStyle()
        {
            if (gridViewStyle == "") gridViewStyle = "Banded";

            switch (gridViewStyle)
            {
                case "Banded":
                    gridControl.MainView = grKadrList;
                    break;
                case "Card":
                    gridControl.MainView = grKadrCard;
                    break;
                case "Simple":
                    break;
            }
        }
        private void cbViloyat_EditValueChanged(object sender, EventArgs e)
        {
            cbTuman.Properties.DataSource = DicoDB.SelectSQL(
                string.Format("SELECT ID, NAME{0} NAME FROM {1} WHERE OBL = {2} ORDER BY NAME",
                    Vars.Lang, " sa_rayon ", cbViloyat.EditValue));
        }

        private void cbUchOblast_EditValueChanged(object sender, EventArgs e)
        {
            cbUchRayon.Properties.DataSource = DicoDB.SelectSQL(
                string.Format("SELECT ID, NAME{0} NAME FROM {1} WHERE OBL = {2} ORDER BY NAME",
                    Vars.Lang, " sa_rayon ", cbUchOblast.EditValue));

            cbUcherejdeniya.Properties.DataSource = DicoDB.SelectSQL("select ID, NAME" + Vars.Lang +
                    " as NAME from  SA_KOLLEJ WHERE TURI =" + cbVidUcherejdeniya.EditValue.ToStr() +
                    " and OBL = " + cbUchOblast.EditValue.ToStr());
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var box = new frmKadrUZ(-1, RecordState.rsNew))
            {
                box.ShowDialog(this);
            }
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var r = gridView1.GetFocusedRow() as tbMain;
            if (r != null)
            {
                using (var box = new frmKadrUZ(r.Id, RecordState.rsEdit))
                {
                    box.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show("Жадвалдан белгиланг...", "Хато", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var r = gridView1.GetFocusedRow() as tbMain;
            if (r != null)
            { 
                

            }
        }

        private void btnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var file = CDialog.SaveDialog();
            if (file != "")
                gridView1.ExportToXlsx(file);
        }

        private void btnClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            bsMain.DataSource = null;

            foreach (BaseLayoutItem baseItem in layoutControl1.Items)
            {
                var item = baseItem as LayoutControlItem;
                if (item != null)
                {
                    var ed = item.Control as TextEdit;
                    if (ed != null)
                        ed.EditValue = null;

                    var cb = item.Control as LookUpEdit;
                    if (cb != null)
                        cb.EditValue = null;
                }
            }
        }

        private void OnRowStyle(object sender, RowStyleEventArgs e)
        {
            //var View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    var taqiq = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TAQIQ"]);
            //    var kod = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TB_DOCKIND"]);

            //    var sec = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TB_SEC"]);

            //    //Тақиқ базасида мавжуд
            //    if (taqiq != "")
            //    {
            //        e.Appearance.BackColor = Color.Salmon;
            //        e.Appearance.BackColor2 = Color.WhiteSmoke;
            //    }

            //    //Тайёр
            //    if (kod == "100")
            //    {
            //        e.Appearance.BackColor = Color.LightGreen;
            //        e.Appearance.BackColor2 = Color.WhiteSmoke;
            //    }

            //    //Қидирув базасида мавхум
            //    if (kod == "204")
            //    {
            //        e.Appearance.BackColor = Color.Gold;
            //        e.Appearance.BackColor2 = Color.WhiteSmoke;
            //    }

            //    //Қидирув базасида мавжуд
            //    var dr = ",118,109,";
            //    if (dr.Contains("," + kod + ","))
            //    {
            //        e.Appearance.BackColor = Color.Black;
            //        e.Appearance.BackColor2 = Color.DarkSalmon;
            //        e.Appearance.ForeColor = Color.WhiteSmoke;
            //    }

            //    var ka = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TB_ACTIVE"]);
            //    if (ka == "0")
            //    {
            //        e.Appearance.BackColor = Color.Silver;
            //        e.Appearance.BackColor2 = Color.WhiteSmoke;
            //    }


            //    if (sec=="6")
            //    {
            //        e.Appearance.BackColor = Color.FromArgb(113, 135, 0);
            //        e.Appearance.ForeColor = Color.FromArgb(255,239,193);
            //    }
            //}
        }

        private void frmTexpList_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    if (MessageBox.Show("Бекор қилмоқчимисиз...", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        btnClear.PerformClick();
            //}
            //;

            //if (e.KeyCode == Keys.F6)
            //{
            //    //   FindRecord(1);
            //}

            //if (e.KeyCode == Keys.F6 && e.Modifiers == Keys.Control)
            //{
            //    // FindRecord(2);
            //}
            //;

            //if (e.KeyCode == Keys.F6 && e.Modifiers == Keys.ShiftKey)
            //{
            //    //  FindRecord(3);
            //}
            //;


            //if (e.Control)
            //{
            //    var ki = 0;
            //    if (e.KeyValue >= 49 && e.KeyValue <= 57)
            //        RunButtonInGallety(e.KeyValue - 48);
            //}
        }





        #region NavBarGroup

        private NavBarGroup currentGroup;

        private void navBarControl1_GroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            currentGroup.Expanded = false;

            //navBarControl1.Groups[currentGroupIndex].Expanded = false;
            currentGroup = e.Group;
        }

        private void navBarControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var navBar = sender as NavBarControl;
                var hitInfo = navBar.CalcHitInfo(new Point(e.X, e.Y));
                if (hitInfo.InGroupCaption && !hitInfo.InGroupButton)
                    hitInfo.Group.Expanded = !hitInfo.Group.Expanded;
            }
        }

        #endregion

        #region Frm Static



        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == 8) || (e.KeyValue == 46))
            {
                (sender as TextEdit).EditValue = null;
            }
        }

        private void btnV1_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (GridShowArm)
            {
                case 1:
                    gridControl.MainView = grKadrList;
                    break;
                case 2:
                    gridControl.MainView = grPaspList;
                    break;
            }
            //grTexpSimple.OptionsView.ShowGroupPanel = false;
            gridViewStyle = "Banded";
        }

        private void btnV2_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (GridShowArm)
            {
                case 1:
                    gridControl.MainView = grKadrCard;
                    break;
                case 2:
                    gridControl.MainView = grPaspCard;
                    break;
            }
            //grTexpSimple.OptionsView.ShowGroupPanel = false;
            gridViewStyle = "Card";
        }

        private void btnV3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (GridShowArm == 1)
            {
                gridControl.MainView = grKadrSimple;
                //gridControl.MainView.BestFitColumns();
            }
            gridViewStyle = "Simple";
        }

        private void frmTexpList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OnCloseChildForm != null)
                OnCloseChildForm(this);
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        #endregion

        private void btnClose_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnFindTexpGlobal_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageManager.WaitFormManager.Show();

            dynamic gsql = new System.Dynamic.ExpandoObject();
            gsql.header = @"SELECT ID, ST_VIDUCHEREJDENIYA, KOLORLIC, VID_DOLJNOST, VSEGO_KOL_CHASOV, FIRSTNAME, LASTNAME, PATRONYMIC,
                            BIRTHDATE, ST_REGION, ST_RAYON, REGION_PROPISKA, RAYON_PROPISKA, 
                            COALESCE(QISHLOQ_PROPISKA, '')||' '||COALESCE(KUCHA_PROPISKA, '')||' '||COALESCE(UY_PROPISKA, '')||' '||
                            COALESCE(HONADON_PROPISKA, '' ) MANZIL, T.CREATEDATE, PED_STAJ, DAN_DOLJ_STAJ, OBSHIY_STAJ,
                            DANNIY_OTCH_PERIODE, HOMEPHONE FROM TBMAIN T ";
            gsql.footer = " order by firstname, lastname, patronymic ";

            var sql = gsql.header + Environment.NewLine + GetFindExp() + gsql.footer;

            DataTable dt = DicoDB.SelectSQL(sql);
            //dt.Columns.Add("VIUCH", typeof (string));
            //foreach (var row in dt.Rows)
            //{
            //    row["VIUCH"] =  row[""]
            //}
            

            bsMain.DataSource = dt;
            MessageManager.WaitFormManager.Close();
        }
        #region Obectivka

        private void btnObectivka_ItemClick(object sender, ItemClickEventArgs e)
        {
            var iii = GetSelectedIndex();
            if (iii >= 0)
            {
                var r = GetTexpSelectedRow(iii);
                var id = r["ID"].ToStr().ToQuote();
                ExportToWord("UZ", id);
            }
            else
            {
                MessageBox.Show("Жадвалдан белгиланг...", "Хато", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnObectivkaRU_ItemClick(object sender, ItemClickEventArgs e)
        {
            var iii = GetSelectedIndex();
            if (iii >= 0)
            {
                var r = GetTexpSelectedRow(iii);
                var id = r["ID"].ToStr().ToQuote();
                ExportToWord("RU", id);
            }
            else
            {
                MessageBox.Show("Жадвалдан белгиланг...", "Хато", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportToWord(string lang, string id)
        {
            DataTable dt = DicoDB.SelectSQL("Select * from TBMAIN where ID=" + id);
            if (dt == null) return;

            DataRow r = dt.Rows[0];
            WordApp wa = new WordApp(AppDomain.CurrentDomain.BaseDirectory + "PrintTemplate" + lang + ".dot");
            var fio = r["FIRSTNAME"].ToStr().ToUpperCapital() + " " + r["LASTNAME"].ToStr().ToUpperCapital() + " " + r["PATRONYMIC"].ToStr().ToUpperCapital();
            wa.Replace(":FIO", fio);

            var ia = SaveImgToFile(id);
            wa.InsPicture(ia);
            wa.Replace(":date_info", r["DATA_PRIKAZA"].ToStr());
            wa.Replace(":Info", GetCurrectDoljnost(id, lang));

            wa.Replace(":bdate", r["BIRTHDATE"].ToStr());
            wa.Replace(":bplace", GetTugilganJoy(id, lang, r));
            wa.Replace(":nationality", GetNat(r["NATIONALITY"].ToStr(), lang, r["SEX"].ToStr()));
            wa.Replace(":party", GetParty(r["PARTY"].ToStr(), lang));
            wa.Replace(":education", GetMalumoti(r["EDUCATION"].ToStr(), lang));
            var speciality = "";
            wa.Replace(":graduated", GetUniverTugatgan(id, lang, r, out speciality));
            wa.Replace(":speciality", speciality);

            wa.Replace(":degree", GetIlmiyDaraja(r["SCDEGREE"].ToStr(), lang));
            wa.Replace(":status", GetIlmiyUnvoni(r["SCSTATUS"].ToStr(), lang));

            wa.Replace(":foreign_langs", GetTillar(r["INOST_YAZIK"].ToStr(), lang));
            var unv = "";
            wa.Replace(":HMU_Title", GetHarbiyUnvon(r["ZVANIE"].ToStr(), lang, out unv));
            wa.Replace(":hrb_m_u", unv);

            wa.Replace(":mukofot", GetDavlatMukofat(id, lang));
            wa.Replace(":deputy", GetPartiviy(id, lang));
            wa.Replace(":W_AC", GetTrudovoy(id, lang));
            wa.Replace(":REL_FIO", fio);


            SetQarindoshi(id, lang, wa);

        }

        private void SetQarindoshi(string id, string lang, WordApp wa)
        {
            var dt = DicoDB.SelectSQL(string.Format(@"select 
                                        TBQARINDOSH.LASTNAME,
                                        TBQARINDOSH.FIRSTNAME,
                                        TBQARINDOSH.PATRONYMIC,
                                        TBQARINDOSH.DATAROJ,
                                        TBQARINDOSH.BIRTHCOUNTRY,
                                        TBQARINDOSH.ISHJOYI,
                                        TBQARINDOSH.DEATH,
                                        SA_RODSTVENNIK.NAME{1} ROD,                                        
                                        SA_OBLAST.NAME{1} OBL,                                                                                
                                        SA_RAYON.NAME{1} RAY
                                    from tbqarindosh
                                       left outer join sa_rodstvennik on (tbqarindosh.qarindoshligi = sa_rodstvennik.id)
                                       left outer join sa_oblast on (tbqarindosh.region = sa_oblast.id)
                                       left outer join sa_rayon on (tbqarindosh.rayon = sa_rayon.id)
                                    where 
                                       (
                                          (mainid = {0})
                                       )
                                    order by  sa_rodstvennik.orderindex", id, lang));
            if (dt == null && dt.Rows.Count > 0) return;

            int i = 2;
            wa.TableNewRow(1);
            foreach (DataRow r in dt.Rows)
            {
                wa.TableNewRow(1);
                wa.TableCell(1, i, 1, r["ROD"].ToStr(), 1);
                wa.TableCell(1, i, 2, r["LASTNAME"].ToStr().ToUpperCapital() + " " + r["FIRSTNAME"].ToStr().ToUpperCapital() + " " + r["PATRONYMIC"].ToStr().ToUpperCapital(), 0);
                wa.TableCell(1, i, 3, r["DATAROJ"].ToStr() + (lang == "UZ" ? "йил," : "год,") + " " + r["BIRTHCOUNTRY"].ToStr().ToUpperCapital(), 0);


                if (r["DEATH"].ToStr() == "")
                {
                    wa.TableCell(1, i, 4, r["ISHJOYI"].ToStr().ToUpperCapital(), 0);
                    var s = r["OBL"].ToStr() + ", " + r["RAY"].ToStr();
                    if (s != ", ")
                        wa.TableCell(1, i, 5, s, 0);
                }
                else
                {
                    var s = "";
                    if (lang == "UZ")
                        s = r["DEATH"].ToStr() + " йил вафот этган (" + r["ISHJOYI"].ToStr() + ")";
                    else
                        s = " в " + r["DEATH"].ToStr() + " году (" + r["ISHJOYI"].ToStr() + ")";
                    wa.TableCell(1, i, 4, s, 0);
                    wa.TableMarge(1, i, 4, i, 5);
                }

                i++;
            }
            wa.TableDelRow(1, i);
        }

        private string GetCurrectDoljnost(string id, string lang)
        {
            var dt = DicoDB.SelectSQL("select ISHJOYI, LAVOZIM from tbmestorab  where MAINID = " + id +
                                      "  and(DATE2 is null or DATE2 = '')");
            if (dt == null || dt.Rows.Count == 0) return "";
            return dt.Rows[0]["ISHJOYI"].ToStr().ToUpperCapital() + " " + dt.Rows[0]["LAVOZIM"].ToStr().ToUpperCapital();
        }

        private string GetTrudovoy(string id, string lang)
        {
            var ba = DicoDB.SelectSQL("select * From TBMESTORAB where MAINID =" + id);
            if (ba == null) return (lang == "UZ" ? "йўқ" : "не имеет");

            var res = "";
            var d1 = "";
            var d2 = "";

            foreach (DataRow r in ba.Rows)
            {
                d1 = r["DATE1"].ToStr();
                d2 = r["DATE2"].ToStr();

                res += d1 + (d2 == "" ? (lang == "UZ" ? " й - " : " г - ") : "-") +
                       (d2 == "" ?
                            (lang == "UZ" ? "ҳ.в. - " : " н.в. - ") :
                            d2 + (lang == "UZ" ?
                                                        " йй. - " :
                                                        " гг. - ") +
                        r["ISHJOYI"].ToStr().ToUpperCapital() +" "+ r["LAVOZIM"].ToStr().ToUpperCapital()) + "^p";
            }
            return res;
        }



        private string SetEnter(DataRow r)
        {
            var res = "";
            if (r.Table.Rows.Count > 1)
            {
                if (r.Table.Rows.IndexOf(r) == r.Table.Rows.Count - 1)
                    res = "";
                else
                    res = "|";
            }
            return res.Replace('|', (Char)11);
        }

        private string SetSoftEnter(DataRow r)
        {
            var res = "";
            if (r.Table.Rows.Count > 1)
            {
                if (r.Table.Rows.IndexOf(r) == r.Table.Rows.Count - 1)
                    res = "";
                else
                    res = "|";
            }
            return res.Replace('|', (Char)13);
        }

        private string GetPartiviy(string id, string lang)
        {
            var ba = DicoDB.SelectSQL("select * From TBDEPUTY where MAINID =" + id);
            if (ba == null) return (lang == "UZ" ? "йўқ" : "не является");

            var res = "";

            foreach (DataRow r in ba.Rows)
            {
                res += r["DATE1"].ToStr() + (lang == "UZ" ? "й. - " : "г. - ") +

                       (r["DATE2"].ToStr() == "" ?
                            (lang == "UZ" ? "ҳ.в. - " : "н.в. - ") :
                            r["DATE2"].ToStr() + (lang == "UZ" ?
                                                        "й. - " :
                                                        "г. - ") +
                        r["DEPUTY"].ToStr().ToUpperCapital() + SetSoftEnter(r));
            }


            return res.Replace("#11", "||");
        }

        private string GetDavlatMukofat(string id, string lang)
        {
            var ba = DicoDB.SelectSQL("select * From TBGOSNAGRADI where MAINID =" + id);
            if (ba == null) return (lang == "UZ" ? "йўқ" : "не имеет");

            var res = "";

            foreach (DataRow r in ba.Rows)
            {
                res += r["DATE_GN"].ToStr() + (lang == "UZ" ? " й. " : " г. ") + "\t" +
                    DicoDB.ExecuteScalar("NAMEUZ", "SA_NAGRADA", "ID=" + r["NAZVANIE"].ToStr().ToUpperCapital()) + SetSoftEnter(r);
            }

            return res;
        }

        private string GetHarbiyUnvon(string toStr, string lang, out string unv)
        {
            var ba = DicoDB.SelectSQL("select NAMEUZ, NAMERU From SA_UCHENIY_STEPEN where ID =" + toStr);
            if (ba == null)
            {
                unv = "";
                return "";
            }

            if (lang == "UZ")
            {
                unv = ba.Rows[0]["NAMEUZ"].ToStr().ToUpperCapital();
                return (unv == "" ? "" : "Ҳарбий (махсус) унвони:");
            }
            else
            {
                unv = ba.Rows[0]["NAMERU"].ToStr().ToUpperCapital();
                return (unv == "" ? "" : "Военное (специальное) звание:");
            }
        }

        private string GetTillar(string toStr, string lang)
        {
            //TODO 1
            var ba = DicoDB.SelectSQL("select NAMEUZ, NAMERU from SA_LANGS where id in (" + toStr + ")");
            if (ba == null) return (lang == "UZ" ? "йўқ" : "не имеет");

            if (lang == "UZ")
                return "";// ba. JoinRows("NAMEUZ");
            else
                return "";// ba.JoinRows("NAMERU");
        }

        private string GetIlmiyDaraja(string toStr, string lang)
        {
            if (toStr == "")
            {
                if (lang == "UZ")
                    return "йўқ";
                else
                    return "не имеет";
            }

            var dt = DicoDB.SelectSQL("select NAMEUZ,NAMERU from SA_UCHENIY_STEPEN where ID=" + toStr);
            if (lang == "UZ")
                toStr = dt.Rows[0]["NAMEUZ"].ToStr();
            else
                toStr = dt.Rows[0]["NAMERU"].ToStr();

            return toStr;
        }

        private string GetIlmiyUnvoni(string toStr, string lang)
        {
            if (toStr == "")
            {
                if (lang == "UZ")
                    return "йўқ";
                else
                    return "не имеет";
            }

            var ba = DicoDB.SelectSQL("select NAMEUZ, NAMERU From SA_UCHENIY_STEPEN where ID =" + toStr);
            if (ba == null) return (lang == "UZ" ? "йўқ" : "не имеет");

            if (lang == "UZ")
                return ba.Rows[0]["NAMEUZ"].ToStr();
            else
                return ba.Rows[0]["NAMERU"].ToStr();
        }

        private string GetUniverTugatgan(string id, string lang, DataRow dataRowView, out string speciality)
        {
            var ba = DicoDB.SelectSQL("select * from tbuniver where MAINID=" + id + " order by cast(GOD_VIPUSKA as integer) desc");
            if (ba == null || ba.Rows.Count == 0)
            {
                speciality = (lang == "UZ" ? "йўқ" : "не имеет");
                return (lang == "UZ" ? "йўқ" : "не имеет");
            }

            var t1 = ba.Rows[0]["GOD_VIPUSKA"].ToStr();
            var t2 = ba.Rows[0]["OBRAZOVATELNIY_UCHERJ"].ToStr();
            var t3 = ba.Rows[0]["VID_OBUCHENIYA"].ToStr();
            speciality = ba.Rows[0]["SPECIALNOST_PODIPLOMU"].ToStr();


            if (lang == "UZ")
            {
                var vuz = DicoDB.ExecuteScalar("SELECT NAMEUZ FROM  sa_vuz where id={0}", t2).ToStr();
                var to = DicoDB.ExecuteScalar("SELECT NAMEUZ  FROM  SA_VID_OBUCHENIYA where id={0}", t3).ToStr();

                return t1 + " й. " + vuz + "(" + to + ")";
            }
            else
            {
                var vuz = DicoDB.ExecuteScalar("SELECT NAMERU FROM  sa_vuz where id={0}", t2).ToStr();
                var to = DicoDB.ExecuteScalar("SELECT NAMERU  FROM  SA_VID_OBUCHENIYA where id={0}" , t3).ToStr();

                return t1 + " г. " + vuz + " (" + to + ")";
            }
        }

        private string GetMalumoti(string toStr, string lang)
        {
            if (toStr == "")
            {
                if (lang == "UZ")
                    return "йўқ";
                else
                    return "не имеет";
            }

            var ba = DicoDB.SelectSQL("select NAMEUZ, NAMERU From SA_OBRAZOVANIYA where ID =" + toStr);
            if (ba == null || ba.Rows.Count == 0) return (lang == "UZ" ? "йўқ" : "не имеет");

            if (lang == "UZ")
                return ba.Rows[0]["NAMEUZ"].ToStr();
            else
                return ba.Rows[0]["NAMERU"].ToStr();
        }

        private string GetParty(string toStr, string lang)
        {
            var ba = DicoDB.SelectSQL("select NAMEUZ, NAMERU From SA_PARTIYA where  ID =" + toStr);
            if (ba == null || ba.Rows.Count == 0) return (lang == "UZ" ? "йўқ" : "не имеет");

            if (lang == "UZ")
                return ba.Rows[0]["NAMEUZ"].ToStr();
            else
                return ba.Rows[0]["NAMERU"].ToStr();
        }

        private string GetNat(string toStr, string lang, string sex)
        {
            var ba = DicoDB.SelectSQL("select NAMEUZ, NAMERU From SA_NAT where ID =" + toStr);
            if (ba == null || ba.Rows.Count == 0) return "";


            string[] na;
            if (lang == "UZ")
                na = ba.Rows[0]["NAMEUZ"].ToStr().Split('/');
            else
                na = ba.Rows[0]["NAMERU"].ToStr().Split('/');

            return (sex == "1" ? na[0] : na[1]);
        }

        private string GetTugilganJoy(string id, string lang, DataRow r)
        {
            var bc = r["BIRTHCOUNTRY"].ToStr();
            var br = r["BIRTHREGION"].ToStr();
            var bt = r["BIRTHTOWN"].ToStr();
            var res = "";
            if (bc != "12")
            {
                if (bc == "") return "";
                var ba = DicoDB.SelectSQL("select NAMEUZ, NAMERU From SA_COUNTRY where ID =" + bc);
                if (ba != null || ba.Rows.Count == 0)
                {
                    if (lang == "UZ")
                        return ba.Rows[0]["NAMEUZ"].ToStr();
                    else
                        return ba.Rows[0]["NAMERU"].ToStr();
                }
            }
            else
            {
                if (br == "") return "";
                var btr = DicoDB.SelectSQL("select NAMEUZ, NAMERU From SA_OBLAST where ID =" + br);
                if (btr != null || btr.Rows.Count == 0)
                {
                    if (lang == "UZ")
                        res += btr.Rows[0]["NAMEUZ"].ToStr();
                    else
                        res += btr.Rows[0]["NAMERU"].ToStr();
                }

                if (bt == "") return "";
                var btt = DicoDB.SelectSQL("select NAMEUZ, NAMERU From SA_RAYON where ID =" + bt);
                if (btt != null || btt.Rows.Count == 0)
                {
                    if (lang == "UZ")
                        res += ", " + btt.Rows[0]["NAMEUZ"].ToStr();
                    else
                        res += ", " + btt.Rows[0]["NAMERU"].ToStr();
                }
            }
            return res;
        }

        private string SaveImgToFile(string o)
        {
            var ba = (byte[])DicoDB.ExecuteScalar("select foto from tbfoto  where  MAINID = {0}" , o);
            if (ba != null)
            {
                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "ti.jpg", ba);
                return AppDomain.CurrentDomain.BaseDirectory + "ti.jpg";
            }
            else
                return "";
        }



        #endregion

 
    }
}