using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kadr.LangResource
{
    #region Xml Class

    [DataContract]
    public class ValuesResurceList
    {
        [DataMember]
        public Dictionary<string, string> ControlValues { get; set; }
    }
    #endregion
}
