using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace Kadr.CommonControls
{
    public class PDateEdit : PTextEdit
    {
        public PDateEdit()
        {
            Properties.Mask.BeepOnError = true;
            Properties.Mask.EditMask = "00/00/0000";
            Properties.Mask.MaskType = MaskType.Simple;
            Properties.MaxLength = 10;
            Properties.ValidateOnEnterKey = true;
            KeyDown += PDateEdit_KeyDown;
            Leave += PDateEdit_Leave;
        }

        public void ConvertDateEdit(TextEdit txt)
        {
            txt.Properties.Mask.BeepOnError = true;
            txt.Properties.Mask.EditMask = "00/00/0000";
            txt.Properties.Mask.MaskType = MaskType.Simple;
            txt.Properties.MaxLength = 10;
            txt.Properties.ValidateOnEnterKey = true;
            txt.KeyDown += PDateEdit_KeyDown;
            txt.Leave += PDateEdit_Leave;
        }

        private void PDateEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                (sender as TextEdit).Text = "";
        }

        private void PDateEdit_Leave(object sender, EventArgs e)
        {
            var ed = sender as TextEdit;
            if (ed.Text != "__.__.____")
            {
                try
                {
                    Convert.ToDateTime(ed.Text);
                }
                catch (Exception )
                {
                    XtraMessageBox.Show("Сана нотуғри киритилган", "Ҳато", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Focus();
                }
            }
        }
    }
}