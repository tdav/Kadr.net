using System;
using DevExpress.XtraEditors;

namespace Kadr.Kadr
{
    public partial class frmFoto : XtraForm
    {
        public frmFoto()
        {
            InitializeComponent();
        }

        private void pictureEdit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}