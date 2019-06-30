using System;
using System.Windows.Forms;
using Apteka.Utils;
using DevExpress.XtraBars.Ribbon;

namespace Kadr.UtilsUI
{
    public static class UtilsUI
    {
         public static bool IsOnline;

        public static string Lang = "1";

        public static bool IsDebugAppMode = false;

        public static string UserId = "";
        public static string UserName = "";

        public static Form CurMainForm;
        public static RibbonControl CurMainRibbon;

        public static bool CheckAccsess(string controlTag)
        {
            if (controlTag.Trim()?.Length == 0) return false;

            #region tmp
            //if (IsPoiskAppMode)
            //{
            //    switch (controlTag)
            //    {
            //        case "3000":
            //            if ()
            //            return true; //АРМ Тех. Паспорт
            //        case "3010":
            //            return true; //АРМ Ишончнома
            //        case "3020":
            //            return true; //АРМ Тақиқ
            //        case "3110":
            //            return true; //Тех. Паспорт (тўла карточкаси)
            //        case "3140":
            //            return true; //Тех. Паспорт (экспорт)
            //        case "3150":
            //            return true; //Тех. паспорт тизимидан излаш
            //        case "3190":
            //            return true; //Ишончнома (излаш)
            //        case "3200":
            //            return true; //Ишончнома (экспорт)
            //        case "3240":
            //            return true; //Тақиқ (излаш)
            //        case "3250":
            //            return true; //Тақиқ (экспорт)

            //        default:
            //            return false;
            //    }
            //}

            /*
             3000	АРМ Тех. Паспорт
             3010	АРМ Ишончнома
             3020	АРМ Тақиқ
             3030	Созлаш
             3040	Созлаш чоп этиш формалари
             3050	Хисоботлар
             3060	Тех. Паспорт (янги)
             3070	Тех. Паспорт (ўзгартириш)
             3080	Тех. Паспорт (варақа асосида)
             3090	Тех. Паспорт (транзит)
             3100	Тех. Паспорт (чоп этиш)
             3110	Тех. Паспорт (тўла карточкаси)
             3120	Тех. Паспорт (хабарнома)
             3130	Тех. Паспорт (тасдиқнома)
             3140	Тех. Паспорт (экспорт)
             3150	Тех. паспорт тизимидан излаш
             3160	Паспорт тизимидан расмини кўриш
             3170	Ишончнома (янги)
             3180	Ишончнома (ўзгартириш)
             3190	Ишончнома (излаш)
             3200	Ишончнома (экспорт)
             3210	Тақиқ (янги)
        ?     3220	Тақиқ (узгартириш)
             3240	Тақиқ (излаш)
             3250	Тақиқ (экспорт)
             */

            #endregion

            //var vr = UserAccess.Contains(controlTag);

            //if (controlTag == "3000")
            //    IsSecTexpMode = UserAccess.Contains("3003");

            //return vr;
            return true;
        }

        public static string Version
        {
            get
            {
                return CFile.GetFileContents(AppDomain.CurrentDomain.BaseDirectory + "\\DownloadVersion.txt");
            }
        }
    }
}