namespace Kadr.DataRepository.Utils
{
    public static class ValueChecker
    {
       public static string ToSearchParamsNumeric(this object v)
        {
            var s = v?.ToString();
            if (!string.IsNullOrEmpty(s))
            {
                s = s.Replace(',', '.');
                return s;
            }

            return "";
        }
    }
}
