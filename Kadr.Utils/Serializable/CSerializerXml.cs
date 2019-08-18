using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Apteka.Utils.Serialization
{

    public static class CObjectXmlSerializer<T> where T : class
    {
        public static T Load(string path)
        {
            T serializableObject = LoadFromDocumentFormat(null, path, null);
            return serializableObject;
        }

        public static void Save(T serializableObject, string path)
        {
            SaveToDocumentFormat(serializableObject, null, path, null);
        }

        public static T LoadFromDocumentFormat(System.Type[] extraTypes, string path, IsolatedStorageFile isolatedStorageFolder)
        {
            T serializableObject = null;

            using (var textReader = CreateTextReader(isolatedStorageFolder, path))
            {
                var xmlSerializer = CreateXmlSerializer(extraTypes);
                serializableObject = xmlSerializer.Deserialize(textReader) as T;

            }
            return serializableObject;
        }

        public static XmlSerializer CreateXmlSerializer(System.Type[] extraTypes)
        {
            Type objectType = typeof(T);

            XmlSerializer xmlSerializer = null;

            xmlSerializer = extraTypes != null ? new XmlSerializer(objectType, extraTypes) : new XmlSerializer(objectType);

            return xmlSerializer;
        }

        public static void SaveToDocumentFormat(T serializableObject, System.Type[] extraTypes, string path, IsolatedStorageFile isolatedStorageFolder)
        {
            using (TextWriter textWriter = CreateTextWriter(isolatedStorageFolder, path))
            {
                XmlSerializer xmlSerializer = CreateXmlSerializer(extraTypes);
                xmlSerializer.Serialize(textWriter, serializableObject);
            }
        }
        private static TextReader CreateTextReader(IsolatedStorageFile isolatedStorageFolder, string path)
        {
            TextReader textReader = null;

            textReader = isolatedStorageFolder == null ? new StreamReader(path) : new StreamReader(new IsolatedStorageFileStream(path, FileMode.Open, isolatedStorageFolder));

            return textReader;
        }

        private static TextWriter CreateTextWriter(IsolatedStorageFile isolatedStorageFolder, string path)
        {
            TextWriter textWriter = null;

            textWriter = isolatedStorageFolder == null ? new StreamWriter(path) : new StreamWriter(new IsolatedStorageFileStream(path, FileMode.OpenOrCreate, isolatedStorageFolder));

            return textWriter;
        }
    }

   }
