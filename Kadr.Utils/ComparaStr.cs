namespace Apteka.Utils
{
    public static class ComparaStr
    {
        public static bool Comparare(this string s, string value)
        {
            var l = s.Length;
            if (l > value.Length) return false;
            return s[0] == value[0];
        }
    }
}
