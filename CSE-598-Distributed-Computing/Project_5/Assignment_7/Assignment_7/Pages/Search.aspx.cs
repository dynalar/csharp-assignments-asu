using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;

namespace Assignment_7.Pages
{
    public partial class Search : System.Web.UI.Page
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

            // parse the result and use HTML builder to return a table to the front-end
            RecAreaParser recAreaParser = new RecAreaParser();
            List<RecArea> recAreas = recAreaParser.ParseRIDBJson(recreationAreaResponse);

            string html = "<table>";
            html += "<tr><th>Name</th><th>Directions</th><th>Favorites?</th><th></th></tr>";

            foreach (RecArea recArea in recAreas)
            {
                html += "<tr>";
                html += "<td><strong>" + recArea.RecAreaName + "</strong></td>";
                html += "<td>" + recArea.RecAreaDirections + "</td>";
                html += "<td><a href='/Actions/SaveFavoriteLocation.aspx?id=" + recArea.RecAreaID + "&name=" + HttpUtility.UrlEncode(recArea.RecAreaName) + "&directions=" + HttpUtility.UrlEncode(recArea.RecAreaDirections) + "'>Add to Favorites</a></td>";
                html += "</tr>";
            }

            html += "</table>";

            ResultLiteral.Text = html;
        }
    }

    /// <summary>
    /// Our RecArea class. this essentially a nice little DTO so we can access the items in the response later.
    /// </summary>
    public class RecArea
    {
        public string RecAreaName { get; set; }
        public string RecAreaDirections { get; set; }
        public string RecAreaID { get; set; }
    }

    /// <summary>
    /// RecAreaParser that is in charge of parsing a json structure from the recreation area response.
    /// </summary>
    public class RecAreaParser
    {
        /// <summary>
        /// parses the json into a list
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public List<RecArea> ParseRIDBJson(string json)
        {
            List<RecArea> recAreas = new List<RecArea>();

            try
            {
               // use jobject to convert the json string 
                JObject jsonObject = JObject.Parse(json);

                // get the RECDATA which is the base node
                JArray recDataArray = (JArray)jsonObject["RECDATA"];

                // iterate over each item in the RECDATA array
                foreach (JObject recDataObject in recDataArray)
                {
                    // were using just name, directions and ID for convenience.
                    string recAreaName = recDataObject["RecAreaName"].ToString();
                    string recAreaDirections = recDataObject["RecAreaDirections"].ToString();
                    string recAreaID = recDataObject["RecAreaID"].ToString();

                    // Create a RecArea object with the extracted values
                    RecArea recArea = new RecArea
                    {
                        RecAreaName = recAreaName,
                        RecAreaDirections = recAreaDirections,
                        RecAreaID = recAreaID
                    };

                    // Add the RecArea object to the recAreas list
                    recAreas.Add(recArea);
                }
            }
            catch (Exception ex)
            {
                // handle any exception that occurs during parsing
                // not sure how to handle this yet
                Console.WriteLine("error parsing JSON: " + ex.Message);
            }

            return recAreas;
        }
    }

}