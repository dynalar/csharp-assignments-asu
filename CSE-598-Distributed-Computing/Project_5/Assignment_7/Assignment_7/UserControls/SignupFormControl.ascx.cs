using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Web.UI.WebControls;
using System.Xml;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Net;

namespace Assignment_7.UserControls
{
    public partial class SignUpFormControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // clear any previous login error messages if necessary
            successMessageLabel.Text = string.Empty;
            errorMessageLabel.Text = string.Empty;
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            // get the entries from the username/pw fields
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;
            string encryptedPassword;

            // simple validation, if any of the fields are empty then return a message to the front end
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                errorMessageLabel.Text = "Please enter both username and password.";
                return;
            }

            // if signup passes, save the user to the "database" (just an xml file)
            try
            {
                encryptedPassword = callEncryptionService(password);
                storeCredentialsToXmlDatabase(username, encryptedPassword);
                successMessageLabel.Text = "Account successfully created! Try logging in.";
            } catch (Exception ex)
            {
                errorMessageLabel.Text = "Failed to encrypt password: Reason: " + ex.Message;
                return;
            }

            storeCredentialsToXmlDatabase(username, encryptedPassword);
        }

        protected string callEncryptionService(string password)
        {
            string encryptionServiceUrl = ConfigurationManager.AppSettings["EncryptionSvcUrl"];
            string encryptedString;

            using (WebClient webClient = new WebClient())
            {

                // try catch for sending error to front end (if any)
                try
                {
                    encryptedString = webClient.DownloadString(encryptionServiceUrl + password);
                }
                catch (Exception ex)
                {
                    // send error to front end
                    throw ex;
                }
            }

            return encryptedString;
        }

        /// <summary>
        /// Add the user login info to our XML database of users.
        /// 
        /// For XML structure, we are following the same structure I defined in Assignment 6, with small modifications.
        /// 
        /// We are using the ASU Encryption Repository Service to Encrypt passwords in the XML file.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        private void storeCredentialsToXmlDatabase(string username, string password)
        {
            // get the xml file path of the Users.xml file that is stored in our app_data
            // much better way than what I was doing before of building the path manually.
            string usersXmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Users.xml");

            // create our xml document
            XmlDocument xmlDocument = new XmlDocument();

            // load our xml file. we will always make it.
            xmlDocument.Load(usersXmlFilePath);

            // get root xml element, Users
            XmlElement rootElement = xmlDocument.DocumentElement;

            // create a new user element
            XmlElement userElement = xmlDocument.CreateElement("User");

            // create the credential element
            XmlElement credentialElement = xmlDocument.CreateElement("Credential");

            // create and append the ID element
            XmlElement idElement = xmlDocument.CreateElement("ID");
            idElement.InnerText = username;
            credentialElement.AppendChild(idElement);

            // create and append the Password element
            XmlElement passwordElement = xmlDocument.CreateElement("Password");
            passwordElement.InnerText = password;
            credentialElement.AppendChild(passwordElement);

            // append the credential element to the user element
            userElement.AppendChild(credentialElement);

            // append the user element to the root element
            rootElement.AppendChild(userElement);

            // save the XML document
            xmlDocument.Save(usersXmlFilePath);
        }
    }
}