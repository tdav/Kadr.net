using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Kadr.CommonControls;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Apteka.Utils;
using Kadr.Database.Views;

namespace Kadr.Reports
{
    public partial class FrmRdmReport : RibbonForm
    {
        public delegate void DelegateOnCloseChildForm(object sender);

        private readonly Args args;
        private readonly string ProcedureName;

        public FrmRdmReport(string p)
        {
            InitializeComponent();

            if (p == "")
            {
                MessageBox.Show("Аргументларда хато");
            }
            else
            {
                var pp = p.Split('@');
                ProcedureName = pp[0];
                args = new Args(pp[1]);
                Text = pp[2];

                InitReportParam();
            }
        }

        public event DelegateOnCloseChildForm OnCloseChildForm;

        private void FrmRdmReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnCloseChildForm != null)
                OnCloseChildForm(sender);
        }

        private void btnCloseOnClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        public string GetSpName(string s)
        {
            switch (s)
            {
                case "ST_AUTOTYPE":
                    return "Тв тури";
                case "SP_COUNTRY":
                    return "Давлат";
                case "ST_COLOR":
                    return "Умимий ранги";
                case "ST_JARAYON":
                    return "Жараён";
                case "ST_KUZOV":
                    return "Кузов тури";
                case "ST_DOCTYPE":
                    return "Сўровнома холати";
                case "ST_MODEL":
                    return "Тв русими";
                case "SP_REGION":
                    return "Вилоят";
                case "SP_SEX":
                    return "Жинси";
                case "ST_SUBCOLOR":
                    return "Ранги";
                case "ST_YOQILGI":
                    return "Ёқилғи";
                case "ST_ORGTYPE":
                    return "Корхона тури";
                case "SP_DOCTYPE":
                    return "Хужжат тури";
                case "ST_MARKA":
                    return "Тв марка";
                case "ST_DIVISION":
                    return "РИБ/ТРИБ";
                case "ST_TRUST":
                    return "Ишончнома тури";
                case "ST_DOCKIND":
                    return "Эгалик хужжати";
                case "ST_PROIZVOD":
                    return "Ишлаб чиқарилган жой";
                case "ST_ACTIVE":
                    return "Тегишлилиги";
                case "ST_TOLOV_MAQSADI":
                    return "Тўлов мақсади";
            }
            return "";
        }

        public void InitReportParam()
        {
            layoutControl1.Clear();
            foreach (var item in args.aItem)
            {
                switch (item.Type)
                {
                    case "SP":
                        if (item.Name == "ST_DIVISION")
                        {
                            #region Grid init

                            var gcDivision = new GridControl();
                            var gvDivision = new GridView();
                            var gridColumn1 = new GridColumn();
                            var gridColumn2 = new GridColumn();
                            var gridColumn3 = new GridColumn();

                            gcDivision.Cursor = Cursors.Default;
                            gcDivision.MainView = gvDivision;
                            gcDivision.Name = item.Name;
                            gcDivision.ViewCollection.AddRange(new BaseView[] {gvDivision});
                            // 
                            // gvDivision
                            // 
                            gvDivision.Columns.AddRange(new[] {gridColumn1, gridColumn2, gridColumn3});
                            gvDivision.GridControl = gcDivision;
                            gvDivision.GroupCount = 1;
                            gvDivision.GroupFormat = "{1} {2}";
                            gvDivision.Name = "gvDivision";
                            gvDivision.OptionsBehavior.Editable = false;
                            gvDivision.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
                            gvDivision.OptionsSelection.MultiSelect = true;
                            gvDivision.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                            gvDivision.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True;
                            gvDivision.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DefaultBoolean.True;
                            gvDivision.OptionsView.ShowGroupPanel = false;
                            gvDivision.SortInfo.AddRange(new[]
                            {new GridColumnSortInfo(gridColumn2, ColumnSortOrder.Ascending)});
                            // 
                            // gridColumn1
                            // 
                            gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
                            gridColumn1.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridColumn1.Caption = "Код";
                            gridColumn1.FieldName = "SPID";
                            gridColumn1.Fixed = FixedStyle.Left;
                            gridColumn1.Name = "gridColumn1";
                            gridColumn1.Visible = true;
                            gridColumn1.VisibleIndex = 1;
                            gridColumn1.Width = 55;
                            // 
                            // gridColumn2
                            // 
                            gridColumn2.Caption = "Туман";
                            gridColumn2.FieldName = "SPREGION";
                            gridColumn2.Name = "gridColumn2";
                            gridColumn2.Visible = true;
                            gridColumn2.VisibleIndex = 1;
                            // 
                            // gridColumn3
                            // 
                            gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
                            gridColumn3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridColumn3.Caption = "Бўлинма";
                            gridColumn3.FieldName = "SPNAME";
                            gridColumn3.Name = "gridColumn3";
                            gridColumn3.Visible = true;
                            gridColumn3.VisibleIndex = 2;
                            gridColumn3.Width = 146;

                            #endregion

                            gcDivision.DataSource =
                                DicoDB.SelectSQL(
                                    @"SELECT d.SP_ID SPID, d.sp_name1 SPNAME, d.SP_TYPE SPLEVEL, r.sp_name00 SPREGION 
                                                                        FROM ST_DIVISION d, SP_REGION r WHERE d.sp_divarea=r.SP_ID AND d.SP_ACTIVE=1");

                            layoutControl1.AddItem(GetSpName(item.Name), gcDivision).TextLocation = Locations.Top;
                        }
                        else
                        {
                            var pField = new PComboBox();
                            pField.Parent = this;
                            pField.Name = item.Name;
                            pField.Properties.Columns.AddRange(new[]
                            {
                                new LookUpColumnInfo("SPID", "Код", 20, FormatType.None, "", false,
                                    HorzAlignment.Default),
                                new LookUpColumnInfo("SPNAME", "Номланиши")
                            });
                            pField.Properties.ValueMember = "SPID";
                            pField.Properties.DisplayMember = "SPNAME";
                            pField.StyleController = layoutControl1;
                            pField.Properties.DataSource = DicoDB.GetDicoAll(item.Name);
                            layoutControl1.AddItem(GetSpName(item.Name), pField);
                        }
                        break;

                    case "DATE":
                        var pDate = new PDateEdit();
                        pDate.Parent = this;
                        pDate.Name = item.Name;
                        pDate.StyleController = layoutControl1;
                        layoutControl1.AddItem(item.Name, pDate);
                        break;

                    case "NUMBER":
                        var pNumber = new PNumberEdit();
                        pNumber.Parent = this;
                        pNumber.Name = item.Name;
                        pNumber.StyleController = layoutControl1;
                        layoutControl1.AddItem(item.Name, pNumber);
                        break;

                    case "VARCHAR":
                        var ed = new PTextEdit();
                        ed.Parent = this;
                        ed.Name = item.Name;
                        ed.StyleController = layoutControl1;
                        layoutControl1.AddItem(item.Name, ed);
                        break;
                }
            }
        }

        private string GetDivisions(GridView inView)
        {
            var result = string.Empty;
            foreach (var item in inView.GetSelectedRows())
            {
                if (!result.Contains(inView.GetDataRow(item)["SPID"].ToStr() + ","))
                    result += inView.GetDataRow(item)["SPID"].ToStr() + ",";
            }
            return result.TrimEnd(',');
        }

        private List<string> GetParams()
        {
            var par = new List<string>();
            foreach (var item in args.aItem)
            {
                switch (item.Type)
                {
                    case "SP":
                        if (item.Name == "ST_DIVISION")
                        {
                            var gc = (layoutControl1.GetControlByName(item.Name) as GridControl);
                            var gv = gc.DefaultView as GridView;

                            var Divs = GetDivisions(gv);
                            if (Divs == "")
                            {
                                XtraMessageBox.Show("Бўлинма танланмаган", "Ҳато", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return null;
                            }
                            par.Add(Divs);
                        }
                        else
                            par.Add((layoutControl1.GetControlByName(item.Name) as PComboBox).EditValue.ToStr());
                        break;
                    default:
                        par.Add((layoutControl1.GetControlByName(item.Name) as PTextEdit).Text.Replace("__.__.____", ""));
                        break;
                }
            }
            par.Add("");
            return par;
        }

        private void btnRunOnClick(object sender, ItemClickEventArgs e)
        {
            var dBegin = DateTime.Now;
            var Params = GetParams();
            if (Params == null) return;
            var dtReport = new DataTable();
            dtReport = ClassOnlineWorks.GetProcedureDataTable(Params.ToArray(), ProcedureName);
            if (dtReport != null)
            {
                gcReport.DataSource = dtReport;
            }
            else
            {
                MessageBox.Show("Маълумот йўқ...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExcelOnClick(object sender, ItemClickEventArgs e)
        {
            if (saveFileExcel.ShowDialog(this) == DialogResult.OK)
                gcReport.ExportToXls(saveFileExcel.FileName);
        }
    }
}