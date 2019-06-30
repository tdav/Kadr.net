using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.Export;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace Kadr.UtilsUI
{
    public class ExportClass
    {
        public static void ExportGrid(GridView gv)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = @"Excel (2010) (.xlsx)|*.xlsx";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    var options = new XlsxExportOptionsEx();
                    options.UnboundExpressionExportMode = UnboundExpressionExportMode.AsFormula;
                    options.ExportType = ExportType.WYSIWYG;
                    gv.ExportToXlsx(saveDialog.FileName, options);

                    Process.Start(saveDialog.FileName);
                }
            }
        }

        public static void DataTableExportExcel(DataTable dt)
        {

            //Excel.Application objApp;
            //Excel._Workbook objBook;

            //Excel.Workbooks objBooks;
            //Excel.Sheets objSheets;
            //Excel._Worksheet objSheet;
            //Excel.Range range;

            //string[,] sv = new string[50000, 55];
            //int columnCount = dt.Columns.Count;

            //for (int u = 0; u < columnCount; u++)
            //{
            //    sv[0, u] = dt.Columns[u].ColumnName;
            //}


            //int i = 1;
            //try
            //{
            //    foreach (DataRow r in dt.Rows)
            //    {
            //        for (int c = 0; c < columnCount; c++)
            //        {
            //            sv[i, c] = r[c].ToStr();
            //        }

            //        i++;
            //    }
            //}
            //catch (System.Exception ee)
            //{
            //    CLog.Write("DataTableExportExcel  sv[i, c+1] "+ee.GetAllMessages());
            //}

            //try
            //{
            //    objApp = new Excel.Application();
            //    objBooks = objApp.Workbooks;
            //    objBook = objBooks.Add(Missing.Value);
            //    objSheets = objBook.Worksheets;
            //    objSheet = (Excel._Worksheet)objSheets.get_Item(1);

            //    range = objSheet.get_Range("A1", "V" + i.ToStr());
            //    range.set_Value(Missing.Value, sv);
            //    objApp.Visible = true;
            //    objApp.UserControl = true;
            //}
            //catch (System.Exception ee)
            //{
            //    CLog.Write("DataTableExportExcel objApp.Visible = true; "+ee.GetAllMessages());
            //}
        }

    }
}