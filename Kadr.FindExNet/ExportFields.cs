using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Kadr.FindExNet
{
    [Serializable]
    public class SerExportFields
    {
        public bool Visible { get; set; }
        public string FieldName { get; set; }
        public string DisplayName { get; set; }
    }

    [Serializable]
    public class SerListExportFields : List<SerExportFields>
    {
        public void Save()
        {
            string fn = AppDomain.CurrentDomain.BaseDirectory + "Sef.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(SerListExportFields));
            using (TextWriter writer = new StreamWriter(fn))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static SerListExportFields Load()
        {
            try
            {
                string fn = AppDomain.CurrentDomain.BaseDirectory + "Sef.xml";
                if (!File.Exists(fn))
                    return new SerListExportFields();
                XmlSerializer mySerializer = new XmlSerializer(typeof(SerListExportFields));
                using (FileStream myFileStream = new FileStream(fn, FileMode.Open))
                {
                    return (SerListExportFields)mySerializer.Deserialize(myFileStream);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }


}