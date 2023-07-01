using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_7.Actions
{
    public partial class SaveFavoriteLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["AuthCookie"];

            string username = userCookie["username"];
            string name = Request.QueryString["name"];
            string directions = Request.QueryString["directions"];

            string usersXmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Users.xml");

            // Load the XML document
            XmlDocument usersXmlDocument = new XmlDocument();
            usersXmlDocument.Load(usersXmlFilePath);

            // Find the user element with the specified ID
            XmlNodeList userNodes = usersXmlDocument.SelectNodes("/Users/User[Credential/ID='" + username + "']");

            foreach (XmlNode userNode in userNodes)
            {
                // Find the FavoriteLocations node within the user element
                XmlNode favoriteLocationsNode = userNode.SelectSingleNode("FavoriteLocations");

                // Create the FavoriteLocations node if it doesn't exist
                if (favoriteLocationsNode == null)
                {
                    favoriteLocationsNode = usersXmlDocument.CreateElement("FavoriteLocations");
                    userNode.AppendChild(favoriteLocationsNode);
                }

                // Create the Location node for the favorite location
                XmlNode locationNode = usersXmlDocument.CreateElement("Location");

                // Create the Name element and set its value
                XmlNode nameNode = usersXmlDocument.CreateElement("Name");
                nameNode.InnerText = name;
                locationNode.AppendChild(nameNode);

                // Create the Directions element and set its value
                XmlNode directionsNode = usersXmlDocument.CreateElement("Directions");
                directionsNode.InnerText = HttpUtility.HtmlEncode(directions);
                locationNode.AppendChild(directionsNode);

                // Append the Location node to the FavoriteLocations node
                favoriteLocationsNode.AppendChild(locationNode);
            }

            // Save the modified XML document
            usersXmlDocument.Save(usersXmlFilePath);

            // redirect back to the user list page with the updated list.
            Response.Redirect("~/Pages/Favorites.aspx");
        }
    }
}