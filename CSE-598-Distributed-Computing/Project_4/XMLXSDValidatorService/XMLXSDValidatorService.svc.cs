using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Runtime;
using System.Xml;
using System.Xml.Linq;
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
                    return validationMessage;
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
            bool validationErrors = false;

            try
            {
                // Create an XmlReaderSettings object and enable schema validation
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;

                // load up the XSD schema for validation.
                XmlSchemaSet schemas = new XmlSchemaSet();

                using (var client = new WebClient())
                {
                    Stream xsdFileStream = client.OpenRead(xsdUrl);

                    schemas.Add(null, XmlReader.Create(xsdFileStream));
                    settings.Schemas = schemas;
                }

                XDocument xmlDocument = XDocument.Load(xmlUrl);
                xmlDocument.Validate(schemas, (s, e) =>
                {
                    Console.WriteLine(e.Message);
                    validationErrors = true;
                    validationMessage = e.Message;
                });

                if (validationErrors)
                {
                    validationMessage = "Validation failed. Reason: " + validationMessage;
                }
                else
                {
                    validationMessage = "Validation succeeded";
                }

                // all xml is valid
                return true;
            }
            catch (Exception ex)
            {
                // only if error occurs
                validationMessage = "Error with schema or XML. Reason: " + ex.Message;
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
