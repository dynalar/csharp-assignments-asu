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
        public bool userAlreadyExists = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            // clear any previous login error messages if necessary
            userAlreadyExists = false;
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
                // encrypt our password before creating the user
                encryptedPassword = callEncryptionService(password);
                storeCredentialsToXmlDatabase(username, encryptedPassword);

                // check if the user already exists. based off a flag that is set in our code.
                if(userAlreadyExists)
                {
                    errorMessageLabel.Text = "Username already exists!";
                } else
                {
                    successMessageLabel.Text = "Account successfully created! Try logging in.";
                }
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
            string usersXmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Users.xml");
            XmlDocument xmlDocument = new XmlDocument();


            xmlDocument.Load(usersXmlFilePath);

            // check if the user already exists in the XML file
            if (UserExists(xmlDocument, username))
            {
                // user already exists, skip adding it by setting flag
                userAlreadyExists = true;
                return;
            }


            // set up and add our credential elements
            XmlElement userElement = xmlDocument.CreateElement("User");
            XmlElement credentialElement = xmlDocument.CreateElement("Credential");
            XmlElement idElement = xmlDocument.CreateElement("ID");
            idElement.InnerText = username;
            credentialElement.AppendChild(idElement);

            // create the roles element and the role element
            XmlElement rolesElement = xmlDocument.CreateElement("Roles");
            XmlElement roleElement = xmlDocument.CreateElement("Role");

            // give a default role of "user" for every user created.
            roleElement.InnerText = "user";

            // append the role element to the roles element
            rolesElement.AppendChild(roleElement);

            // append the roles element to the credential element
            credentialElement.AppendChild(rolesElement);

            // create the password element
            XmlElement passwordElement = xmlDocument.CreateElement("Password");
            passwordElement.InnerText = password;

            // append the credentials
            credentialElement.AppendChild(passwordElement);
            userElement.AppendChild(credentialElement);

            // append the user element to the root element
            xmlDocument.DocumentElement.AppendChild(userElement);

            // Save the XML document
            xmlDocument.Save(usersXmlFilePath);
        }

        /// <summary>
        /// checks the XML file to see if the ID ("username") is already in the db.
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        private bool UserExists(XmlDocument xmlDocument, string username)
        {
            // get all the usernames and check if they exist
            XmlNodeList userNodes = xmlDocument.SelectNodes("//User/Credential/ID");

            // return true if username already exists
            foreach (XmlNode idNode in userNodes)
            {
                if (idNode.InnerText == username)
                {
                    return true;
                }
            }

            // return false if user doesn't exist.
            return false;
        }
    }
}