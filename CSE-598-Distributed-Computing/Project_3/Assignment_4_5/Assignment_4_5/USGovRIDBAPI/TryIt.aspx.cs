using Assignment_4_5.WeatherServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4_5.USGovRIDBAPI
{
    public partial class TryIt : System.Web.UI.Page
    {
        RecreationAreaServiceRef.RecreationAreaServiceClient ridbServiceRef = new RecreationAreaServiceRef.RecreationAreaServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get the values from the text boxes
            string query = QueryTextBox.Text.Trim();
            string states = StateTextBox.Text.Trim();

            // call the service reference to get our weather
            string recreationAreaResponse = ridbServiceRef.GetRecreationAreas(query, states);

            // Display the result
            ResultLiteral.Text = $"Recreation Service Response: {recreationAreaResponse}";
        }
    }
}