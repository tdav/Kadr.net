using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Apteka.Utils
{
    public class CAESEncryption
    {
        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="PlainText">Text to be encrypted</param>
        /// <param name="Password">Password to encrypt with</param>
        /// <param name="Salt">Salt to encrypt with</param>
        /// <param name="HashAlgorithm">Can be either SHA1 or MD5</param>
        /// <param name="PasswordIterations">Number of iterations to do</param>
        /// <param name="InitialVector">Needs to be 16 ASCII characters long</param>
        /// <param name="KeySize">Can be 128, 192, or 256</param>
        /// <returns>An encrypted string</returns>
        private static string EncryptEx(string PlainText, string Password, string Salt, string HashAlgorithm, int PasswordIterations, string InitialVector, int KeySize)
        {
            try
            {
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
                byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
                PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
                byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
                RijndaelManaged SymmetricKey = new RijndaelManaged
                {
                    Mode = CipherMode.CBC
                };
                ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, null);
                MemoryStream MemStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] CipherTextBytes = MemStream.ToArray();
                MemStream.Close();
                cryptoStream.Close();
                MemStream.Dispose();
                cryptoStream.Dispose();
                Encryptor.Dispose();
                return Convert.ToBase64String(CipherTextBytes);
            }
            catch (Exception a)
            {
                throw a;
            }
        }

        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="CipherText">Text to be decrypted</param>
        /// <param name="Password">Password to decrypt with</param>
        /// <param name="Salt">Salt to decrypt with</param>
        /// <param name="HashAlgorithm">Can be either SHA1 or MD5</param>
        /// <param name="PasswordIterations">Number of iterations to do</param>
        /// <param name="InitialVector">Needs to be 16 ASCII characters long</param>
        /// <param name="KeySize">Can be 128, 192, or 256</param>
        /// <returns>A decrypted string</returns>
        private static string DecryptEx(string CipherText, string Password, string Salt, string HashAlgorithm, int PasswordIterations, string InitialVector, int KeySize)
        {
            try
            {
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
                byte[] CipherTextBytes = Convert.FromBase64String(CipherText);
                PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
                byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
                RijndaelManaged SymmetricKey = new RijndaelManaged
                {
                    Mode = CipherMode.CBC
                };
                ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, null);
                MemoryStream MemStream = new MemoryStream(CipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read);
                byte[] PlainTextBytes = new byte[CipherTextBytes.Length];
                int ByteCount = cryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
                MemStream.Close();
                cryptoStream.Close();
                MemStream.Dispose();
                cryptoStream.Dispose();
                Decryptor.Dispose();
                return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount);
            }
            catch (Exception a)
            {
                throw a;
            }
        }

        public static string Encrypt(string PlainText, string Password)
        {
            return EncryptEx(PlainText, Password, "Asbt.Utils.CAESEncryption", "MD5", 15, "This hotfix is for Microsoft Visual Studio 2013 Ultimate - ENU.", 256);
        }

        public static string Decrypt(string PlainText, string Password)
        {
            return DecryptEx(PlainText, Password, "Asbt.Utils.CAESEncryption", "MD5", 15, "This hotfix is for Microsoft Visual Studio 2013 Ultimate - ENU.", 256);
        }
    }
}