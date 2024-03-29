﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Data;
using System.Net;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Configuration;

namespace PhoneNotificationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PhoneNotificationService : IPhoneNotificationService
    {
        // carrier consts
        private static readonly string tmobile = "@tmomail.net";
        private static readonly string att = "@txt.att.net";
        private static readonly string verizon = "@vtext.com";
        private static readonly string boost = "@smsmyboostmobile.com";
        private static readonly string cricket = "@sms.cricketwireless.net";
        private static readonly string sprint = "@messaging.sprintpcs.com";
        private static readonly string uscc = "@email.uscc.net";
        private static readonly string virgin = "@vmobl.com";

        /// <summary>
        /// gets the items from the notifications
        /// 0 - phone number
        /// 1 - carrier
        /// 2 - latitude
        /// 3 - longitude
        /// 4 - newTemperature
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="newTemperature"></param>
        public string sendPhoneNotificationText(string phoneNumber, string newTemperature)
        {
            // read all of the items from csv file, fine 
            List<string[]> subscribedPhoneNumbers = readCsvFile();

            // loop through the suscribed phoneNumber, compare to new temperature.
            foreach (string[] subscribedPhoneNumber in subscribedPhoneNumbers)
            {
                string decryptedPhoneNumber = decryptPhoneNumber(subscribedPhoneNumber[0]);

                // check if phone matches decrypted number
                if(decryptedPhoneNumber == phoneNumber)
                {
                    string carrier = subscribedPhoneNumber[1];
                    string previousTemperature = subscribedPhoneNumber[4];

                    // google smtp configuration
                    // made a google account for this project to leverage smtp gateway
                    string smtpPassword = ConfigurationManager.AppSettings["GoogleSMTPPassword"];
                    string smtpEmail = ConfigurationManager.AppSettings["GoogleSMTPEmail"];

                    // if there is a temperature change, send notification
                    if (Int32.Parse(newTemperature) > Int32.Parse(subscribedPhoneNumber[4]) || Int32.Parse(newTemperature) < Int32.Parse(subscribedPhoneNumber[4]))
                    {
                        // send notification text message of temperature change
                        MailMessage message = new MailMessage("bantillo@asu.edu", phoneNumber + getCorrectEmailDomain(carrier), "Temperature Update", "Temperature has changed to " + newTemperature);

                        // Create a new SmtpClient object
                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                        // Set the credentials from smtp server, in this case gmail
                        smtpClient.Credentials = new NetworkCredential(smtpEmail, smtpPassword);

                        // Enable SSL
                        smtpClient.EnableSsl = true;

                        try
                        {
                            // Send the email
                            smtpClient.Send(message);
                            return "Notification sent successfully! It may take a couple of minutes for it to arrive to your phone via SMS.";
                        }
                        catch (Exception ex)
                        {
                            return "Error sending notification: " + ex.Message;
                        }
                    }
                }
            }
            return "Notification action completed";
        }

        public string getCorrectEmailDomain(string carrier)
        {
            switch (carrier)
            {
                case "tmobile":
                    return tmobile;
                case "att":
                    return att;
                case "verizon":
                    return verizon;
                case "boost":
                    return boost;
                case "cricket":
                    return cricket;
                case "sprint":
                    return sprint;
                case "uscc":
                    return uscc;
                case "virgin":
                    return virgin;
                default:
                    return "invalid";
            }
        }

        public void registerPhoneNumberNotification(string phoneNumber, string carrier, string latLocation, string longLocation, string currentTemperature)
        {
            // register our phone number for text notifications by writing it into a csv file
               
            // encrypt the phone number and insert it into our csv file.
            List<string[]> dataRows = new List<string[]>
            { 
                new string[] { encryptPhoneNumber(phoneNumber), carrier, latLocation, longLocation, currentTemperature },
            };

            WriteToCsvFile(dataRows);
        }

        public static void WriteToCsvFile(List<string[]> dataRows)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "phoneNumbers.csv");
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                foreach (string[] row in dataRows)
                {
                    string csvLine = string.Join(",", row);
                    writer.WriteLine(csvLine);
                }
            }
        }

        public static List<string[]> readCsvFile()
        {
            // create a new list to read from our file
            List<string[]> csvRows = new List<string[]>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "phoneNumbers.csv");

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] fields = line.Split(',');
                    csvRows.Add(fields);
                }
            }

            return csvRows;
        }

        /// <summary>
        /// THIS CODE WILL BE REMOVED IN FUTURE ASSIGNMENT, THIS WILL BE THE ENCRYPTION/DECRYPTION SERVICE
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string encryptPhoneNumber(string plainText)
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

                // double using loop, not sure how to do this cleaner.
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

        /// <summary>
        /// THIS CODE WILL BE REMOVED IN FUTURE ASSIGNMENT, THIS WILL BE THE ENCRYPTION/DECRYPTION SERVICE
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public string decryptPhoneNumber(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            // bad practice, dont hard code keys
            string key = ConfigurationManager.AppSettings["EncryptionKey"];
            string iv = ConfigurationManager.AppSettings["EncryptionKey"];

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

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
