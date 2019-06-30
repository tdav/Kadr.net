using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kadr.LangResource
{
    #region Xml Class

    [DataContract]
    public class FormResurceItem
    {
        [DataMember]
        public Dictionary<string, ValuesResurceList> ResurceValues { get; set; }
    }
    #endregion
}
