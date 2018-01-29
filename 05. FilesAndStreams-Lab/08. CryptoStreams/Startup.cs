namespace _08._CryptoStreams
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class Startup
    {
        private const string Text = "This is CSharp Advanced!";
        private const string EncryptionKey = "ABCDEFGH";
        private const string FilePath = "file.txt";

        public static void Main()
        {
            SaveEncrypted(Text, EncryptionKey, FilePath);
            string result = Decrypt(EncryptionKey, FilePath);
            Console.WriteLine(result);
        }

        private static string Decrypt(string encryptionKey, string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            using (fileStream)
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                cryptoProvider.Key = Encoding.ASCII.GetBytes(encryptionKey);
                cryptoProvider.IV = Encoding.ASCII.GetBytes(encryptionKey);
                CryptoStream cryptoStream = new CryptoStream(fileStream, cryptoProvider.CreateDecryptor(), CryptoStreamMode.Read);
                using (cryptoStream)
                {
                    StreamReader reader = new StreamReader(cryptoStream);
                    using (reader)
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        private static void SaveEncrypted(string text, string encryptionKey, string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            using (fileStream)
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                cryptoProvider.Key = Encoding.ASCII.GetBytes(encryptionKey);
                cryptoProvider.IV = Encoding.ASCII.GetBytes(encryptionKey);

                CryptoStream cryptoStream = new CryptoStream(fileStream, cryptoProvider.CreateEncryptor(), CryptoStreamMode.Write);
                using (cryptoStream)
                {
                    byte[] data = Encoding.ASCII.GetBytes(text);
                    cryptoStream.Write(data, 0, data.Length);
                }
            }
        }
    }
}