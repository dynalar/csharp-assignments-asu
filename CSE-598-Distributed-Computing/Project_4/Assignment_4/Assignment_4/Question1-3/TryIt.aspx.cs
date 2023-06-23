using System;
using System.Net;
using System.Text;
using System.Xml;

namespace Assignment_4.Question1_3
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Method that takes in user XML input URL and sends it to the front-end
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // get the contents of the XML passed to us.
            string xmlUrl = XmlUrlTextBox.Text;
            string xmlBody = "";

            // download the file contents from the URL
            using (WebClient webClient = new WebClient()) 
            { 
                // try catch for sending error to front end (if any)
                try
                {
                    xmlBody = webClient.DownloadString(xmlUrl);
                } catch (Exception ex)
                {
                    // send error to front end
                    ResultLabel.Text = "Failed to pull XML file. Reason: " + ex.Message;
                    return;
                }
            }

           try
            {
                // next, load the xml body into the XmlDocument class
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlBody);

                // we need the root level node, and then we will drill down into it.
                XmlNodeList allNodes = xmlDocument.SelectNodes("//root/element");

                // create a StringBuilder to build the HTML output
                StringBuilder htmlBuilder = new StringBuilder();

                // Start iterating through the nodes recursively
                XmlNode rootNode = xmlDocument.DocumentElement;

                // build an unordered list for our HTML
                parseXmlNodes(rootNode, htmlBuilder);

                // output all of our HTML we built to the front-end.
                ResultLabel.Text = htmlBuilder.ToString();

            } catch (Exception ex)
            {
                // send error to front end
                ResultLabel.Text = "Error in XML file or syntax: " + ex.Message;
                return;
            }
        }

        /// <summary>
        /// XML parsing method that also builds HTML that gets outputted to the frontend
        /// </summary>
        /// <param name="xmlNodes"></param>
        protected void parseXmlNodes(XmlNode node, StringBuilder htmlBuilder, string indent = "")
        {
            
            // add the current node and its value to the HTML output
            htmlBuilder.AppendLine("<div class=\"tree\">");
            htmlBuilder.AppendLine($"<span>{node.Name}: {node.InnerText}</span>");

            // add attributes if any are present
            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                // loop through all attributes and add them
                htmlBuilder.AppendLine("<ul class=\"attributes\">");
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    htmlBuilder.AppendLine("<li>");
                    htmlBuilder.AppendLine($"<span class=\"attribute-name\">{attribute.Name}=\"{attribute.Value}\"</span>");
                    htmlBuilder.AppendLine("</li>");
                }
                htmlBuilder.AppendLine("</ul>");
            }

            // iterate through all child nodes.
            // recursive
            foreach (XmlNode childNode in node.ChildNodes)
            {   
                // use recursion, not dangerous since an XML file will have an end
                // much simpler than using no recursion
                parseXmlNodes(childNode, htmlBuilder);
            }

            // close the content with a div
            htmlBuilder.AppendLine("</div>");
        }
    }
}