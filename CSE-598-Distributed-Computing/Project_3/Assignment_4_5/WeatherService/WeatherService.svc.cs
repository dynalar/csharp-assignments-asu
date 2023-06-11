using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using WeatherService.JsonObjects;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WeatherService : IWeatherService
    {
        // endpoint for weather API
        private const string weatherApiEndpoint = "https://api.openweathermap.org/data/2.5/weather";

        // ADD API KEY HERE BEFORE SUBMITTING ASSIGNMENT
        private const string openWeatherMapAPIKey = "";

        // get attributes
        public string currentConditions;
        public string currentTemp;
        public string minTemp;
        public string maxTemp;
        public string weatherResponseString;

        // instantiate new http client
        HttpClient client = new HttpClient();

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

        public string GetWeather(float latVal, float longVal)
        {
            // call the weather API
            callWeatherApi(latVal, longVal);

            // return the serialized json string with our information
            return weatherResponseString;
        }

        public async void callWeatherApi(float latVal, float longVal)
        {
            try
            {
                var weatherApiResponse = await client.GetAsync(weatherApiEndpoint + "?lat=" + latVal + "&lon=" + longVal + "&units=imperial" + "&appid=" + openWeatherMapAPIKey);
                weatherApiResponse.EnsureSuccessStatusCode();
                weatherResponseString = (await weatherApiResponse.Content.ReadAsStringAsync()).Trim();

                // get data from weather API endpoint
                JObject weatherDataObject = JObject.Parse(weatherResponseString);
                currentConditions = (string)weatherDataObject.SelectToken("weather[0].main");
                currentTemp = (string)weatherDataObject.SelectToken("main.temp") + " °F";
                minTemp = (string)weatherDataObject.SelectToken("main.temp_min") + " °F";
                maxTemp = (string)weatherDataObject.SelectToken("main.temp_max") + " °F";

                // build json response from model
                WeatherResponse weatherResponse = new WeatherResponse(currentConditions, currentTemp, minTemp, maxTemp);

                // set our json response
                weatherResponseString = JsonConvert.SerializeObject(weatherResponse);
            }
            catch (HttpRequestException e)
            {
                // catch any errors from the response
                WeatherResponse weatherResponse = new WeatherResponse("", "", "", "", "No location found. Please try again. Error: " + e.Message);
                
                // set our json response
                weatherResponseString = JsonConvert.SerializeObject(weatherResponse);
            }
        }
    }
}
