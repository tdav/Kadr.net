using System;

namespace Apteka.Utils
{
    public static class CNumber
    {
        public static int RoundUpWeird(int rawNr)
        {
            if (rawNr < 100 && rawNr > -100)
                return RoundUpToNext50(rawNr);
            else
                return RoundUpToNext500(rawNr);
        }

        public static int RoundUpToNext50(int rawNr)
        {
            return RoundUpToNext(rawNr, 50);
        }

        public static int RoundUpToNext500(int rawNr)
        {
            return RoundUpToNext(rawNr, 500);
        }

        public static int RoundUpToNext(int rawNr, int next)
        {
            int result;
            int remainder;
            if ((remainder = rawNr % next) != 0)
            {
                if (rawNr >= 0)
                    result = RoundPositiveToNext(rawNr, next, remainder);
                else
                    result = RoundNegativeToNext(rawNr, remainder);
                if (result < rawNr)
                    throw new OverflowException("round(Number) > Int.MaxValue!");
                return result;
            }
            return rawNr;
        }

        private static int RoundNegativeToNext(int rawNr, int remainder)
        {
            return rawNr - remainder;
        }

        private static int RoundPositiveToNext(int rawNr, int next, int remainder)
        {
            return rawNr + next - remainder;
        }
    }
}