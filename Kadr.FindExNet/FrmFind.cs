using Apteka.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraTab;
using Kadr.Database.Views;
using Kadr.GlobalVars;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kadr.FindExNet
{
    public partial class FrmFind : RibbonForm
    {
        public delegate void DelegateOnCloseChildForm(object sender);

        private DataTable dtDBSTRUCT;
        private SerListExportFields ExportFields;
        private string OldSql = "";
        public string SqlJoin = "dbo.%s ON dbo.tbMain.ID = dbo.%s.MainID INNER JOIN";
        public string SqlTexp = @"select * from VI_TEXP  ";
        public string SqlTexpCount = @"select count(TB_ID) from vi_texp ";

        public FrmFind()
        {
            InitializeComponent();

            ExportFields = SerListExportFields.Load();
        }

        public event DelegateOnCloseChildForm OnCloseChildForm;

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmFind_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ExportFields != null)
                ExportFields.Save();

            if (OnCloseChildForm != null)
                OnCloseChildForm(this);
        }

        public string LoadSpr(string sp, int kod)
        {
           

            return DicoDB.ExecuteScalar("SP_NAME" + Vars.Lang, sp, "SP_ID=" + kod.ToStr()).ToStr();
        }



        public DataTable LoadSprSql(string sp, string id, string fname, string ord)
        {
            return DicoDB.SelectSQL(String.Format("SELECT {0}, {0}||' '||{1} AS {1} FROM  {2} ORDER BY {3}", id, fname, sp, ord));
        }

        public DataTable LoadSpr(string sp, string displayF = "")
        {
            DataTable dt = null;
            if (displayF == "")
            {
                dt = DicoDB.SelectSQL("SELECT * FROM  " + sp);
            }
            else
            {
                dt = DicoDB.SelectSQL("SELECT * FROM  " + sp + " ORDER BY " + displayF);
            }
            return dt;
        }

        public DataTable GetLsOperator(int id)
        {
            return DicoDB.SelectSQL(@"SELECT VAL, NAMEUZ  From sp_Operator  E Where  E.mainid = " + id.ToStr());
        }

        public DataTable GetDbStruct()
        {
            return DicoDB.SelectSQL("SELECT * FROM DBSTRUCT ORDER BY SORT");
        }

        public DataTable GetDbStruct(string fieldName)
        {
            return DicoDB.SelectSQL("SELECT *  from DBSTRUCT E Where  E.FIELDNAME= " + fieldName.ToQuote());
        }

        public string GetOperatorToValue(string s)
        {
            if (String.IsNullOrEmpty(s)) return "";
            return DicoDB.ExecuteScalar("SELECT NAMEUZ from sp_Operator E Where  E.VAL = {0}", s.ToQuote()).ToStr();
        }

        private void gridViewIfoda_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.FieldName == "OPERAT")
            {
                e.DisplayText = GetOperatorToValue(e.Value.ToString());
            }

            if (e.Column.FieldName == "VAL")
            {
                e.DisplayText = e.Value.ToString();
            }
        }

        private void gridViewIfoda_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            try
            {
                var i = e.RowHandle;
                if (i == 0) return;

                var r1 = gridViewIfoda.GetRowCellValue(i, "OPERAT").ToString();
                var r2 = gridViewIfoda.GetRowCellValue(i, "VAL").ToString();

                if (!((r1 == "" && r2 == "") || (r1 != "" && r2 != "")))
                    e.Appearance.BackColor = Color.DarkOrange;
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }

        private void frmFind_Shown(object sender, EventArgs e)
        {
            dtDBSTRUCT = GetDbStruct();
            bsList.DataSource = dtDBSTRUCT;
            SetColumnsGridViewResult();
        }

        private void SetColumnsGridViewResult()
        {
            if (ExportFields == null) return;

            gridViewResult.Columns.Clear();
            foreach (var item in ExportFields)
            {
                if (item.Visible)
                {
                    var gc = new GridColumn
                    {
                        FieldName = item.FieldName,
                        Caption = item.DisplayName,
                        Visible = true
                    };


                    /*
                    DataTable ls = GetDbStruct(item.FieldName);
                    if (ls != null)
                        if (ls.Rows.Count > 0 && ls.Rows[0]["SPTTABLE"].ToStr() != "")
                        {
                            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                            lu.DataSource = LoadSpr(ls.Rows[0]["SPTTABLE"].ToStr());
                            lu.DisplayMember = ls.Rows[0]["SPTLIST"].ToStr();
                            lu.ValueMember = ls.Rows[0]["SPTKOD"].ToStr();

                            gc.ColumnEdit = lu;

                            //var pf =  pivotGridControl1.Fields.GetFieldByName("pg"+ls[0].FIELDNAME);
                            //if (pf != null)
                            //    pf.FieldEdit = lu;

                        }
                    
                     */

                    gridViewResult.Columns.Add(gc);
                }
            }
        }

        private void gridViewIfoda_ShowingEditor(object sender, CancelEventArgs e)
        {
            var rind = gridViewIfoda.GetSelectedRows()[0];
            var fieldType = gridViewIfoda.GetRowCellValue(rind, "FIELDTYPE").ToInt();
            var fieldOperator = gridViewIfoda.GetRowCellValue(rind, "OPERAT").ToString();
            var fieldValue = gridViewIfoda.GetRowCellValue(rind, "VAL").ToString();

            cbOperator.DataSource = GetLsOperator(fieldType);
            grColResult.ColumnEdit = null;

            switch (fieldType)
            {
                /*
                case 3:  //date
                    if (fieldOperator != "BETWEEN" && fieldOperator != "IN" && fieldOperator != "NOT IN")
                        grColResult.ColumnEdit = cbResultDateEdit;
                    break;
                  */
                case 4: //int

                    var SPTTABLE = gridViewIfoda.GetRowCellValue(rind, "SPTTABLE").ToString();
                    var SPTLIST = gridViewIfoda.GetRowCellValue(rind, "SPTLIST").ToString();
                    var SPTKOD = gridViewIfoda.GetRowCellValue(rind, "SPTKOD").ToString();

                    if (fieldOperator == "IN" || fieldOperator == "NOT IN")
                    {
                        cbResultCheckBox.DataSource = LoadSprSql(SPTTABLE, SPTKOD, SPTLIST, SPTLIST);
                        //cbResultCheckBox.DataSource = LoadSpr(SPTTABLE, (SPTTABLE == "SP_DISTRICT" ? " SP_NAME00 " : ""));
                        cbResultCheckBox.DisplayMember = SPTLIST;
                        cbResultCheckBox.ValueMember = SPTKOD;
                        grColResult.ColumnEdit = cbResultCheckBox;
                    }
                    else
                    {
                        cbResultComboBox.DataSource = LoadSpr(SPTTABLE, (SPTTABLE == "SP_DISTRICT" ? " SP_NAME00 " : ""));
                        cbResultComboBox.Columns[1].FieldName = SPTLIST;
                        cbResultComboBox.DisplayMember = SPTLIST;
                        cbResultComboBox.Columns[0].FieldName = SPTKOD;
                        cbResultComboBox.ValueMember = SPTKOD;
                        grColResult.ColumnEdit = cbResultComboBox;
                    }
                    break;
            }
        }

        public string GetSql()
        {
            var sql = new StringBuilder();

            for (var i = 0; i < gridViewIfoda.RowCount; i++)
            {
                var fieldType = gridViewIfoda.GetRowCellValue(i, "FIELDTYPE").ToInt();
                var rf = gridViewIfoda.GetRowCellValue(i, "FIELDNAME").ToString();
                var ro = gridViewIfoda.GetRowCellValue(i, "OPERAT").ToString();
                var rv = gridViewIfoda.GetRowCellValue(i, "VAL").ToString();

                if (ro == "" || rv == "") continue;

                switch (ro)
                {
                    case "BETWEEN":
                        rv = RelBetweenChar(fieldType, rv);
                        break;

                    case "IN":
                    case "NOT IN":
                        if (fieldType != 5)
                        {
                            if (fieldType == 2)
                                rv = RelInString(rv);
                            else if (fieldType == 3)
                                rv = RelInDateTime(rv);
                            else
                                rv = "(" + rv + ")";
                        }
                        break;

                    default:
                        switch (fieldType)
                        {
                            // 1 : rv := psGrid.Cells[3, ARow];
                            case 2:
                                rv = RelLikeChar(ro, rv).ToQuote();
                                break;
                            case 3:
                                if (ro != "BETWEEN")
                                    rv = rv.ToOracleDate();
                                break;
                        }
                        break;
                }

                sql.Append((sql.Length != 0 ? " AND " : "") + "(" + rf + " " + ro + " " + rv + ")" + Environment.NewLine);
            }

            return sql.ToString();
        }

        private string RelInDateTime(string rv)
        {
            var x = "";
            var sl = rv.Split(',');
            for (var i = 0; i < sl.Length; i++)
            {
                x = x + (i != 0 ? "," : "") + sl[i].ToOracleDate();
            }
            return "(" + x + ")";
        }

        private string RelLikeChar(string o, string S)
        {
            string x;
            if (o != "LIKE")
                return S;

            x = S.Replace('*', '%');
            x = x.Replace('?', '_');

            if ((x.IndexOf('_') == -1) && (x.IndexOf('%') == -1))
                x = x + '%';

            return x;
        }

        private string RelInString(string rv)
        {
            var sl = rv.Split(',');
            var res = new StringBuilder();
            for (var i = 0; i < sl.Length; i++)
            {
                if (sl[i] != "")
                    res.Append((res.Length != 0 ? " , " : "") + sl[i].Trim().ToQuote());
            }
            return "( " + res + " )";
        }

        private string RelBetweenChar(int t, string s)
        {
            string x;
            var sl = s.Split(',');
            if (t == 3)
                x = sl[0].Trim().ToOracleDate(1) + " AND " + sl[1].Trim().ToOracleDate(2);
            else
                x = sl[0].Trim() + " AND " + sl[1].Trim();
            return x;
        }

        private void btnSqlEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmSqlEdit(this);

            if (OldSql != "")
            {
                if (MessageBox.Show("Олдиги ўзгартирилган шартларни керакми?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    f.edSql.Text = OldSql;
                }
                else
                {
                    f.edSql.Text = GetSql();
                }
            }
            else
            {
                f.edSql.Text = GetSql();
            }


            f.Icon = Icon;
            f.ShowDialog();
            OldSql = f.edSql.Text;
            f.Dispose();
        }

        private void btnColList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmColEdit();
            f.gridCol.DataSource = ExportFields;
            if (f.ShowDialog() == DialogResult.OK)
            {
                ExportFields = f.gridCol.DataSource as SerListExportFields;
                SetColumnsGridViewResult();
            };
            f.Dispose();
        }

        private void btnRun_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sqlW = GetSql();
            if (sqlW == "")
            {
                MessageBox.Show("Шартлар кўрсатилмаган...");
                return;
            }

            sqlW = SqlTexp + " WHERE tb_active<>9 and " + Environment.NewLine + sqlW;

            var val = new string[2];
            val[0] = sqlW;
          //  bsRes.DataSource = ClassOnlineWorks.GetProcedureDataTable(val, "TEXP.FORM_WORKS.RemoteSqlExec");
            TabControl.SelectedTabPageIndex = 1;
        }

        private void btnRunCount_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sqlW = GetSql();
            if (sqlW == "")
            {
                MessageBox.Show("Шартлар кўрсатилмаган...");
                return;
            }

            sqlW = SqlTexpCount + " WHERE tb_active<>9 and " + Environment.NewLine + sqlW;

            var val = new string[2];
            val[0] = sqlW;
          //  var dt = ClassOnlineWorks.GetProcedureDataTable(val, "TEXP.FORM_WORKS.RemoteSqlExec_Count");
         //   MessageBox.Show("Қидирув натижаси " + dt.Rows[0][0].ToStr() + " та", "", MessageBoxButtons.OK,                MessageBoxIcon.Asterisk);
        }

        private void btnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sd = new SaveFileDialog();
            sd.DefaultExt = "xls";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                if (TabControl.SelectedTabPageIndex == 1)
                    gridViewResult.ExportToXls(sd.FileName);
                if (TabControl.SelectedTabPageIndex == 2)
                    pgcReport.ExportToXls(sd.FileName);
            }
            sd.Dispose();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            pgcReport.ShowRibbonPrintPreview();
        }

        private void btnClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (var i = 0; i < gridViewIfoda.RowCount; i++)
            {
                gridViewIfoda.SetRowCellValue(i, "OPERAT", "");
                gridViewIfoda.SetRowCellValue(i, "VAL", "");
            }
        }

        private void pivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
        {
            //if (e.Field != null)
            //    if (e.Field.Tag != null)
            //        if (e.Value != null)
            //            if (e.Value.ToString().Trim() != "")
            //            {
            //                int kod = (e.Value != null ? e.Value.ToInt() : -1);
            //                string sp = e.Field.Tag.ToString();
            //                e.DisplayText = LoadSpr(sp, kod).ToString();
            //            }
        }

        private void TabControl_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tpGrid)
            {
                gridViewIfoda.ShowingEditor += gridViewIfoda_ShowingEditor;
                gridViewIfoda.CustomColumnDisplayText += gridViewIfoda_CustomColumnDisplayText;
                gridViewIfoda.CustomDrawCell += gridViewIfoda_CustomDrawCell;
            }
            else
            {
                gridViewIfoda.ShowingEditor -= gridViewIfoda_ShowingEditor;
                gridViewIfoda.CustomColumnDisplayText -= gridViewIfoda_CustomColumnDisplayText;
                gridViewIfoda.CustomDrawCell -= gridViewIfoda_CustomDrawCell;
            }
        }
    }
}