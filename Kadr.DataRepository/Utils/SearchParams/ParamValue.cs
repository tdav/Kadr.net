namespace Kadr.Models.Utils
{
    public struct ParamValue
    {
        public object[] Value { get; set; }
        public TypeEnum ParamType { get; set; }
        public СonditionsSearchEnum Conditions { get; set; }
        public ParamValue(object[] v, TypeEnum p, СonditionsSearchEnum c)
        {
            Value = v;
            ParamType = p;
            Conditions = c;
        }
    }
}
