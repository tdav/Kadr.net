using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Xml;

namespace Kadr.LangResource
{
    [DataContract]
    public class CultureResurce
    {
        [DataMember]
        public Dictionary<string, FormResurceItem> CultureValues { get; set; }

        public void Save(string filename="")
        {
            string fp = "";
            if (filename == "")
                fp = Application.ExecutablePath + ".lang";
            else
                fp = filename;

            FileStream writer = new FileStream(fp, FileMode.Create);
            DataContractSerializer ser = new DataContractSerializer(typeof(CultureResurce));
            ser.WriteObject(writer, this);
            writer.Close();
        }

        public static CultureResurce Load(string filename="")
        {
            string fp = "";
            if (filename == "")
                fp = Application.ExecutablePath + ".lang";
            else
                fp = filename;
            
            if (File.Exists(fp))
            {
                FileStream fs = new FileStream(fp, FileMode.Open);
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(CultureResurce));

                CultureResurce deserialized = (CultureResurce)ser.ReadObject(reader, true);
                reader.Close();
                fs.Close();
                return deserialized;
            }
            else
            {
                return new CultureResurce();
            }
        }
    }
}
