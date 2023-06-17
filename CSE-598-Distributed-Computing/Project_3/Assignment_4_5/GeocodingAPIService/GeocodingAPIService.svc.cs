using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeocodingAPIService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GeocodingAPIService : IGeocodingAPIService
    {
        private const string googleMapsGeocodingEndpoint = "https://maps.googleapis.com/maps/api/geocode/json";
        private const string googleMapsAPIKey = "AIzaSyDokQhYEuIY82yVG1Tbt8n1WyrXaJnWoUs";
        string geocodeResponseString;

        public async Task<string> convertZipCodeToLongitudeLatitude(string zipCode)
        {
            return await callGeocodeApi(zipCode);
        }

        private async Task<string> callGeocodeApi(string zipCode)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // set the headers with auth token and json data type
                    client.DefaultRequestHeaders.Add("accept", "application/json");
                    client.DefaultRequestHeaders.Add("apikey", googleMapsAPIKey);

                    var geocodeApiResponse = await client.GetAsync(googleMapsGeocodingEndpoint + "?address=" + zipCode + "&key=" + googleMapsAPIKey);

                    string serializedRidbResponse = (await geocodeApiResponse.Content.ReadAsStringAsync()).Trim();

                    return serializedRidbResponse;

                }
                catch (Exception e)
                {

                    return e.Message;
                }
            }
        }


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
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
