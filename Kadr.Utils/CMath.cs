namespace Apteka.Utils
{
    public static class CMath
    {
        public static decimal ToRoundDown25(this decimal o)
        {
            return o - (o % 25);
        }

        public static decimal ToRoundDown50(this decimal o)
        {
            return o - (o % 50);
        }

        public static decimal ToRoundDown100(this decimal o)
        {
            return o - (o % 100);
        }
    }
}
