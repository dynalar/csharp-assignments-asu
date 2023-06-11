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
        // instantiate our weather service reference
        public WeatherServiceRef.WeatherServiceClient weatherServiceClient = new WeatherServiceRef.WeatherServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get the values from the text boxes
            string latitude = LatitudeTextBox.Text.Trim();
            string longitude = LongitudeTextBox.Text.Trim();

            // call the service reference to get our weather
            string weatherClientResponse = weatherServiceClient.GetWeather(latitude, longitude);

            // Display the result
            ResultLiteral.Text = $"Weather API Response: {weatherClientResponse}";
        }
    }
}