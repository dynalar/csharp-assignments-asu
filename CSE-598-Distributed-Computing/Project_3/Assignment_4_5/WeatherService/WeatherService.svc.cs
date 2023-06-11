using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using WeatherService.JsonObjects;
using System.Threading.Tasks;

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
        public string weatherResponseString { get; set; }

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

        public async Task<string> GetWeather(string latVal, string longVal)
        {
            // call the weather API
            return await callWeatherApi(latVal, longVal);
        }

        public async Task<string> callWeatherApi(string latVal, string longVal)
        {
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    var weatherApiResponse = await client.GetAsync(weatherApiEndpoint + "?lat=" + latVal + "&lon=" + longVal + "&units=imperial" + "&appid=" + openWeatherMapAPIKey);
                    weatherApiResponse.EnsureSuccessStatusCode();
                    string serializedWeatherResponse = (await weatherApiResponse.Content.ReadAsStringAsync()).Trim();

                    // get data from weather API endpoint
                    JObject weatherDataObject = JObject.Parse(serializedWeatherResponse);
                    currentConditions = (string)weatherDataObject.SelectToken("weather[0].main");
                    currentTemp = (string)weatherDataObject.SelectToken("main.temp") + " °F";
                    minTemp = (string)weatherDataObject.SelectToken("main.temp_min") + " °F";
                    maxTemp = (string)weatherDataObject.SelectToken("main.temp_max") + " °F";

                    // build json response from model
                    WeatherResponse weatherResponse = new WeatherResponse(currentConditions, currentTemp, minTemp, maxTemp);

                    // set our json response
                    return JsonConvert.SerializeObject(weatherResponse);
                } catch (Exception e)
                {
                    // catch any errors from the response
                    WeatherResponse weatherResponse = new WeatherResponse("", "", "", "", "No location found. Please try again. Error: " + e.Message);

                    // set our json response
                    return JsonConvert.SerializeObject(weatherResponse);
                }
            }

        }
    }
}
