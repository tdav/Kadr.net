using System;
using System.Linq;

namespace Apteka.Utils
{
    public static class CArray
    {
        public static string[] ToStrArray(this object o)
        {

            var ol = o.GetType().GetProperties().ToList();
            string[] sa = new string[ol.Count + 2];

            int i = 0;
            ol.ForEach(f =>
            {
                f.GetValue(o, null);
                Type pt = f.PropertyType;
                if (pt.IsGenericType && pt.GetGenericTypeDefinition() == typeof(Nullable<>))
                    pt = Nullable.GetUnderlyingType(pt);


                object value = f.GetValue(o, null);

                if (value.ToStr() == "-1")
                    sa[i] = "";
                else
                    sa[i] = value.ToStr();
                i++;

            });

            sa[ol.Count] = "1";
            return sa;
        }
    }
}
