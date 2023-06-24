using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4.Question3
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            XmlXsdValidatorServiceRef.XMLXSDValidatorServiceClient xmlValidator = new XmlXsdValidatorServiceRef.XMLXSDValidatorServiceClient();

            string encodedXmlUrl = HttpUtility.UrlPathEncode(XmlTextBox.Text);
            string encodedXsdUrl = HttpUtility.UrlPathEncode(XsdTextBox.Text);

            string validatorResponse = xmlValidator.ValidateXMLToXSD(encodedXmlUrl, encodedXsdUrl);

            ResultLiteral.Text = validatorResponse;
        }
    }
}