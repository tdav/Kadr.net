using Kadr.Utils;
using System.Windows.Forms;

namespace Kadr.UtilsUI
{
    public partial class MessageBoxDev : DevExpress.XtraEditors.XtraForm
    {
        public MessageBoxDev()
        {
            InitializeComponent();

            CLang.Init(this);
        }

        public static void ShowError(string text, string caption = "Информация")
        {
            var f = new MessageBoxDev();
            f.Text = caption;
            f.piInfo.Visible = false;
            f.labelControl1.Text = text;
            f.btnClose.Text = "Закрыть".ToLang("FrmMain");
            f.btnClose.Width += 30;
            f.btnClose.Left -= 30;
            f.btnSave.Visible = false;
            f.ShowDialog();
        }

        public static void ShowInfo(string text, string caption = "Информация")
        {
            var f = new MessageBoxDev();
            f.Text = caption;
            f.labelControl1.Text = text;
            f.btnClose.Text = "Закрыть".ToLang("FrmMain");
            f.btnClose.Width += 30;
            f.btnClose.Left -= 30;
            f.btnSave.Visible = false;
            f.ShowDialog();
        }

        public static DialogResult ShowDialogError(string text, string caption = "Информация")
        {
            var f = new MessageBoxDev();
            f.Text = caption;
            f.piInfo.Visible = false;
            f.labelControl1.Text = text;
            return f.ShowDialog();
        }

        public static DialogResult ShowDialogInfo(string text, string caption = "Информация")
        {
            var f = new MessageBoxDev();
            f.Text = caption;
            f.labelControl1.Text = text;
            return f.ShowDialog();
        }
    }
}