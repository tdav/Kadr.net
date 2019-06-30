using System;
using System.Windows.Forms;
using Apteka.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace Kadr.CommonControls
{
    public class PDateBirthEdit : PTextEdit
    {
        public PDateBirthEdit()
        {
            Properties.Mask.BeepOnError = true;
            Properties.Mask.EditMask = "AA/AA/0000";
            Properties.Mask.MaskType = MaskType.Simple;
            Properties.MaxLength = 10;
            Properties.ValidateOnEnterKey = true;
            KeyDown += PDateBirthEdit_KeyDown;
            KeyPress += PDateBirthEdit_KeyPress;
            Leave += PDateBirthEdit_Leave;
        }

        public void ConvertPDateBirthEdit(TextEdit txt)
        {
            txt.Properties.Mask.BeepOnError = true;
            txt.Properties.Mask.EditMask = "AA/AA/0000";
            txt.Properties.Mask.MaskType = MaskType.Simple;
            txt.Properties.MaxLength = 10;
            txt.Properties.ValidateOnEnterKey = true;
            txt.KeyDown += PDateBirthEdit_KeyDown;
            txt.KeyPress += PDateBirthEdit_KeyPress;
            txt.Leave += PDateBirthEdit_Leave;
        }

        private void PDateBirthEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                (sender as TextEdit).Text = "";
        }

        private void PDateBirthEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
                e.KeyChar = CTransliter.CheckX(e.KeyChar);
        }

        private void PDateBirthEdit_Leave(object sender, EventArgs e)
        {
            var ed = sender as TextEdit;
            if (ed.Text != "__.__.____")
            {
                try
                {
                    Convert.ToDateTime(ed.Text.Replace("XX.XX", "01.01"));
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