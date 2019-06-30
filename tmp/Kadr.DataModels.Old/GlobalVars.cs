using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Windows.Forms;
using Asbt.Utils;

namespace Asbt.Global
{
    public enum RecordState
    {
        rsNew,
        rsKartOsnov,
        rsEdit
    }

    public enum SplashScreenCommand
    {
        sscFrm,
        sscSp,
        sscReports,
        sscSetup,
        sscPing,
        sscLoadPlugin
    }


    public static class GlobalVars
    {
        public static int Oblast { get; set; }
        public static int Rayon { get; set; }
        public static int Turi { get; set; }
        public static int Ucherejdeniya { get; set; }


        public static CLanguage ln = new CLanguage();
        public static bool IsOnline;
        public static bool IsPoiskAppMode=false;
        public static string Skin { get; set; }
        public static string GrivView { get; set; }

        public static bool InitGlobalVars()
        {
            try
            {
                CurPath = Path.GetDirectoryName(Application.ExecutablePath);
                ConnStrDictionary = CRegistry.GetValue("Dictionary", CurPath + "\\REFERENCE.FDB");

               GlobalVars. Oblast = CRegistry.GetValue("Oblast").ToInt32();
                GlobalVars.Rayon = CRegistry.GetValue("Rayon").ToInt32();
                GlobalVars.Turi = CRegistry.GetValue("Turi").ToInt32();
                GlobalVars.Ucherejdeniya = CRegistry.GetValue("Ucherejdeniya").ToInt32();
                                                                                        
                Skin = CRegistry.GetValue("Skin").ToStr();

                if (DivisionId.ToStr() == "") DivisionId = "1000";

             
                return true;
            }
            catch (Exception ex)
            {
                CLog.Write("Конфигурацияни уқиш жараёнида ҳато - " + ex);
                MessageBox.Show("Конфигурацияни уқиш жараёнида ҳато", "Ҳато", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void SaveSkin()
        {
            CRegistry.SetValue("Skin", Skin);
        }

        public static bool WriteGlobalVars()
        {
            try
            {
                CRegistry.SetValue("Oblast", GlobalVars.Oblast);
                CRegistry.SetValue("Rayon", GlobalVars.Rayon);
                CRegistry.SetValue("Turi", GlobalVars.Turi);
                CRegistry.SetValue("Ucherejdeniya", GlobalVars.Ucherejdeniya);
                 

                return true;
            }
            catch (Exception ex)
            {
                CLog.Write(ex.GetAllMessages());
                MessageBox.Show("Конфигурацияни ёзиш жараёнида ҳато", "Ҳато", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void CreatePath(String inPath)
        {
            try
            {
                var splPath = inPath.Split('\\');
                var dirs = splPath[0] + "\\" + splPath[1];
                for (var i = 2; i < splPath.Length; i++)
                {
                    if (!Directory.Exists(dirs))
                        Directory.CreateDirectory(dirs);
                    dirs += "\\" + splPath[i];
                }
            }
            catch (Exception err)
            {
                CLog.Write(err.GetAllMessages());
            }
        }

        public static bool CheckAccsess(string controlTag)
        {
            //    if (controlTag.Trim() == "") return false;


            #region tmp
            //    //if (IsPoiskAppMode)
            //    //{
            //    //    switch (controlTag)
            //    //    {

            //    //        case "3250":
            //    //            return true; //Тақиқ (экспорт)

            //    //        default:
            //    //            return false;
            //    //    }
            //    //}
            //    var vr = UserAccess.Contains(controlTag);


            //    return vr;
            #endregion


            return true;
        }

        #region Vars

        public static string LastErrorStr { get; set; }

        public static string Lang_T
        {
            get { return "1"; }
        }

        public static bool IsDebugAppMode = false;
        //public static bool IsPoiskAppMode = false;

        public static string UserId = "";
        public static string UserName = "";

        public static Form CurMainForm;
        public static Object CurMainRibbon;


        public static string ConnStrDictionary = "";

        private static string _version = "";

        public static string Version
        {
            get
            {
                if (_version == "")
                    _version = CVersion.GetAverageAppVersion(Application.ExecutablePath);
                    
                return _version;
            }
        }

        public static string ConnStrTemproary = "";

        public static string UsersPath
        {
            get
            {
                CurPath = Path.GetDirectoryName(Application.ExecutablePath);
                var up = CurPath + "\\Users\\";
                CreatePath(up);
                return up;
            }
        }

        public static string CurEndpoint
        {
            get
            {
                if (IsDebugAppMode)
                {
                    return "BasicHttpBinding_Debug";
                }
                return "BasicHttpBinding_IwcService";
            }
        }

        private static string _addressKO = "http://172.250.1.206:9876/KO/";

        public static string AddressKO
        {
            get
            {
                if (IsDebugAppMode)
                    return "http://192.168.0.215/KO/";
                return _addressKO;
            }
            set { _addressKO = value; }
        }

        private static string _divisionId;

        public static string DivisionId
        {
            get { return _divisionId; }
            set
            {
                _divisionId = value;
                CurOblastId = Convert.ToInt64(_divisionId.Substring(0, 2));
            }
        }


        public static bool IsSecTexpMode = false;

        public static string CurPath = "";
        public static string DivisionStr = "";
        public static string KeyDivisionStr = "";
        public static bool ShowPreviewDialog;
        public static Int64 CurOblastId;
        public static string CurrentIp = "";
        public static string Lang = "RU";
        public static string Style;
        public static Int32 MaxRecordsPerPage = 20;
        public static Int32 RecPerPage = 50;
        public static bool UseDictionaryForFio = true;
        public static bool SaveConsultEvent;
        public static Int32 MailStatus = 10;
        public static Int32 MailTimer = 10;
        public static bool MailShowNotifications = true;

        public static string SignedUserId = "";
        public static string UserInfo = "";
        public static decimal EKIH = 0;

        public static SecureString CurPin;
        public static string UserAccess;
        public static string RegionId = string.Empty;
        public static int DivisionLevel;
        public static string BoshliqFIO { get; set; }
        public static string BoshliqLavozim { get; set; }
        public static string KalitDateTill { get; set; }
        public static bool IsSendData { get; set; }

        public static Dictionary<string, bool> _mail = new Dictionary<string, bool>();

        #endregion
    }
}