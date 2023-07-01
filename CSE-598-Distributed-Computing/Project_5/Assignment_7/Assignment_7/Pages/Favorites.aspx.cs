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
    public partial class Favorites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // pulls the session cookie if authenticated correctly.
            HttpCookie userCookie = Request.Cookies["AuthCookie"];

            // if there is no cookie, just redirect to forbidden.
            if (userCookie == null)
            {
                Response.Redirect("~/Pages/Forbidden.aspx");
            }

            // load up all of the users and show them in the admin panel.
            favoriteLocationsLiteral.Text = generateFavoritesTable(userCookie["username"]);
        }

        /// <summary>
        /// Generates the HTML table that shows all saved favorites locations.
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private string generateFavoritesTable(string username)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            // Load the XML document
            XmlDocument doc = new XmlDocument();
            string xmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Users.xml");
            doc.Load(xmlFilePath);

            // Find the user element with the specified ID
            XmlNode userNode = doc.SelectSingleNode("/Users/User[Credential/ID='" + username + "']");

            if (userNode != null)
            {
                // Find the FavoriteLocations node within the user element
                XmlNode favoriteLocationsNode = userNode.SelectSingleNode("FavoriteLocations");

                if (favoriteLocationsNode != null)
                {
                    // Get all Location nodes within the FavoriteLocations node
                    XmlNodeList locationNodes = favoriteLocationsNode.SelectNodes("Location");

                    // Generate the HTML table
                    htmlBuilder.AppendLine("<table>");
                    htmlBuilder.AppendLine("<tr><th>Name</th><th>Directions</th></tr>");

                    foreach (XmlNode locationNode in locationNodes)
                    {
                        string name = locationNode.SelectSingleNode("Name").InnerText;
                        string directions = locationNode.SelectSingleNode("Directions").InnerText;

                        // Append a new table row for each location
                        htmlBuilder.AppendLine("<tr>");
                        htmlBuilder.AppendLine("<td>" + name + "</td>");
                        htmlBuilder.AppendLine("<td>" + directions + "</td>");
                        htmlBuilder.AppendLine("</tr>");
                    }

                    htmlBuilder.AppendLine("</table>");
                }
            }

            return htmlBuilder.ToString();
        }
    }
}