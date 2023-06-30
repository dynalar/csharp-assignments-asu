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
    public partial class LoginFormControl : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // clear any previous login error messages if necessary
            successMessageLabel.Text = string.Empty;
            errorMessageLabel.Text = string.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                errorMessageLabel.Text = "Please enter both username and password.";
                return;
            } else
            {
                // attempt to authenticate user.
                if(attemptToAuthenticateUser(username, password))
                {
                    successMessageLabel.Text = "Authenticated!";
                } else
                {
                    errorMessageLabel.Text = "Incorrect username or password. Please try again or sign up.";
                }
            }
        }

        /// <summary>
        /// Method that attempts to authenticate the user.
        /// 
        /// Uses ASU decryption REST service to check if the password is correct.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <exception cref="NotImplementedException"></exception>
        private bool attemptToAuthenticateUser(string username, string password)
        {
            // load up our xml file of users
            string xmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Users.xml");
            XmlDocument usersXmlDocument = new XmlDocument();
            usersXmlDocument.Load(xmlFilePath);

            // select all of the elements that have our users. we will loop through this.
            XmlNodeList userNodes = usersXmlDocument.SelectNodes("/Users/User");

            // loop through all of the users in our XML "database"
            foreach(XmlNode userNode in userNodes)
            {
                // get the username node based off the one that was entered.
                XmlNode usernameNode = userNode.SelectSingleNode("Credential/ID");
                XmlNode passwordNode = userNode.SelectSingleNode("Credential/Password");

                // if the username matches the one entered, then we verify the password.
                if(usernameNode.InnerText == username)
                {
                    // we compare the encrypted entered password to the encrypted password in the xml file.
                    // if the hashes dont match, failure is returned.
                    string encryptedEnteredPassword = callEncryptionService(password);
                    if(passwordNode.InnerText == encryptedEnteredPassword)
                    {
                        return true;
                    }

                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Same as the one in the Signup Form Control
        /// 
        /// We encrypt the entered password, and compare the encrypted hashes.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string callEncryptionService(string password)
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
    }
}