using Apteka.Utils;

namespace Kadr.Utils.Serializable
{
    public static class CSerializer<T> where T : class
    {
        public static T Load(string path)
        {
            var data = CFile.GetFileContents(path);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
        }

        public static void Save(T serializableObject, string path)
        {
            var data = Newtonsoft.Json.JsonConvert.SerializeObject(serializableObject, Newtonsoft.Json.Formatting.Indented);
            CFile.SaveFile(data, path);
        }
    }
}
