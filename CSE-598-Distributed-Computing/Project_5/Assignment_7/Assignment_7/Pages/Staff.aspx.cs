using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Assignment_7.Pages
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // pulls the session cookie if authenticated correctly.
            HttpCookie userCookie = Request.Cookies["AuthCookie"];

            // if there is no cookie, just redirect to forbidden.
            if (userCookie != null)
            {
                // check for admin role before giving access to this page.
                if (userCookie["Role"] != "staff" && userCookie["Role"] != "admin")
                {
                    Response.Redirect("~/Pages/Forbidden.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Pages/Forbidden.aspx");
            }

            // load up all of the users and show them in the admin panel.
            userTableLiteral.Text = generateTableOfAllUsers();
        }

        /// <summary>
        /// generates a table using html builder of all users.
        /// 
        /// this is specifically for the staff. they CANNOT delete users.
        /// </summary>
        /// <returns></returns>
        private string generateTableOfAllUsers()
        {
            StringBuilder htmlBuilder = new StringBuilder();

            // Load the XML document
            XmlDocument xmlDocument = new XmlDocument();
            string xmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Users.xml");
            xmlDocument.Load(xmlFilePath);

            // Get the root element
            XmlElement rootElement = xmlDocument.DocumentElement;

            // Get all the User elements
            XmlNodeList userNodes = rootElement.SelectNodes("/Users/User");

            // Start building the HTML table
            htmlBuilder.AppendLine("<table>");
            htmlBuilder.AppendLine("<tr><th>User ID</th><th>Role</th></tr>");

            // Iterate over each User element
            foreach (XmlNode userNode in userNodes)
            {
                // Get the ID and Role values
                string userId = userNode.SelectSingleNode("Credential/ID").InnerText;
                string userRole = userNode.SelectSingleNode("Credential/Roles/Role").InnerText;

                // Append a table row with the user's ID, Role, and delete hyperlink
                htmlBuilder.AppendLine("<tr>");
                htmlBuilder.AppendLine($"<td>{userId}</td>");
                htmlBuilder.AppendLine($"<td>{userRole}</td>");
                htmlBuilder.AppendLine("<td>");
                htmlBuilder.AppendLine("</td>");
                htmlBuilder.AppendLine("</tr>");
            }

            // Close the HTML table
            htmlBuilder.AppendLine("</table>");

            return htmlBuilder.ToString();
        }
    }
}