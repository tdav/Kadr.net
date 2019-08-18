using System.Drawing.Printing;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace Kadr.Template
{
    public partial class rpAllDb : XtraReport
    {
        private readonly string CurId = "";
        private readonly bool IsShoqAll;

        public rpAllDb(BindingSource dt, string curId, bool _isShowAll = false)
        {
            InitializeComponent();

            IsShoqAll = _isShowAll;
            CurId = curId;
            DetailReport.DataSource = dt;
        }

        private void detailBand1_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!IsShoqAll)
                DetailReport.FilterString = "TB_ID = " + CurId;
        }
    }
}