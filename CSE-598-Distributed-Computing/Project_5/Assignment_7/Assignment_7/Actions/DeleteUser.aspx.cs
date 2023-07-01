using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Assignment_7.Actions
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get the userId from the query string
            string userId = Request.QueryString["userId"];

            // get the path to the XML file and load it
            string xmlFilePath = Server.MapPath("~/App_Data/Users.xml");
            XmlDocument usersXmlDocument = new XmlDocument();
            usersXmlDocument.Load(xmlFilePath);

            // find the user node with the specified ID
            XmlNode userNode = usersXmlDocument.SelectSingleNode($"//User[Credential/ID = '{userId}']");

            // delete the user node if found in the xml file by iterating through it
            if (userNode != null)
            {
                XmlNode parentNode = userNode.ParentNode;
                parentNode.RemoveChild(userNode);

                // save the changes to the XML file
                usersXmlDocument.Save(xmlFilePath);
            }

            // redirect back to the user list page with the updated list.
            Response.Redirect("~/Pages/Admin.aspx");
        }
    }
}