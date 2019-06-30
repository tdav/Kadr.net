using System;
using Kadr.Utils;
using DevExpress.XtraWaitForm;

namespace Kadr.UtilsUI
{
    public partial class WaitForm1 : WaitForm
    {
        public enum WaitFormCommand
        {
        }

        public WaitForm1()
        {
            InitializeComponent();
            progressPanel1.AutoHeight = true;

            CLang.Init(this);
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