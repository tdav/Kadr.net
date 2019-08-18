using System.Windows.Forms;

namespace Apteka.Utils
{
    public class CDialog
    {
        public static string SaveDialog(string filter= @"Excel файл (.xlsx)|*.xlsx")
        {
            using (var sd = new SaveFileDialog())
            {
                sd.Filter = filter;
                if (sd.ShowDialog() != DialogResult.Cancel)
                {
                    return sd.FileName;
                }
            }
            return "";
        }

        public static string OpenDialog(string filter = @"Excel файл (.xls)|*.xls")
        {
            using (var od = new OpenFileDialog())
            {
                od.Filter = filter;
                if (od.ShowDialog() != DialogResult.Cancel)
                {
                    return od.FileName;
                }
            }
            return "";
        }
    }
}
