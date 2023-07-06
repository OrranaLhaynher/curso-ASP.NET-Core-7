using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.Services;
using System.Globalization;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnHubService _myService;
        private readonly IOptions<TradingOptions> _options;

        public HomeController(FinnHubService myService, IOptions<TradingOptions> options)
        {
            _myService = myService;
            _options = options;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_options.Value.DefaultStockSymbol == null)
            {
                _options.Value.DefaultStockSymbol = "MSFT";
            }

            Dictionary<string, object>? responseDictionary = await _myService.GetStockPriceQuote(_options.Value.DefaultStockSymbol);

            Stocks stock = new Stocks()
            {
                StockSymbol = "MSFT",
                CurrentPrice = Convert.ToDouble(responseDictionary["c"].ToString(), CultureInfo.InvariantCulture),
                Change = Convert.ToDouble(responseDictionary["d"].ToString(), CultureInfo.InvariantCulture),
                PercentChange = Convert.ToDouble(responseDictionary["dp"].ToString(), CultureInfo.InvariantCulture),
                HighPriceOfTheDay = Convert.ToDouble(responseDictionary["h"].ToString(), CultureInfo.InvariantCulture),
                LowPriceOfTheDay = Convert.ToDouble(responseDictionary["l"].ToString(), CultureInfo.InvariantCulture),
                OpenPriceOfTheDay = Convert.ToDouble(responseDictionary["o"].ToString(), CultureInfo.InvariantCulture),
                PreviousClosePrice = Convert.ToDouble(responseDictionary["pc"].ToString(), CultureInfo.InvariantCulture)
            };

            return View(stock);
        }
    }
}
