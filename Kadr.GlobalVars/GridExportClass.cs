using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace Kadr.MessageManager
{
    public class GridExportClass
    {
        public static void ExportGrid(GridControl gridControl)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = @"Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx
                                      |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf 
                                      |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    var exportFilePath = saveDialog.FileName;
                    var fileExtenstion = new FileInfo(exportFilePath).Extension;
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridControl.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridControl.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridControl.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridControl.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridControl.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridControl.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    Process.Start(exportFilePath);
                }
            }
        }
    }
}