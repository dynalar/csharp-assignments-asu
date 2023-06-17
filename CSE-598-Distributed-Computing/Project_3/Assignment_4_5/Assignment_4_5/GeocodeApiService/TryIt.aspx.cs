using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Assignment_4_5.GeocodeApiService
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // define SubmitButton_Click
        public async void SubmitButton_Click(object sender, EventArgs e)
        {
           string geocodeResponse = await callGeocodeService();

           ResultLiteral.Text = sanitizeJsonString(geocodeResponse);
        }

        // call the async service
        protected async Task<string> callGeocodeService()
        {
            // pull our env variables
            string geocodeServiceUrl = ConfigurationManager.AppSettings["GeocodeServiceURL"];

            // call the geocoding api and return information about the zip code
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string zipCode = ZipCodeTextBox.Text.Trim();

                    var weatherApiResponse = await client.GetAsync(geocodeServiceUrl + zipCode);
                    weatherApiResponse.EnsureSuccessStatusCode();
                    string serializedWeatherResponse = (await weatherApiResponse.Content.ReadAsStringAsync()).Trim();

                    // set our json response
                    return serializedWeatherResponse;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public string sanitizeJsonString(string jsonString)
        {
            // Remove escape characters
            // Remove newline characters
            string strippedJson = jsonString.Replace("\n", "");

            // Trim leading and trailing whitespace
            string trimmedJson = strippedJson.Trim();

            return trimmedJson;
        }
    }
}