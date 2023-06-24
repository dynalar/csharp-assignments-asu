using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Schema;

namespace XMLXSDValidatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class XMLXSDValidatorService : IXMLXSDValidatorService
    {
        /// <summary>
        /// Endpoint that validates XML to an XSD file.
        /// </summary>
        /// <param name="xmlUrl"></param>
        /// <param name="xsdUrl"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string ValidateXMLToXSD(string xmlUrl, string xsdUrl)
        {
            // get validation status, as a bool
            try
            {
                bool validationStatus = ValidateXmlToXsd(xmlUrl, xsdUrl);
                if (validationStatus)
                {
                    return "Success!";
                }
                else
                {
                    return "False";
                }
            } catch(Exception e)
            {
                return "Failed to validate XML against XSD. Reason: " + e.Message;
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public bool ValidateXmlToXsd(string xmlUrl, string xsdUrl)
        {
            try
            {
                // pull both of our files 
                string xmlContent;
                using (WebClient xmlClient = new WebClient())
                {
                    xmlContent = xmlClient.DownloadString(xmlUrl);
                }

                // Download the XSD schema file
                string xsdContent;
                using (WebClient xsdClient = new WebClient())
                {
                    xsdContent = xsdClient.DownloadString(xsdUrl);
                }

                // Create an XmlSchemaSet and add the XSD schema to it
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add("", XmlReader.Create(new StringReader(xsdContent)));

                // Create XmlReaderSettings and specify the schema set for validation
                XmlReaderSettings readerSettings = new XmlReaderSettings();
                readerSettings.ValidationType = ValidationType.Schema;
                readerSettings.Schemas = schemaSet;

                // Create an XmlReader for the XML content
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlContent), readerSettings))
                {
                    // Read the XML content, performing the validation
                    while (reader.Read())
                    {
                        // Perform validation here (if required)
                    }
                }

                // If no exception occurred during validation, the XML is valid
                return true;
            } catch(Exception e)
            {
                // Handle any exceptions that occurred during validation
                Console.WriteLine("XML validation error: " + e.Message);
                return false;
            }
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
