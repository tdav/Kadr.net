using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Apteka.Utils
{
    public static class StringExtensions
    {
        private static char[] SanitizeChr = new[] { '\'', '\"' };

        public static void WriteConsole(this string s, int px, int py)
        {
            Console.SetCursorPosition(px, py);
            Console.Write(s);
        }

        public static string CalculateMD5Hash(this string source)
        {
            var encoder = Encoding.Default;
            var hash = MD5.Create().ComputeHash(encoder.GetBytes(source));
            return string.Concat(hash.Select(i => i.ToString("X")).ToArray());
        }

        public static string ToSanitize(this string value)
        {
            if (!string.IsNullOrEmpty(value))
                return value.RemoveChars(SanitizeChr);
            else
                return "";
        }

        public static string ToUpperCapital(this string text)
        {
            if (text.IsNullorEmpty() || text == "") return "";
            return char.ToUpper(text[0]) + ((text.Length > 1) ? text.Substring(1).ToLower() : string.Empty);
        }

        public static int ToIntParseFast(this string value)
        {
            int result = 0;
            int length = value.Length;
            for (int i = 0; i < length; i++)
            {
                result = 10 * result + (value[i] - 48);
            }
            return result;
        }



        public static int ToInt(this string source)
        {
            int i = -1;
            if (!string.IsNullOrEmpty(source))
                i = Convert.ToInt32(source.Replace(" ", ""));
            else
                CLog.Write("source IsNullOrEmpty");
            return i;
        }

        public static int ToInt(this char source)
        {
            return Convert.ToInt32(source);
        }


        public static int GetInt(this string source)
        {
            var temp = string.Empty;
            for (var i = 0; i < source.Length; i++)
            {
                if (char.IsNumber(source[i]))
                    temp += source[i];
            }
            return ((temp.Length == 0) ? 0 : temp.ToInt());
        }

        public static DateTime ToDataTime(this string source)
        {
            return Convert.ToDateTime(source, System.Threading.Thread.CurrentThread.CurrentCulture);
        }

        public static decimal ToDecimal(this string source)
        {
            return Convert.ToDecimal(source);
        }

        public static string ToDQuote(this string source)
        {
            return '"' + source + '"';
        }

        public static string ToQuote(this string source)
        {
            source = source.Replace("'", " ");
            return $"'{source}'";
        }

        public static string ToReshetka(this string source)
        {
            return "#" + source + "#";
        }

        public static string ToClear(this string source)
        {
            return source.Replace("‘", "").Replace("’", "");
        }

        public static byte[] ToByteArray(this string source)
        {
            return Encoding.UTF8.GetBytes(source);
        }

        public static long? ToNullableInt64(this string inVal)
        {
            if (string.IsNullOrEmpty(inVal))
            {
                return null;
            }
            else
            {
                if (long.TryParse(inVal, out long no))
                    return no;
                else
                    return null;
            }
        }

        public static int? ToNullableInt(this string inVal)
        {
            if (string.IsNullOrEmpty(inVal))
            {
                return null;
            }
            else
            {
                if (int.TryParse(inVal, out int no))
                    return no;
                else
                    return null;
            }
        }

        public static DateTime? ToNullableDateTime(this string inVal)
        {
            if (string.IsNullOrEmpty(inVal))
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(inVal);
            }

        }

        public static bool IsEmpty(this string inVal)
        {
            if (inVal == null) return true;
            return (string.IsNullOrEmpty(inVal.Trim()));
        }

        public static bool IsNotEmpty(this string inVal)
        {
            return !string.IsNullOrEmpty(inVal?.Trim());
        }

        public static string GetDateBirth(string dateBirth, string dateBirthComp)
        {
            return ((dateBirthComp == "1") ? dateBirth.Replace("01.01", "XX.XX") : dateBirth);
        }

        public static string ToStr(this byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }
    }
}