using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Kadr.FindExNet
{
    public partial class FrmSqlEdit : XtraForm
    {
        private readonly FrmFind mainform;

        public FrmSqlEdit(FrmFind f)
        {
            InitializeComponent();
            mainform = f;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var sqlW = edSql.Text;
            if (sqlW == "")
            {
                MessageBox.Show("Шартлар кўрсатилмаган...");
                return;
            }

            sqlW = mainform.SqlTexp + " WHERE " + Environment.NewLine + sqlW;

            var val = new string[2];
            val[0] = sqlW;

            Close();

           // mainform.bsRes.DataSource = ClassOnlineWorks.GetProcedureDataTable(val, "TEXP.FORM_WORKS.RemoteSqlExec");
          //  mainform.TabControl.SelectedTabPageIndex = 1;
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            var sqlW = edSql.Text;
            if (sqlW == "")
            {
                MessageBox.Show("Шартлар кўрсатилмаган...");
                return;
            }

            sqlW = mainform.SqlTexp + " WHERE " + Environment.NewLine + sqlW;    

            var val = new string[2];
            val[0] = sqlW;
           // var dt = ClassOnlineWorks.GetProcedureDataTable(val, "TEXP.FORM_WORKS.RemoteSqlExec_Count");
          //  MessageBox.Show("Қидирув натижаси " + dt.Rows[0][0].ToStr() + " та", "", MessageBoxButtons.OK,        MessageBoxIcon.Asterisk);
        }
    }
}