using Apteka.Utils;
using System;
using System.Windows.Forms;

namespace Kadr.GlobalVars
{
    public class Vars
    {
        public static CLanguage ln = new CLanguage();
        public static int UserId { get; set; }
        public static string UserName { get; set; }
        public static string UserAccess { get; set; }
        public static string UsersPath { get; set; }
        public static string Version { get; set; }
        public static string CurEndpoint { get; set; }
        public static string CurPath { get; set; }
        public static string Skin { get; set; } 
        public static string Lang { get; set; } 
        public static int Turi { get; set; } 


        public static string DivisionId { get; set; }
        public static string DivisionLevel { get; set; }
        public static string DivisionStr { get; set; }
        public static string RegionId { get; set; }
        public static Form CurMainForm { get; set; }
        public static object CurMainRibbon { get; set; }
        public static string GrivView { get; set; }
        public static bool IsDebug { get; set; }
        public static bool IsSendData { get; set; }

        public static int Oblast { get; set; }
        public static int Rayon { get; set; }
        public static int Ucherejdeniya { get; set; }
        public static bool IsOnline { get; set; }
        public static string RepConfigPath { get; set; }
        public static string UserFullName { get; set; }

        public static bool CheckAccsess(string v)
        {
            return true;
        }

        public static bool InitGlobalVars()
        {
            return true;
        }

        public static bool SaveSkin()
        {
            return true;
        }

        public static void SetAccess(object userAccess)
        {
            throw new NotImplementedException();
        }

        public static bool CheckAccess(int v)
        {
            throw new NotImplementedException();
        }
    }
}
