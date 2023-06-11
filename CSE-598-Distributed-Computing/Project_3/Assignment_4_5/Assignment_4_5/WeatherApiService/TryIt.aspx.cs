using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4_5.WeatherApiService
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get the values from the text boxes
            string latitude = LatitudeTextBox.Text;
            string longitude = LongitudeTextBox.Text;

            // call the service reference to get our weather


            // Display the result
            ResultLiteral.Text = $"Latitude: {latitude}, Longitude: {longitude}";
        }
    }
}