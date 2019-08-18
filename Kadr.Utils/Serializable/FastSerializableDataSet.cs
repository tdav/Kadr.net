using System;
using System.Data;
using System.Runtime.Serialization;

namespace Apteka.Utils.DataBase
{
    /// <summary>
    /// Replacement for the standard DataSet to allow Fast Serialization
    /// during remoting.
    /// </summary>
    [Serializable]
    public class FastSerializableDataSet : DataSet, ISerializable
    {
        #region Constructors

        public FastSerializableDataSet() : base() { }

        public FastSerializableDataSet(string dataSetName) : base(dataSetName) { }

        #endregion Constructors

        #region ISerializable Members

        protected FastSerializableDataSet(SerializationInfo info, StreamingContext context)
        {
            AdoNetHelper.DeserializeDataSet(this, (byte[])info.GetValue("_", typeof(byte[])));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_", AdoNetHelper.SerializeDataSet(this));
        }

        #endregion ISerializable Members
    }
}