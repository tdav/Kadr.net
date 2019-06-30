using System;
using System.Drawing;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraSplashScreen;
using Kadr.GlobalVars;
using Kadr.GlobalVars.Properties;

namespace Kadr.MessageManager
{
    public class WaitFormManager
    {
        public static void Show()
        {
            try
            {
                Vars.IsSendData = false;
                SplashScreenManager.ShowForm(typeof (frmWait));
            }
            catch (Exception)
            {
            }
        }

        public static void ShowUpload()
        {
            try
            {
                Vars.IsSendData = true;
                SplashScreenManager.ShowForm(typeof (frmWait));
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
        public static void ShowError(string mes)
        {
            using (var box = new AlertControl())
            {
                var ai = new AlertInfo("Хато", mes, Resources.error);
                box.AutoFormDelay = 3000;
                box.AllowHotTrack = false;
                box.FormDisplaySpeed = AlertFormDisplaySpeed.Slow;
                box.FormLocation = AlertFormLocation.TopRight;
                box.AutoHeight = true;
                box.Show(Vars.CurMainForm, ai);
            }
        }

        public static void Show(string caption, string mes)
        {
            try
            {
                using (var box = new AlertControl())
                {
                    var sa = mes.Split('|');

                    var ai = new AlertInfo(caption, sa[0], Resources.Save);
                    box.AutoFormDelay = 3000;
                    box.AllowHotTrack = false;
                    box.FormDisplaySpeed = AlertFormDisplaySpeed.Moderate;
                    box.FormLocation = AlertFormLocation.BottomRight;
                    box.AutoHeight = true;
                    box.Show(Vars.CurMainForm, ai);
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

                box.Show(Vars.CurMainForm, "Хабарнома", mes, img);
            }
        }
    }
}