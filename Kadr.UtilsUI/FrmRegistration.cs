using Kadr.Utils;
using System.Windows.Forms;

namespace Kadr.UtilsUI
{
    public partial class FrmRegistration : DevExpress.XtraEditors.XtraForm
    {

        public FrmRegistration()
        {
            InitializeComponent();

            CLang.Init(this);
        }

        public static DialogResult Execute()
        {
            var f = new FrmRegistration();
            return f.ShowDialog();
        }

        private void btnReg_Click(object sender, System.EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
           
                DialogResult = DialogResult.OK;
           

            Close();
        }
    }
}