using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Extensions.Caching.Memory;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        // define empty cache
        private readonly IMemoryCache _cache;
        private const int expirationTime = 10;

        // detect whether we're using cache or not
        public string fromCache = "false";

        // API endpoints
        private const string googleMapsGeocodingEndpoint = "";
        private const string weatherApiEndpoint = "";

        // bad practice to store API keys here in the real world, but for our purposes it's ok.
        private const string openWeatherMapAPIKey = "3a16025f3740884e31385c79e3b9588c";
        private const string googleMapsAPIKey = "AIzaSyCV5pTKtfwl2Is_GVpGvVAboogc3RXSfUQ";

        public MainPage()
        {
            InitializeComponent();

            // initialize the cache
            _cache = new MemoryCache(new MemoryCacheOptions() { });
        }

        private async void Get_API_Data(object sender, EventArgs e)
        {
            // declare all of our new stuff up here
            HttpClient client = new HttpClient();

            // reset fromCache flag to false
            fromCache = "false";

            // response strings from api responses
            string geocodeResponseString;
            string weatherResponseString;

            // data to send to xaml layout
            string latitude;
            string longitude;
            string address;
            string currentConditions;
            string currentTemp;
            string minTemp;
            string maxTemp;

            // if cached data is present, just get the items from the cache and set the variables.
            // display immediately and halt execution.
            JObject cachedData = GetCacheData<JObject>(ZipCodeEntry.Text);

            // check if the cache has data, if it does then display to the app and stop execution.
            if (cachedData != null)
            {
                latitude = (string)cachedData.SelectToken("latitude");
                longitude = (string)cachedData.SelectToken("longitude");
                address = (string)cachedData.SelectToken("address");
                currentConditions = (string)cachedData.SelectToken("currentConditions");
                currentTemp = (string)cachedData.SelectToken("currentTemp");
                minTemp = (string)cachedData.SelectToken("minTemp");
                maxTemp = (string)cachedData.SelectToken("maxTemp");

                // weather data displayed here
                ConditionsValue.Text = currentConditions;
                TempValue.Text = currentTemp;
                MinTempValue.Text = minTemp;
                MaxTempValue.Text = maxTemp;

                // location data displayed here
                LatitudeValue.Text = latitude;
                LongitudeValue.Text = longitude;
                LocationValue.Text = address;

                // display that the data came from the cache
                CachedValue.Text = fromCache;

                return;
            }

            // if there is no cache data, then call our APIs and store in the cache.
            try
            {
                // call the geocoding API and get the response.
                var geocodeResponse = await client.GetAsync(googleMapsGeocodingEndpoint + "?address=" + ZipCodeEntry.Text + "&key=" + googleMapsAPIKey);
                geocodeResponse.EnsureSuccessStatusCode();
                geocodeResponseString = (await geocodeResponse.Content.ReadAsStringAsync()).Trim();

                // get our necessary data from the geocode response
                JObject geocodeDataObject = JObject.Parse(geocodeResponseString);
                latitude = (string)geocodeDataObject.SelectToken("results[0].geometry.location.lat");
                longitude = (string)geocodeDataObject.SelectToken("results[0].geometry.location.lng");
                address = (string)geocodeDataObject.SelectToken("results[0].formatted_address");

                // call the weather api and get the response
                var weatherApiResponse = await client.GetAsync(weatherApiEndpoint + "?lat=" + latitude + "&lon=" + longitude + "&units=imperial" + "&appid=" + openWeatherMapAPIKey);
                weatherApiResponse.EnsureSuccessStatusCode();
                weatherResponseString = (await weatherApiResponse.Content.ReadAsStringAsync()).Trim();

                // get data from weather API endpoint
                JObject weatherDataObject = JObject.Parse(weatherResponseString);
                currentConditions = (string)weatherDataObject.SelectToken("weather[0].main");
                currentTemp = (string)weatherDataObject.SelectToken("main.temp") + " °F";
                minTemp = (string)weatherDataObject.SelectToken("main.temp_min") + " °F";
                maxTemp = (string)weatherDataObject.SelectToken("main.temp_max") + " °F";

                // create json object for caching. we will always cache data
                JObject cacheData = new JObject
                {
                    ["latitude"] = latitude,
                    ["longitude"] = longitude,
                    ["address"] = address,
                    ["currentConditions"] = currentConditions,
                    ["currentTemp"] = currentTemp,
                    ["minTemp"] = minTemp,
                    ["maxTemp"] = maxTemp,
                };

                // set to the cache once we have all data ready
                SetCacheData(ZipCodeEntry.Text, cacheData);
            }
            catch (HttpRequestException ex)
            {
                geocodeResponseString = ex.ToString();

                LatitudeValue.Text = "No Location Found";
                LongitudeValue.Text = "No Longitude Found";
                LocationValue.Text = "No Latitude Found";

                ConditionsValue.Text = "Conditions Not Available";
                TempValue.Text = "Current Temperature Not Available";
                MinTempValue.Text = "Min Temp Not Available";
                MaxTempValue.Text = "Max Temp Not Available";

                return;
            }

            // weather data displayed here
            ConditionsValue.Text = currentConditions;
            TempValue.Text = currentTemp;
            MinTempValue.Text = minTemp;
            MaxTempValue.Text = maxTemp;

            // location data displayed here
            LatitudeValue.Text = latitude;
            LongitudeValue.Text = longitude;
            LocationValue.Text = address;
            CachedValue.Text = fromCache;
        }

        public void SetCacheData<T>(string key, T value)
        {
            _cache.Set(key, value);
        }

        public T GetCacheData<T>(string key)
        {
            if(_cache.TryGetValue(key, out T value))
            {
                fromCache = "true";
                return value;
            } else
            {
                fromCache = "false";
                return default(T);
            }
        }
    }
}
