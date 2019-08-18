using System.Security.Cryptography;
using System.Text;

namespace Apteka.Utils
{
    public static class CHash
    {
        public static string EncryptMD5(string Text)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(Text));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public class HashSha256
        {
            private static string Salt = "lsdhfbiu wiruhwi4h39@#$%284h 234 u234289  fk sj skdfdhfsldhf";

            public static string Get(string str)
            {
                var crypt = new SHA256Managed();
                var hash = new StringBuilder();

                str += Salt;
                var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetByteCount(str));

                foreach (byte theByte in crypto)
                {
                    hash.Append(theByte.ToString("x2"));
                }
                return hash.ToString();
            }
        }
    }
}
