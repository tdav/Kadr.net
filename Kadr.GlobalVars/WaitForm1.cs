using System;
using DevExpress.XtraWaitForm;
using Kadr.GlobalVars;

namespace Kadr.MessageManager
{
    public partial class frmWait : WaitForm
    {
        public enum WaitFormCommand
        {
        }

        public frmWait()
        {
            InitializeComponent();
            progressPanel1.AutoHeight = true;
            progressPanel1.Description = (Vars.IsSendData
                ? "Серверга маълумот жўнатилмоқда..."
                : "Сервердан маълумотлар юкланмоқда...");
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel1.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel1.Description = description;
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion
    }
}