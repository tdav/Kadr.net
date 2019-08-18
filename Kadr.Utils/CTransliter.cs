using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


namespace Apteka.Utils
{
    public class CTransliter
    {
        const int KLF_ACTIVATE = 1; //активизируем раскладку 
        const int KL_NAMELENGTH = 9; // длина буфера клавиатуры 
        const string LANG_EN_US = "00000409";
        const string LANG_RU_RU = "00000419";
        const string LANG_UZ_CI = "00000843";
        const string LANG_UZ_LA = "00000443";
        const string LANG_KZ_CI = "0000043f";

        const int L_EN_US = 67699721;
        const int L_RU_RU = 68748313;
        const int L_UZ_CI = 138610755;
        const int L_UZ_LA = 67699721;
        const int L_KZ_CI = 71238719;

        public const string LETTER_UZ_C = "ЙЦУКЕНГШЎЗХЪҒҲФҚВАПРОЛДЖЭЯЧСМИТЬБЮЁ- ’";
        public const string LETTER_RU_C = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ- ’";
        public const string LETTER_EN_L = "QWERTYUIOPASDFGHJKLZXCVBNM-’ ";
        public const string LETTER_KZ_C = "ЙЦУКЕНГШЩЗХЪҚӨҒҢҮӘФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ- ’";
        public const string LETTER_UZ_L = "QWERTYUIOPASDFGHJKLZXCVBNM-‘’ ";
        public const string LETTER_LAT = "QWERTYUIOPASDFGHJKLZXCVBNM";
        public const string LETTER_NUMBER = "0123456789";
        public const string LETTER_VOWEL = "УЕАОЭЯИЮЁЫ";

        [DllImport("user32")]
        public static extern int ActivateKeyboardLayout(int HKL, int flags);
        [DllImport("user32", EntryPoint = "LoadKeyboardLayout")]
        public static extern int LoadKeyboardLayout(string pwszKLID, int flags);

        public static void LoadKeybords()
        {
            LoadKeyboardLayout(LANG_UZ_CI, KLF_ACTIVATE);
            LoadKeyboardLayout(LANG_RU_RU, KLF_ACTIVATE);
            LoadKeyboardLayout(LANG_KZ_CI, KLF_ACTIVATE);
            LoadKeyboardLayout(LANG_EN_US, KLF_ACTIVATE);
            LoadKeyboardLayout(LANG_UZ_LA, KLF_ACTIVATE);
        }

        public static void SetLanguage(int _ln)
        {
            switch (_ln)
            {
                case 0:
                    //InputLanguage.FromCulture(new CultureInfo("uz-UZ Cyrl"));
                    LoadKeyboardLayout(LANG_UZ_CI, KLF_ACTIVATE);
                    break;
                case 1:
                    LoadKeyboardLayout(LANG_RU_RU, KLF_ACTIVATE);
                    break;
                case 2:
                    LoadKeyboardLayout(LANG_KZ_CI, KLF_ACTIVATE);
                    break;
                case 3:
                    LoadKeyboardLayout(LANG_EN_US, KLF_ACTIVATE);
                    break;
                case 4:
                    LoadKeyboardLayout(LANG_UZ_LA, KLF_ACTIVATE);
                    break;
                default:
                    LoadKeyboardLayout(LANG_UZ_CI, KLF_ACTIVATE);
                    break;
            }
        }

        public static bool CheckLetter(string in_ch, string ln)
        {
            string check_str;
            switch (ln)
            {
                case "0":
                case "00":
                case "1":
                case "01":
                case "2":
                case "02":
                    check_str = LETTER_KZ_C + LETTER_UZ_C + LETTER_RU_C;
                    break;
                case "3":
                case "03":
                    check_str = LETTER_EN_L;
                    break;
                case "4":
                case "04":
                case "5":
                case "05":
                    check_str = LETTER_UZ_L;
                    break;
                case "6":
                case "06":
                    check_str = LETTER_LAT;
                    break;
                case "Number":
                case "7":
                    check_str = LETTER_NUMBER;
                    break;
                case "EnglishNumber":
                    check_str = LETTER_LAT + LETTER_NUMBER;
                    break;
                default:
                    check_str = LETTER_UZ_C + LETTER_RU_C + LETTER_KZ_C + LETTER_UZ_L + LETTER_EN_L;
                    break;
            }
            return !(check_str.Contains(in_ch.ToUpper()));
        }

        public static char CheckX(char in_ch)
        {
            string check_str = LETTER_NUMBER;
            return (check_str.Contains(in_ch.ToString().ToUpper())) ? in_ch : 'X';
        }

        public static bool CheckNumber(char in_ch)
        {
            string check_str = LETTER_NUMBER;
            return !(check_str.Contains(in_ch));
        }

        public static String CirToLat(string in_ch)
        {
            String result = "";
            String _result = "";
            String check_str = LETTER_VOWEL;
            for (int i = 0; i < in_ch.Length; i++)
            {
                switch (in_ch[i].ToString().ToUpper())
                {
                    case "А": result = "A"; break;
                    case "Б": result = "B"; break;
                    case "В": result = "V"; break;
                    case "Г": result = "G"; break;
                    case "Д": result = "D"; break;
                    case "Е":
                        if (i == 0)
                            result = "YE";
                        else
                            if (!(check_str.Contains(in_ch[i].ToString().ToUpper())))
                                result = "E";
                            else
                                result = "YE";
                        break;
                    case "Ё": result = "YO"; break;
                    case "Ж": result = "J"; break;
                    case "З": result = "Z"; break;
                    case "И": result = "I"; break;
                    case "Й": result = "Y"; break;
                    case "К": result = "K"; break;
                    case "Л": result = "L"; break;
                    case "М": result = "M"; break;
                    case "Н": result = "N"; break;
                    case "О": result = "O"; break;
                    case "П": result = "P"; break;
                    case "Р": result = "R"; break;
                    case "С": result = "S"; break;
                    case "Т": result = "T"; break;
                    case "У": result = "U"; break;
                    case "Ф": result = "F"; break;
                    case "Х": result = "X"; break;
                    case "Ц":
                        if (i == 0)
                            result = "S";
                        else
                            if (!(check_str.Contains(in_ch[i].ToString().ToUpper())))
                                result = "S";
                            else
                                result = "TS";
                        break;
                    case "Ч": result = "CH"; break;
                    case "Ш": result = "SH"; break;
                    case "Ъ": result = "’"; break;
                    case "Э": result = "E"; break;
                    case "Ю": result = "YU"; break;
                    case "Я": result = "YA"; break;
                    case "Ў": result = "O‘"; break;
                    case "Қ": result = "Q"; break;
                    case "Ғ": result = "G‘"; break;
                    case "Ҳ": result = "H"; break;
                    case "Ы": result = "I"; break;
                    case "Щ": result = "SH"; break;
                    case "Ь": result = ""; break;
                    //case "Ұ": result = "Y"; break;
                    //case "Ө": result = "O"; break;
                    //case "Һ": result = "H"; break;
                    //case "Ң": result = "H"; break;
                    //case "Ү": result = "Y"; break;
                    //case "Ә": result = "E"; break;

                    default: result = in_ch[i].ToString().ToUpper(); break;
                }
                _result += result;
            }
            return _result;
        }

        public static bool ValidateLetter(string in_str, string LETTER_LN)
        {
            String values = LETTER_LN;
            bool res = true;
            for (int i = 0; i < in_str.Length; i++)
            {
                if (!values.Contains(in_str[i])) res = false;
            }
            return res;
        }

        public static String CirToEngAsLat(string in_ch, string in_lang)
        {
            String result = "";
            String _result = "";
            String check_str = LETTER_VOWEL;

            if (in_lang == "02")
            {
                #region From Karakalpak

                for (int i = 0; i < in_ch.Length; i++)
                {
                    switch (in_ch[i].ToString().ToUpper())
                    {
                        case "‘": result = ""; break;
                        case "А": result = "A"; break;
                        case "Ә": result = "A"; break;
                        case "Б": result = "B"; break;
                        case "В": result = "V"; break;
                        case "Г": result = "G"; break;
                        case "Ғ": result = "G"; break;
                        case "Е":
                            if (i == 0)
                                result = "YE";
                            else
                                result = "E";
                            break;
                        case "Д": result = "D"; break;
                        case "Ё": result = "YO"; break;
                        case "Ж": result = "J"; break;
                        case "З": result = "Z"; break;
                        case "И": result = "I"; break;
                        case "Й": result = "Y"; break;
                        case "К": result = "K"; break;
                        case "Қ": result = "Q"; break;
                        case "Л": result = "L"; break;
                        case "М": result = "M"; break;
                        case "Н": result = "N"; break;
                        case "Ң": result = "N"; break;
                        case "О":
                            if (i == 0)
                                result = "WO";
                            else
                                result = "O";
                            break;
                        case "Ө":
                            if (i == 0)
                                result = "WO";
                            else
                                result = "O";
                            break;
                        case "П": result = "P"; break;
                        case "Р": result = "R"; break;
                        case "С": result = "S"; break;
                        case "Т": result = "T"; break;
                        case "У": result = "U"; break;
                        case "Ў": result = "W"; break;
                        case "Ү": result = "U"; break;
                        case "Ф": result = "F"; break;
                        case "Х": result = "X"; break;
                        case "Ҳ": result = "H"; break;
                        case "Ц": result = "C"; break;
                        case "Ч": result = "CH"; break;
                        case "Ш": result = "SH"; break;
                        case "Щ": result = "CH"; break;
                        case "Ы": result = "I"; break;
                        case "Э": result = "E"; break;
                        case "Ю": result = "YU"; break;
                        case "Я": result = "YA"; break;
                        case "Ь": result = ""; break;
                        case "Ъ": result = ""; break;
                        //case "Ұ": result = "Y"; break;
                        //case "Һ": result = "H"; break;

                        default: result = in_ch[i].ToString().ToUpper(); break;
                    }
                    _result += result;
                }

                #endregion From Karakalpak
            }
            else
            {
                #region From Uzbek

                for (int i = 0; i < in_ch.Length; i++)
                {
                    switch (in_ch[i].ToString().ToUpper())
                    {
                        case "‘": result = ""; break;
                        case "А": result = "A"; break;
                        case "Б": result = "B"; break;
                        case "В": result = "V"; break;
                        case "Г": result = "G"; break;
                        case "Д": result = "D"; break;
                        case "Е":
                            if (i == 0)
                                result = "YE";
                            else
                                if (!(check_str.Contains(in_ch[i - 1].ToString().ToUpper())))
                                    result = "E";
                                else
                                    result = "YE";
                            break;
                        case "Ё": result = "YO"; break;
                        case "Ж": result = "J"; break;
                        case "З": result = "Z"; break;
                        case "И": result = "I"; break;
                        case "Й": result = "Y"; break;
                        case "К": result = "K"; break;
                        case "Л": result = "L"; break;
                        case "М": result = "M"; break;
                        case "Н": result = "N"; break;
                        case "О": result = "O"; break;
                        case "П": result = "P"; break;
                        case "Р": result = "R"; break;
                        case "С": result = "S"; break;
                        case "Т": result = "T"; break;
                        case "У": result = "U"; break;
                        case "Ф": result = "F"; break;
                        case "Х": result = "X"; break;
                        case "Ц":
                            if (i == 0)
                                result = "S";
                            else
                                if (!(check_str.Contains(in_ch[i - 1].ToString().ToUpper())))
                                    result = "S";
                                else
                                    result = "TS";
                            break;
                        case "Ч": result = "CH"; break;
                        case "Ш": result = "SH"; break;
                        case "Ъ": result = ""; break;
                        case "Э": result = "E"; break;
                        case "Ю": result = "YU"; break;
                        case "Я": result = "YA"; break;
                        case "Ў": result = "O"; break;
                        case "Қ": result = "Q"; break;
                        case "Ғ": result = "G"; break;
                        case "Ҳ": result = "H"; break;
                        case "Ы": result = "I"; break;
                        case "Щ": result = "SH"; break;
                        case "Ь": result = ""; break;

                        //case "Ұ": result = "Y"; break;
                        //case "Ө": result = "O’"; break;
                        //case "Һ": result = "H"; break;
                        //case "Ң": result = "N‘"; break;
                        //case "Ү": result = "U‘"; break;
                        //case "Ә": result = "A‘"; break;

                        default: result = in_ch[i].ToString().ToUpper(); break;
                    }
                    _result += result;
                }

                #endregion From Uzbek
            }

            return _result;
        }

        public static String CirToEng(string in_ch)
        {
            String result = "";
            String _result = "";

            #region From All

            for (int i = 0; i < in_ch.Length; i++)
            {
                switch (in_ch[i].ToString().ToUpper())
                {
                    case "А": result = "A"; break;
                    case "Ә": result = "A"; break;
                    case "Б": result = "B"; break;
                    case "В": result = "V"; break;
                    case "Г": result = "G"; break;
                    case "Ғ": result = "G"; break;
                    case "Е": result = "E"; break;
                    case "Д": result = "D"; break;
                    case "Ё": result = "E"; break;
                    case "Ж": result = "ZH"; break;
                    case "З": result = "Z"; break;
                    case "И": result = "I"; break;
                    case "Й": result = "I"; break;
                    case "К": result = "K"; break;
                    case "Қ": result = "K"; break;
                    case "Л": result = "L"; break;
                    case "М": result = "M"; break;
                    case "Н": result = "N"; break;
                    case "Ң": result = "N"; break;
                    case "О": result = "O"; break;
                    case "Ө": result = "O"; break;
                    case "П": result = "P"; break;
                    case "Р": result = "R"; break;
                    case "С": result = "S"; break;
                    case "Т": result = "T"; break;
                    case "У": result = "U"; break;
                    case "Ў": result = "U"; break;
                    case "Ұ": result = "U"; break;
                    case "Ф": result = "F"; break;
                    case "Х": result = "KH"; break;
                    case "Ҳ": result = "KH"; break;
                    case "Ц": result = "TS"; break;
                    case "Ч": result = "CH"; break;
                    case "Ш": result = "SH"; break;
                    case "Щ": result = "SHCH"; break;
                    case "Ы": result = "Y"; break;
                    case "Э": result = "E"; break;
                    case "Ю": result = "IU"; break;
                    case "Я": result = "IA"; break;
                    case "Ь": result = ""; break;
                    case "Ъ": result = ""; break;
                    //case "Һ": result = "H"; break;

                    case "A":
                        if (i == in_ch.Length - 1)
                        {
                            result = "A";
                        }
                        else
                        {
                            if (in_ch[i + 1] == '‘')
                            {
                                result = "A";
                                i++;
                            }
                            else
                            {
                                result = "A";
                            }
                        }
                        break;
                    case "B": result = "B"; break;
                    case "V": result = "V"; break;
                    case "G":
                        if (i == in_ch.Length - 1)
                        {
                            result = "G";
                        }
                        else
                        {
                            if (in_ch[i + 1] == '‘')
                            {
                                result = "G";
                                i++;
                            }
                            else
                            {
                                result = "G";
                            }
                        }
                        break;
                    case "D": result = "D"; break;
                    case "Y":
                        if (i == in_ch.Length - 1)
                        {
                            result = "I";
                        }
                        else
                        {
                            if ((in_ch[i + 1] == 'E') || (in_ch[i + 1] == 'O'))
                            {
                                result = "E";
                                i++;
                            }
                            else if (in_ch[i + 1] == 'U')
                            {
                                result = "IU";
                                i++;
                            }
                            else if (in_ch[i + 1] == 'A')
                            {
                                result = "IA";
                                i++;
                            }
                            else
                            {
                                result = "I";
                            }
                        }
                        break;
                    case "J": result = "ZH"; break;
                    case "Z": result = "Z"; break;
                    case "I":
                        if (i == in_ch.Length - 1)
                        {
                            result = "I";
                        }
                        else
                        {
                            if (in_ch[i + 1] == '‘')
                            {
                                result = "I";
                                i++;
                            }
                            else
                            {
                                result = "I";
                            }
                        }
                        break;
                    case "K": result = "K"; break;
                    case "L": result = "L"; break;
                    case "M": result = "M"; break;
                    case "N":
                        if (i == in_ch.Length - 1)
                        {
                            result = "N";
                        }
                        else
                        {
                            if (in_ch[i + 1] == '‘')
                            {
                                result = "N";
                                i++;
                            }
                            else
                            {
                                result = "N";
                            }
                        }
                        break;
                    case "O":
                        if (i == in_ch.Length - 1)
                        {
                            result = "O";
                        }
                        else
                        {
                            if (in_ch[i + 1] == '‘')
                            {
                                result = "U";
                                i++;
                            }
                            else
                            {
                                result = "O";
                            }
                        }
                        break;
                    case "P": result = "P"; break;
                    case "R": result = "R"; break;
                    case "S":
                        if (i == in_ch.Length - 1)
                        {
                            result = "S";
                        }
                        else
                        {
                            if (in_ch[i + 1] == 'H')
                            {
                                result = "SH";
                                i++;
                            }
                            else
                            {
                                result = "S";
                            }
                        }
                        break;

                    case "T":
                        if (i == in_ch.Length - 1)
                        {
                            result = "T";
                        }
                        else
                        {
                            if (in_ch[i + 1] == 'S')
                            {
                                result = "TS";
                                i++;
                            }
                            else
                            {
                                result = "T";
                            }
                        }
                        break;
                    case "U": result = "U"; break;
                    case "F": result = "F"; break;
                    case "X": result = "KH"; break;
                    case "C":
                        if (i == in_ch.Length - 1)
                        {
                            result = "TS";
                        }
                        else
                        {
                            if (in_ch[i + 1] == 'H')
                            {
                                result = "CH";
                                i++;
                            }
                            else
                            {
                                result = "TS";
                            }
                        }
                        break;
                    case "Q": result = "K"; break;

                    case "E": result = "E"; break;
                    case "H": result = "KH"; break;
                    case "‘": result = ""; break;

                    default: result = in_ch[i].ToString().ToUpper(); break;
                }
                _result += result;
            }

            #endregion From All

            return _result;
        }

        public static String CirToLat(string in_ch, string in_lang)
        {
            String result = "";
            String _result = "";
            String check_str = LETTER_VOWEL;

            if (in_lang == "02")
            {
                #region From Karakalpak

                for (int i = 0; i < in_ch.Length; i++)
                {
                    switch (in_ch[i].ToString().ToUpper())
                    {
                        case "А": result = "A"; break;
                        case "Ә": result = "A‘"; break;
                        case "Б": result = "B"; break;
                        case "В": result = "V"; break;
                        case "Г": result = "G"; break;
                        case "Ғ": result = "G‘"; break;
                        case "Е":
                            if (i == 0)
                                result = "YE";
                            else
                                result = "E";
                            break;
                        case "Д": result = "D"; break;
                        case "Ё": result = "YO"; break;
                        case "Ж": result = "J"; break;
                        case "З": result = "Z"; break;
                        case "И": result = "I"; break;
                        case "Й": result = "Y"; break;
                        case "К": result = "K"; break;
                        case "Қ": result = "Q"; break;
                        case "Л": result = "L"; break;
                        case "М": result = "M"; break;
                        case "Н": result = "N"; break;
                        case "Ң": result = "N‘"; break;
                        case "О":
                            if (i == 0)
                                result = "WO";
                            else
                                result = "O";
                            break;

                        case "Ө":
                            if (i == 0)
                                result = "WO‘";
                            else
                                result = "O‘";
                            break;

                        case "П": result = "P"; break;
                        case "Р": result = "R"; break;
                        case "С": result = "S"; break;
                        case "Т": result = "T"; break;
                        case "У": result = "U"; break;
                        case "Ў": result = "W"; break;
                        case "Ү": result = "U‘"; break;
                        case "Ф": result = "F"; break;
                        case "Х": result = "X"; break;
                        case "Ҳ": result = "H"; break;
                        case "Ц": result = "C"; break;
                        case "Ч": result = "CH"; break;
                        case "Ш": result = "SH"; break;
                        case "Щ": result = "CH"; break;
                        case "Ы": result = "I‘"; break;
                        case "Э": result = "E"; break;
                        case "Ю": result = "YU"; break;
                        case "Я": result = "YA"; break;
                        case "Ь": result = ""; break;
                        case "Ъ": result = "’"; break;
                        //case "Ұ": result = "Y"; break;
                        //case "Һ": result = "H"; break;

                        default: result = in_ch[i].ToString().ToUpper(); break;
                    }
                    _result += result;
                }

                #endregion From Karakalpak
            }
            else
            {
                #region From Uzbek

                for (int i = 0; i < in_ch.Length; i++)
                {
                    switch (in_ch[i].ToString().ToUpper())
                    {
                        case "А": result = "A"; break;
                        case "Б": result = "B"; break;
                        case "В": result = "V"; break;
                        case "Г": result = "G"; break;
                        case "Д": result = "D"; break;
                        case "Е":
                            if (i == 0)
                            {
                                result = "YE";
                            }
                            else
                            {
                                if (!(check_str.Contains(in_ch[i - 1].ToString().ToUpper())))
                                {
                                    result = "E";
                                }
                                else
                                {
                                    result = "YE";
                                }
                            }
                            break;
                        case "Ё": result = "YO"; break;
                        case "Ж": result = "J"; break;
                        case "З": result = "Z"; break;
                        case "И": result = "I"; break;
                        case "Й": result = "Y"; break;
                        case "К": result = "K"; break;
                        case "Л": result = "L"; break;
                        case "М": result = "M"; break;
                        case "Н": result = "N"; break;
                        case "О": result = "O"; break;
                        case "П": result = "P"; break;
                        case "Р": result = "R"; break;
                        case "С": result = "S"; break;
                        case "Т": result = "T"; break;
                        case "У": result = "U"; break;
                        case "Ф": result = "F"; break;
                        case "Х": result = "X"; break;
                        case "Ц":
                            if (i == 0)
                            {
                                result = "S";
                            }
                            else
                            {
                                if (!(check_str.Contains(in_ch[i - 1].ToString().ToUpper())))
                                {
                                    result = "S";
                                }
                                else
                                {
                                    result = "TS";
                                }
                            }
                            break;
                        case "Ч": result = "CH"; break;
                        case "Ш": result = "SH"; break;
                        case "Ъ": result = "’"; break;
                        case "Э": result = "E"; break;
                        case "Ю": result = "YU"; break;
                        case "Я": result = "YA"; break;
                        case "Ў": result = "O‘"; break;
                        case "Қ": result = "Q"; break;
                        case "Ғ": result = "G‘"; break;
                        case "Ҳ": result = "H"; break;
                        case "Ы": result = "I"; break;
                        case "Щ": result = "SH"; break;
                        case "Ь": result = ""; break;

                        //case "Ұ": result = "Y"; break;
                        //case "Ө": result = "O’"; break;
                        //case "Һ": result = "H"; break;
                        //case "Ң": result = "N‘"; break;
                        //case "Ү": result = "U‘"; break;
                        //case "Ә": result = "A‘"; break;

                        default: result = in_ch[i].ToString().ToUpper(); break;
                    }
                    _result += result;
                }

                #endregion From Uzbek
            }

            return _result;
        }

        public static UInt16 PkCorrect(String pk, String date_birth, String s)
        {
            //------PersonalKod 42612540060015
            try
            {
                DateTime dtt = date_birth.Replace("XX.", "01.").ToDataTime();
            }
            catch (Exception )
            {
                return 3;
            }
            date_birth = date_birth.Replace("XX.", "00.").Replace(".", "");
            int sex = 1;
            try
            {
                sex = s.ToInt();
            }
            catch (Exception )
            {
                return 4;
            }
            if (pk.Length != 14) return 1;
            if ((pk.Length == 14) && (date_birth.Length == 8) && (sex != -1))
            {
                string pks = (pk[0].ToInt() * 7 + pk[1].ToInt() * 3 + pk[2].ToInt() * 1 +
                              pk[3].ToInt() * 7 + pk[4].ToInt() * 3 + pk[5].ToInt() * 1 +
                              pk[6].ToInt() * 7 + pk[7].ToInt() * 3 + pk[8].ToInt() * 1 +
                              pk[9].ToInt() * 7 + pk[10].ToInt() * 3 + pk[11].ToInt() * 1 + pk[12].ToInt() * 7).ToString();
                char pkc = pks[pks.Length - 1];
                if (pkc != pk[13])
                {
                    return 0;
                }
                if ((date_birth.Substring(4).ToInt() < 2000) && (sex == 1) && (pk[0] != '3')) return 6;
                if ((date_birth.Substring(4).ToInt() < 2000) && (sex == 2) && (pk[0] != '4')) return 6;
                if ((date_birth.Substring(4).ToInt() > 2000) && (sex == 1) && (pk[0] != '5')) return 6;
                if ((date_birth.Substring(4).ToInt() > 2000) && (sex == 2) && (pk[0] != '6')) return 6;

                if (pk.Substring(1, 6) != date_birth.Remove(4, 2)) return 2;
                return 7;
            }
            else
                return 5;
        }

        public static Dictionary<String, String> MRZ(String mrz1, String mrz2)
        {
            Dictionary<String, String> t = new Dictionary<string, string>();
            t.Add("Sery", "");
            t.Add("Number", "");
            t.Add("SurnameEnglish", "");
            t.Add("NameEnglish", "");
            t.Add("Sex", "");
            t.Add("Pk", "");
            t.Add("BirthDate", "");
            t.Add("Type", "");
            try
            {
                t["Type"] = mrz1.Substring(0, 2).Replace("<", "");
                t["Sery"] = mrz2.Substring(0, 2).Replace("<", "");
                t["Number"] = mrz2.Substring(2, 7).Replace("<", "");

                string target = "<<";
                char[] anyOf = target.ToCharArray();
                t["SurnameEnglish"] = mrz1.Substring(5, mrz1.IndexOf("<<") - 5);
                t["NameEnglish"] = mrz1.Substring(mrz1.IndexOfAny(anyOf, 5) + 2, mrz1.IndexOfAny(anyOf, mrz1.IndexOfAny(anyOf, 5) + 2) - mrz1.IndexOfAny(anyOf, 5) - 2);
                t["Sex"] = ((mrz2.Substring(20, 1) == "M") ? "1" : "2");

                if (mrz2.Substring(28, 14).Contains('<'))
                {
                    t["Pk"] = "";
                    t["BirthDate"] = mrz2.Substring(17, 2).Replace('<', 'X') + "." + mrz2.Substring(15, 2).Replace('<', 'X') + ".19" + mrz2.Substring(13, 2);
                }
                else
                {
                    t["Pk"] = mrz2.Substring(28, 14);
                    if ((t["Pk"][0] == '1') || (t["Pk"][0] == '2'))
                        t["BirthDate"] = mrz2.Substring(17, 2).Replace('<', 'X') + "." + mrz2.Substring(15, 2).Replace('<', 'X') + ".18" + mrz2.Substring(13, 2);
                    if ((t["Pk"][0] == '3') || (t["Pk"][0] == '4'))
                        t["BirthDate"] = mrz2.Substring(17, 2).Replace('<', 'X') + "." + mrz2.Substring(15, 2).Replace('<', 'X') + ".19" + mrz2.Substring(13, 2);
                    if ((t["Pk"][0] == '5') || (t["Pk"][0] == '6'))
                        t["BirthDate"] = mrz2.Substring(17, 2).Replace('<', 'X') + "." + mrz2.Substring(15, 2).Replace('<', 'X') + ".20" + mrz2.Substring(13, 2);
                }
            }
            catch (Exception )
            {
            }
            return t;
        }

        public static string ToText(int inDigit)
        {
            string[] array_string = new string[3] { " миллион", " минг", "" };
            int[] array_int = new int[3];
            array_int[0] = ((inDigit % 1000000000) - (inDigit % 1000000)) / 1000000;
            array_int[1] = ((inDigit % 1000000) - (inDigit % 1000)) / 1000;
            array_int[2] = inDigit % 1000;
            string result = "";

            for (int i = 0; i < 3; i++)
            {
                if (array_int[i] != 0)
                {
                    //if (((array_int[i] - (array_int[i] % 100)) / 100) != 0)
                    switch (((array_int[i] - (array_int[i] % 100)) / 100))
                    {
                        case 0: result += ""; break;
                        case 1: result += " бир юз"; break;
                        case 2: result += " икки юз"; break;
                        case 3: result += " уч юз"; break;
                        case 4: result += " турт юз"; break;
                        case 5: result += " беш юз"; break;
                        case 6: result += " олти юз"; break;
                        case 7: result += " етти юз"; break;
                        case 8: result += " саккиз юз"; break;
                        case 9: result += " туққиз юз"; break;
                    }
                    //if (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10 != 0)
                    //{
                    switch (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10)
                    {
                        case 0: result += ""; break;
                        case 1: result += " ўн"; break;
                        case 2: result += " йигирма"; break;
                        case 3: result += " ўттиз"; break;
                        case 4: result += " қириқ"; break;
                        case 5: result += " эллик"; break;
                        case 6: result += " олтмиш"; break;
                        case 7: result += " етмиш"; break;
                        case 8: result += " саксон"; break;
                        case 9: result += " тўқсон"; break;
                    }
                    //}
                    switch (array_int[i] % 10)
                    {
                        case 1: result += " бир"; break;
                        case 2: result += " икки"; break;
                        case 3: result += " уч"; break;
                        case 4: result += " турт"; break;
                        case 5: result += " беш"; break;
                        case 6: result += " олти"; break;
                        case 7: result += " етти"; break;
                        case 8: result += " сакиз"; break;
                        case 9: result += " тўққиз"; break;
                    }
                    result += " " + array_string[i] + " ";
                }
                //else switch (array_int[i] % 100)
                //    {
                //        case 10: result += " ўн"; break;
                //        case 11: result += " ўн бир"; break;
                //        case 12: result += " ўн икки"; break;
                //        case 13: result += " ўн уч"; break;
                //        case 14: result += " ўн тўрт"; break;
                //        case 15: result += " ўн беш"; break;
                //        case 16: result += " ўн олти"; break;
                //        case 17: result += " ўн етти"; break;
                //        case 18: result += " ўн сакиз"; break;
                //        case 19: result += " ўн тўққиз"; break;
                //    }

            }
            return result;
        }


        public static String CirToLatFull(String in_ch)
        {
            const string LETTER_VOWEL = "УуЕеАаОоЭэЯяИиЮю";
            String result = "";
            String _result = "";
            String check_str = LETTER_VOWEL;
            for (int i = 0; i < in_ch.Length; i++)
            {
                switch (in_ch[i].ToString())
                {
                    case "А": result = "A"; break;
                    case "а": result = "a"; break;
                    case "Б": result = "B"; break;
                    case "б": result = "b"; break;
                    case "В": result = "V"; break;
                    case "в": result = "v"; break;
                    case "Г": result = "G"; break;
                    case "г": result = "g"; break;
                    case "Д": result = "D"; break;
                    case "д": result = "d"; break;
                    case "Е":
                        if (i == 0)
                        {
                            result = "Ye";
                        }
                        else
                        {
                            if (!(check_str.Contains(in_ch[i - 1].ToString().ToUpper())))
                            {
                                result = "E";
                            }
                            else
                            {
                                result = "Ye";
                            }
                        }
                        break;
                    case "e":
                        if (i == 0)
                        {
                            result = "ye";
                        }
                        else
                        {
                            if (!(check_str.Contains(in_ch[i - 1].ToString().ToUpper())))
                            {
                                result = "e";
                            }
                            else
                            {
                                result = "ye";
                            }
                        }
                        break;
                    case "Ё": result = "Yo"; break;
                    case "ё": result = "yo"; break;
                    case "Ж": result = "J"; break;
                    case "ж": result = "j"; break;
                    case "З": result = "Z"; break;
                    case "з": result = "z"; break;
                    case "И": result = "I"; break;
                    case "и": result = "i"; break;
                    case "Й": result = "Y"; break;
                    case "й": result = "y"; break;
                    case "К": result = "K"; break;
                    case "к": result = "k"; break;
                    case "Л": result = "L"; break;
                    case "л": result = "l"; break;
                    case "М": result = "M"; break;
                    case "м": result = "m"; break;
                    case "Н": result = "N"; break;
                    case "н": result = "n"; break;
                    case "О": result = "O"; break;
                    case "о": result = "o"; break;
                    case "П": result = "P"; break;
                    case "п": result = "p"; break;
                    case "Р": result = "R"; break;
                    case "р": result = "r"; break;
                    case "С": result = "S"; break;
                    case "с": result = "s"; break;
                    case "Т": result = "T"; break;
                    case "т": result = "t"; break;
                    case "У": result = "U"; break;
                    case "у": result = "u"; break;
                    case "Ф": result = "F"; break;
                    case "ф": result = "f"; break;
                    case "Х": result = "X"; break;
                    case "х": result = "x"; break;
                    case "Ц":
                        if (i == 0)
                        {
                            result = "S";
                        }
                        else
                        {
                            if (!(check_str.Contains(in_ch[i - 1].ToString().ToUpper())))
                            {
                                result = "S";
                            }
                            else
                            {
                                result = "Ts";
                            }
                        }
                        break;
                    case "ц":
                        if (i == 0)
                        {
                            result = "s";
                        }
                        else
                        {
                            if (!(check_str.Contains(in_ch[i - 1].ToString().ToUpper())))
                            {
                                result = "s";
                            }
                            else
                            {
                                result = "ts";
                            }
                        }
                        break;
                    case "Ч": result = "Ch"; break;
                    case "ч": result = "ch"; break;
                    case "Ш": result = "Sh"; break;
                    case "ш": result = "sh"; break;
                    case "Ъ": result = "’"; break;
                    case "ъ": result = "’"; break;
                    case "Э": result = "E"; break;
                    case "э": result = "e"; break;
                    case "Ю": result = "Yu"; break;
                    case "ю": result = "yu"; break;
                    case "Я": result = "Ya"; break;
                    case "я": result = "ya"; break;
                    case "Ў": result = "O‘"; break;
                    case "ў": result = "o‘"; break;
                    case "Қ": result = "Q"; break;
                    case "қ": result = "q"; break;
                    case "Ғ": result = "G‘"; break;
                    case "ғ": result = "g‘"; break;
                    case "Ҳ": result = "H"; break;
                    case "ҳ": result = "h"; break;
                    case "Ы": result = "I"; break;
                    case "ы": result = "i"; break;
                    case "Щ": result = "SH"; break;
                    case "щ": result = "sh"; break;
                    case "Ь": result = ""; break;
                    case "ь": result = ""; break;
                    //case "Ұ": result = "Y"; break;
                    //case "Ө": result = "O"; break;
                    //case "Һ": result = "H"; break;
                    //case "Ң": result = "H"; break;
                    //case "Ү": result = "Y"; break;
                    //case "Ә": result = "E"; break;

                    default: result = in_ch[i].ToString(); break;
                }
                _result += result;
            }
            return _result;
        }
    }
}
