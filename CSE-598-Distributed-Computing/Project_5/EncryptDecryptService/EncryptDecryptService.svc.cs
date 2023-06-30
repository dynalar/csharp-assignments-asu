using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EncryptDecryptService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EncryptDecryptService : IEncryptDecryptService
    {
        public string encryptString(string plainText)
        {
            byte[] encryptedBytes;

            // key that we're using to encrypt along with initalization vector
            // bad practice, dont hard code keys
            string key = ConfigurationManager.AppSettings["EncryptionKey"];
            string iv = ConfigurationManager.AppSettings["EncryptionKey"];

            using (Aes aes = Aes.Create())
            {
                // use the iv and key to encrypt
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // double using() {}, not sure how to do this cleaner.
                // thank you to microsoft docs for this example.
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                        cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cs.FlushFinalBlock();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public string decryptString(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            // bad practice, dont hard code keys
            string key = ConfigurationManager.AppSettings["EncryptionKey"];
            string iv = ConfigurationManager.AppSettings["EncryptionKey"];

            // using AES library to create keys
            using (Aes aes = Aes.Create())
            {
                // usually iv is randomized, but we'll skip that for now
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                // create decryptor with our aes key and iv
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // ugly nested using {}, is this ok????
                using (MemoryStream ms = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                        {
                            string decryptedText = reader.ReadToEnd();
                            return decryptedText;
                        }
                    }
                }
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
