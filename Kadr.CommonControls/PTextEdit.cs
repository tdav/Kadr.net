using System;
using System.Windows.Forms;
using Apteka.Utils;
using DevExpress.XtraEditors;

namespace Kadr.CommonControls
{
    public class PTextEdit : TextEdit
    {
        public PTextEdit()
        {
            EnterMoveNextControl = true;
            Properties.MaxLength = 250;
            Properties.CharacterCasing = CharacterCasing.Upper;
            Properties.ValidateOnEnterKey = true;
            Enter += PTextEdit_Enter;
        }

        private void PTextEdit_Enter(object sender, EventArgs e)
        {
            SelectAll();
        }
    }

    public class PTextLatinEdit : TextEdit
    {
        public PTextLatinEdit()
        {
            EnterMoveNextControl = true;
            Properties.MaxLength = 75;
            Properties.CharacterCasing = CharacterCasing.Upper;
            Properties.ValidateOnEnterKey = true;
            Enter += PTextLatinEdit_Enter;
            KeyPress += PTextLatinEdit_KeyPress;
        }

        private void PTextLatinEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '"') e.KeyChar = '’';
            if (e.KeyChar == '\'') e.KeyChar = '‘';
            if (e.KeyChar != '\b')
                e.Handled = CTransliter.CheckLetter(e.KeyChar.ToString(), "3");
        }

        private void PTextLatinEdit_Enter(object sender, EventArgs e)
        {
            SelectAll();
            CTransliter.SetLanguage(4);
        }
    }

    public class PTextCirillicEdit : TextEdit
    {
        public PTextCirillicEdit()
        {
            EnterMoveNextControl = true;
            Properties.MaxLength = 75;
            Properties.CharacterCasing = CharacterCasing.Upper;
            Properties.ValidateOnEnterKey = true;
            Enter += PTextCirillicEdit_Enter;
            KeyPress += PTextCirillicEdit_KeyPress;
        }

        private void PTextCirillicEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (e.KeyChar == 'Ғ')
                {
                    e.KeyChar = '-';
                    e.Handled = false;
                }
                else
                    e.Handled = CTransliter.CheckLetter(e.KeyChar.ToString(), "0");
            }
        }

        private void PTextCirillicEdit_Enter(object sender, EventArgs e)
        {
            SelectAll();
            CTransliter.SetLanguage(0);
        }
    }
}