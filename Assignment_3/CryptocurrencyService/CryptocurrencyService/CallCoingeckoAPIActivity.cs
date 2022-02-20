using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CryptocurrencyService
{
    public sealed class CallCoingeckoAPIActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }
        public OutArgument<string> CoinGeckoResponse { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string cryptoTicker = context.GetValue(this.Text);

            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");

                HttpResponseMessage response = client.GetAsync($"coins/{cryptoTicker}/market_chart?vs_currency=usd&days=14&interval=daily").Result;

                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                context.SetValue(CoinGeckoResponse, result);
            }
        }

    }
}
