using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Runtime;
using System.Xml;
using System.Xml.Schema;

namespace XMLXSDValidatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class XMLXSDValidatorService : IXMLXSDValidatorService
    {
        private string validationMessage;

        /// <summary>
        /// method that returns proper message to the front-end consuming this service.
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
                    return "Succesfully validated XML against XSD Schema!";
                }
                else
                {
                    return "XML does not match the XSD schema provided. More information: " + validationMessage;
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

        /// <summary>
        /// method in charge of running actual validation of XML against XSD
        /// </summary>
        /// <param name="xmlUrl"></param>
        /// <param name="xsdUrl"></param>
        /// <returns></returns>
        public bool ValidateXmlToXsd(string xmlUrl, string xsdUrl)
        {
            try
            {
                // pull contents of XML link
                string xmlContent;
                using (WebClient xmlClient = new WebClient())
                {
                    xmlContent = xmlClient.DownloadString(xmlUrl);
                }

                // pull contents of XSD link
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

                // according to MS documentation, these are proper settings for extra validation of xml files.
                readerSettings.ValidationType = ValidationType.Schema;
                readerSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                readerSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                readerSettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                readerSettings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

                // Create an XmlReader for the XML content
                XmlReader xmlReader = XmlReader.Create(new StringReader(xmlContent), readerSettings);
                
                // iterate through the reader and read the file until an exception is raised
                // we can add extra validation here, but it won't be necessary since we're just looking for exceptions.
                while (xmlReader.Read()) { } ;

                // if no exception occurred, we'll just return true since everything was ok.
                return true;
            } catch(Exception e)
            {
                // Handle any exceptions that occurred during validation
                validationMessage = "XML validation error: " + e.Message;
                return false;
            }
        }

        // Display any warnings or errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {
                Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
            } else
            {
                Console.WriteLine("\tValidation error: " + args.Message);
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
