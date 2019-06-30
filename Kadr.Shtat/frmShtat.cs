using Kadr.Database.Views;

namespace Kadr.Shtat
{
    public partial class frmShtat : DevExpress.XtraEditors.XtraForm
    {
        public frmShtat()
        {
            InitializeComponent();

            cbLovazim.Properties. DataSource = DicoDB.dt_SA_DOLJNOST;
            cbFan.Properties.DataSource = DicoDB.dt_SA_PREDMET;

        }

       
    }
}