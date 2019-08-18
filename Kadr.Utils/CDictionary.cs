using System;
using System.Collections.Generic;
using System.Linq;

namespace Apteka.Utils
{
    public static class CDictionary
    {
        public static Dictionary<string, T> ToCaseInsensitive<T>(this Dictionary<string, T> caseSensitiveDictionary)
        {
            var caseInsensitiveDictionary = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
            caseSensitiveDictionary.Keys.ToList()
                .ForEach(k => caseInsensitiveDictionary[k] = caseSensitiveDictionary[k]);

            return caseInsensitiveDictionary;
        }


        public static Dictionary<string, object> ToModelToDictionary(this object o)
        {

            var ol = o.GetType().GetProperties().ToList();
            Dictionary<string, object> sa = new Dictionary<string, object>();

            ol.ForEach(f =>
            {
                f.GetValue(o, null);
                Type pt = f.PropertyType;
                if (pt.IsGenericType && pt.GetGenericTypeDefinition() == typeof(Nullable<>))
                    pt = Nullable.GetUnderlyingType(pt);


                var value = f.GetValue(o, null);
                sa.Add(f.Name, value);
            });

            return sa;
        }


    }
}
