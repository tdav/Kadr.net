using System;
using DevExpress.XtraSplashScreen;
using Kadr.GlobalVars;

namespace App
{
    public partial class SplashScreen1 : SplashScreen
    {
        public SplashScreen1()
        {
            InitializeComponent();

            labelControl1.Text = "Technologic ASBT 1994-" + DateTime.Now.ToString("yyyy");
            labelControl2.Text = "Версия " + Vars.Version;
        }

        #region Overrides

        //public override void ProcessCommand(Enum cmd, object arg)
        //{
        //    var command = (SplashScreenCommand) cmd;
        //    switch (command)
        //    {
        //        case SplashScreenCommand.sscFrm:
        //            break;
        //        case SplashScreenCommand.sscSp:
        //            lbStatus.Text = "Қўшимча рўйхатлар";
        //            break;
        //        case SplashScreenCommand.sscReports:
        //            lbStatus.Text = "Ҳисоботлар сервердан юкланмоқда";
        //            break;
        //        case SplashScreenCommand.sscSetup:
        //            lbStatus.Text = "Система парамертлари";
        //            break;
        //        case SplashScreenCommand.sscPing:
        //            lbStatus.Text = "Алоқани текшириш";
        //            break;
        //        case SplashScreenCommand.sscLoadPlugin:
        //            lbStatus.Text = "Қўшимча ҳисоболар";
        //            break;
        //        default:
        //            break;
        //    }
        //    base.ProcessCommand(cmd, arg);
        //}

        #endregion
    }
}