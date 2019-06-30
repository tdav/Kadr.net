using System;
using System.Drawing;
using Kadr.Utils;
using Kadr.UtilsUI.Properties;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraSplashScreen;

namespace Kadr.UtilsUI
{
    public class WaitFormManager
    {
        public static void Show()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof (WaitForm1));
            }
            catch (Exception)
            {
            }
        }

        public static void Close()
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch (Exception)
            {
            }
        }
    }

    public class AlertMessage
    {
        private static bool IsShowing = false;

        public static void ShowError(string mes)
        {
            using (var box = new AlertControl())
            {                
                var ai = new AlertInfo("Ошибка".ToLang("All"), mes, Resources.error);
                box.AutoFormDelay = 3000;
                box.AllowHotTrack = false;
                box.FormDisplaySpeed = AlertFormDisplaySpeed.Slow;
                box.FormLocation = AlertFormLocation.BottomRight;
                box.AutoHeight = true;               
                box.Show(UtilsUI.CurMainForm, ai);
            }
        }

        public static void Show(string mes, string caption= "Информация")
        {
            try
            {
                if (IsShowing) return;
                using (var box = new AlertControl())
                {
                    IsShowing = true;
                    var ai = new AlertInfo(caption, mes, Resources.Save);
                    box.AutoFormDelay = 3000;
                    box.AllowHotTrack = false;
                    box.FormDisplaySpeed = AlertFormDisplaySpeed.Moderate;
                    box.FormLocation = AlertFormLocation.BottomRight;
                    box.AutoHeight = true;
                    box.FormClosing += (s, e) => { IsShowing = false; };
                    box.Show(UtilsUI.CurMainForm, ai);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void HabarnomaShow(string mes, Image img, Action<int> res)
        {
            using (var box = new AlertControl())
            {
                box.AutoFormDelay = 9000;
                box.AllowHotTrack = false;
                box.FormDisplaySpeed = AlertFormDisplaySpeed.Slow;
                box.FormLocation = AlertFormLocation.BottomRight;
                box.AutoHeight = true;
                box.AllowHotTrack = true;
                box.ShowCloseButton = false;               
                box.AlertClick += (s, ex) => { res.Invoke(0); };
                box.Show(UtilsUI.CurMainForm, "Информация".ToLang("All"), mes, img);
            }
        }
    }
}