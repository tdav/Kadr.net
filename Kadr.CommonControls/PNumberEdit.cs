using System;
using System.Windows.Forms;
using Apteka.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace Kadr.CommonControls
{
    public class PPinppEdit : PTextEdit
    {
        public PPinppEdit()
        {
            KeyPress += PPinppEdit_KeyPress;
            Leave += PPinppEdit_Leave;
            Properties.MaxLength = 14;
        }

        private void PPinppEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
                e.Handled = CTransliter.CheckNumber(e.KeyChar);
        }

        private void PPinppEdit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Text))
                if ((sender as PTextEdit).Text.Length != 14)
                {
                    XtraMessageBox.Show("Шахсий рақам 14-та сондан иборат бўлиши керак", "Ҳато", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Focus();
                }
                else if (!("1,2,3,4".Contains((sender as PTextEdit).Text[0] + ",")))
                {
                    XtraMessageBox.Show("Шахсий рақамдаги биринчи сон 1,2,3 ёки 4 дан иборат бўлиши керак", "Ҳато",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Focus();
                }
        }
    }

    public class PNumberEdit : PTextEdit
    {
        public PNumberEdit()
        {
            KeyPress += PNumberEdit_KeyPress;
            Properties.MaxLength = 12;
        }

        private void PNumberEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = CTransliter.CheckNumber(e.KeyChar);
            }
        }
    }

    public class PCurrencyEdit : PTextEdit
    {
        public PCurrencyEdit()
        {
            KeyPress += PCurrencyEditEdit_KeyPress;
            Properties.Mask.EditMask = "n";
            Properties.Mask.MaskType = MaskType.Numeric;
            Properties.Mask.UseMaskAsDisplayFormat = true;
            Properties.MaxLength = 12;
        }

        private void PCurrencyEditEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = CTransliter.CheckNumber(e.KeyChar);
            }
        }
    }
}