using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;
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
        private const string googleMapsGeocodingEndpoint = "https://maps.googleapis.com/maps/api/geocode/json";
        private const string weatherApiEndpoint = "https://api.openweathermap.org/data/2.5/weather";

        // bad practice to store API keys here in the real world, but for our purposes it's ok.
        private const string openWeatherMapAPIKey = "c641aea47c7d362af597c57e28c2aeb5";
        private const string googleMapsAPIKey = "AIzaSyClXnOanbBNWulSvYF7wOqyoZJ2pKBYtwI";

        // data to send to xaml layout
        public string latitude;
        public string longitude;
        public string address;
        public string currentConditions;
        public string currentTemp;
        public string minTemp;
        public string maxTemp;

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

            // if cached data is present, just get the items from the cache and set the variables.
            // display immediately and halt execution.
            // zip code is used as the key for searching if it has associated cache data
            JObject cachedData = GetCacheData<JObject>(ZipCodeEntry.Text);

            // check if the cache has data, if it does then display to the app and stop execution.
            if (cachedData != null)
            {
                // if we have cache data, get values from cache and display them
                LatitudeValue.Text = (string)cachedData.SelectToken("latitude");
                LongitudeValue.Text = (string)cachedData.SelectToken("longitude");
                LocationValue.Text = (string)cachedData.SelectToken("address");
                ConditionsValue.Text = (string)cachedData.SelectToken("currentConditions");
                TempValue.Text = (string)cachedData.SelectToken("currentTemp");
                MinTempValue.Text = (string)cachedData.SelectToken("minTemp");
                MaxTempValue.Text = (string)cachedData.SelectToken("maxTemp");
                
                // display to front end if data came from cache.
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

                // create json object for caching. we will always cache data when we do an API call.
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
                // expiration time is set to 10 seconds.
                SetCacheData(ZipCodeEntry.Text, cacheData, TimeSpan.FromSeconds(expirationTime));
            }
            catch (HttpRequestException ex)
            {
                LatitudeValue.Text = "No Location Found";
                LongitudeValue.Text = "No Longitude Found";
                LocationValue.Text = "No Latitude Found";

                ConditionsValue.Text = ex.ToString();
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

        // set the cache data to our memory cache
        public void SetCacheData<T>(string key, T value, TimeSpan expiration)
        {
            _cache.Set(key, value, expiration);
        }

        // get the cached data from memory
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
