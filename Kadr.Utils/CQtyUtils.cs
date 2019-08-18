using System;

namespace Apteka.Utils
{
    public static class CQtyUtils
    {
        public static string CalcQty(this int c, int p)
        {
            //if (p == 0) return $"0 уп 0 шт";
            if (c == 0) return "нет";
            if (p == 0) return "ошибка";

            int u = c / p;
            int s = c % p;

            if (u > 0 && s > 0)
                return $"{u} уп {s} шт";

            if (u > 0 && s == 0)
                return $"{u} уп";
            
            if (u == 0 && s > 0)
                return $"{s} шт";

            return "ошибка";
        }

        public static decimal CalcTotalAmount(decimal price, int qty, int piece)
        {
            if (qty == 0) return 0;

            return Math.Round(((decimal)qty / (decimal)piece) * price, 2);
        }
    }
}
