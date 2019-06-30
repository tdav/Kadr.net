using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Kadr.Users;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Apteka.Utils;
using Kadr.GlobalVars;

namespace App
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var cl = Environment.GetCommandLineArgs();
            if (cl.Length > 1)
                if (cl[1] == "debug")
                    Vars.IsDebug = true;

            if (Environment.OSVersion.Version > Version.Parse("6.1.0.0"))
            {
                WindowsFormsSettings.ForceDirectXPaint();
                WindowsFormsSettings.EnableFormSkins();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            BonusSkins.Register();


            if (args.Length > 0)
                Vars.IsDebug = args[0] == "debug";

            var cc = new CultureInfo("ru-RU");
            // var cl = new CultureInfo("uz-Cyrl-UZ");
            Thread.CurrentThread.CurrentCulture = cc;
            Thread.CurrentThread.CurrentUICulture = cc;

            bool res = true;

            if (res && FrmLogin.Execute() == DialogResult.OK)
            {
                Application.Run(new frmMain());
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ee = e.ExceptionObject as Exception;
            var li = new LogItem
            {
                App = "Admin",
                Stacktrace = ee.GetStackTrace(5),
                Message = ee.GetAllMessages(),
                Method = "Program.CurrentDomain_UnhandledException"
            };
            CLogJson.Write(li);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ee = e.Exception;
            var li = new LogItem
            {
                App = "Admin",
                Stacktrace = ee.GetStackTrace(5),
                Message = ee.GetAllMessages(),
                Method = "Program.Application_ThreadException"
            };
            CLogJson.Write(li);
        }
    }
}