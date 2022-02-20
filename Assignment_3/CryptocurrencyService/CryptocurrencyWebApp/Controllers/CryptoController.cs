using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptocurrencyWebApp.Controllers
{
    public class CryptoController : Controller
    {
        // GET: Cryptocurrency
        public string Index()
        {
            CryptocurrencyService.ServiceClient cryptoService = new CryptocurrencyService.ServiceClient();

            return cryptoService.GetCryptocurrencyPrice("bitcoin");
        }

        public string CallCryptoService(string ticker)
        {
            CryptocurrencyService.ServiceClient cryptoService = new CryptocurrencyService.ServiceClient();

            return cryptoService.GetCryptocurrencyPrice(ticker);
        }
    }
}