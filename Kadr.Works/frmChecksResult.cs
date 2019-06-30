using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Kadr.Kadr
{
    public partial class frmChecksResult : XtraForm
    {
        public frmChecksResult()
        {
            InitializeComponent();
        }

        public static void Execute(string id)
        {
            //using (var f = new frmChecksResult())
            //{
            //    f.bsList.DataSource = ClassOnlineWorks.GetProcedureDataTable(new[] {"31", id},
            //        "PVIZA.ASBT_SEARCH.VI_CHECKS");
            //    var sx = "";
            //    f.ShowDialog();
            //}
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChecksResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}