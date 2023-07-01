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
    public partial class Admin : System.Web.UI.Page
    {
        /// <summary>
        /// Checks if the user is even allowed to access this page when it first loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // pulls the session cookie if authenticated correctly.
            HttpCookie userCookie = Request.Cookies["AuthCookie"];

            // if there is no cookie, just redirect to forbidden.
            if (userCookie != null)
            {
                // check for admin role before giving access to this page.
                if (userCookie["Role"] != "admin")
                {
                    Response.Redirect("~/Pages/Forbidden.aspx");
                }
            } else
            {
                Response.Redirect("~/Pages/Forbidden.aspx");
            }

            // load up all of the users and show them in the admin panel.
            userTableLiteral.Text = generateTableOfAllUsers();
        }

        /// <summary>
        /// generates table of all users in the system.
        /// 
        /// admin has the power to delete users as well by clicking the "Delete" hyperlink
        /// </summary>
        /// <returns></returns>
        private string generateTableOfAllUsers()
        {
            StringBuilder htmlBuilder = new StringBuilder();

            // pulls the session cookie if authenticated correctly.
            HttpCookie userCookie = Request.Cookies["AuthCookie"];

            // load XML document
            XmlDocument xmlDocument = new XmlDocument();
            string xmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Users.xml");
            xmlDocument.Load(xmlFilePath);

            // get root element
            XmlElement rootElement = xmlDocument.DocumentElement;

            // get all the User elements
            XmlNodeList userNodes = rootElement.SelectNodes("/Users/User");

            // build html table
            htmlBuilder.AppendLine("<table>");
            htmlBuilder.AppendLine("<tr><th>User ID</th><th>Role</th><th>Actions</th></tr>");

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

                // if the user is the one currently logged in, do NOT allow them to delete their own account!
                if (userId != userCookie["username"])
                {
                    htmlBuilder.AppendLine($"<a href=\"../Actions/DeleteUser.aspx?userId={userId}\">Delete</a>");
                }

                htmlBuilder.AppendLine("</td>");
                htmlBuilder.AppendLine("</tr>");
            }

            // Close the HTML table
            htmlBuilder.AppendLine("</table>");

            return htmlBuilder.ToString();
        }
    }
}