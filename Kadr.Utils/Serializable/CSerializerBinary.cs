using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Apteka.Utils.CSerializerBinary
{ 
    public static class CBinSerializer<T> where T : class
    {
        // Мы объявляем параметр со спецификатором ref, а не out, 
        // потому что нам нужен его адрес, а ключевое слово
        // __makeref требует инициализированное значение.
        public static unsafe void ReadPointerTypedRef<T>(byte[] data, int offset, ref T value)
        {
            // В действительности мы не изменяем 'value' - нам просто 
            // требуется левостороннее значение
            TypedReference tr = __makeref(value);

            fixed (byte* ptr = &data[offset])
            {
                // Первое поле - указатель в структуре TypedReference - это 
                // адрес объекта, поэтому мы записываем в него 
                // указатель на нужный элемент в массиве с данными
                *(IntPtr*)&tr = (IntPtr)ptr;

                // __refvalue копирует указатель из TypedReference в 'value'
                value = __refvalue(tr, T);
            }
        }

        public static T LoadFromBinaryMem(byte[] bin)
        {
            T serializableObject = null;

            using (MemoryStream ms = new MemoryStream(bin))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                serializableObject = binaryFormatter.Deserialize(ms) as T;
            }

            return serializableObject;
        }

        public static byte[] SaveToBinaryMem(T serializableObject)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(ms, serializableObject);
                return ms.GetBuffer();
            }
        }

        public static T LoadFromBinaryFormat(string path, IsolatedStorageFile isolatedStorageFolder)
        {
            T serializableObject = null;

            using (FileStream fileStream = CreateFileStream(isolatedStorageFolder, path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                serializableObject = binaryFormatter.Deserialize(fileStream) as T;
            }

            return serializableObject;
        }

        public static FileStream CreateFileStream(IsolatedStorageFile isolatedStorageFolder, string path)
        {
            FileStream fileStream = null;

            if (isolatedStorageFolder == null)
                fileStream = new FileStream(path, FileMode.OpenOrCreate);
            else
                fileStream = new IsolatedStorageFileStream(path, FileMode.OpenOrCreate, isolatedStorageFolder);

            return fileStream;
        }
    }
}
