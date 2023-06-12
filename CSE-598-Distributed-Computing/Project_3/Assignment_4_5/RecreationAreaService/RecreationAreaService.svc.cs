using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RecreationAreaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RecreationAreaService : IRecreationAreaService
    {
        // endpoint for RIDB API service
        private const string ridbEndpoint = "https://ridb.recreation.gov/api/v1/recareas";

        // RIDB API token ADD WHEN SUBMITTED
        private const string ridbAPIKey = "";

        public string ridbResponseString { get; set; }


        // call the RIDB api to get recreation areas
        public async Task<string> GetRecreationAreas(string searchTerms, string states)
        {
            return await callRIDBApi(searchTerms, states);
        }

        private async Task<string> callRIDBApi(string searchTerms, string states)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // set the headers with auth token and json data type
                    client.DefaultRequestHeaders.Add("accept", "application/json");
                    client.DefaultRequestHeaders.Add("apikey", ridbAPIKey);

                    var ridbApiResponse = await client.GetAsync(ridbEndpoint + "?limit=15" + "&query=" + searchTerms + "&state=" + states + "&radius=10");

                    string serializedRidbResponse = (await ridbApiResponse.Content.ReadAsStringAsync()).Trim();

                    return serializedRidbResponse;

                } catch (Exception e) {

                    return e.Message;
                }
            }
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
