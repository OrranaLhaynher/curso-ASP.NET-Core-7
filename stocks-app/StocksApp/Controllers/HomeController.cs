using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.Services;

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
                CurrentPrice = Convert.ToDouble(responseDictionary["c"].ToString()),
                Change = Convert.ToDouble(responseDictionary["d"].ToString()),
                PercentChange = Convert.ToDouble(responseDictionary["dp"].ToString()),
                HighPriceOfTheDay = Convert.ToDouble(responseDictionary["h"].ToString()),
                LowPriceOfTheDay = Convert.ToDouble(responseDictionary["l"].ToString()),
                OpenPriceOfTheDay = Convert.ToDouble(responseDictionary["o"].ToString()),
                PreviousClosePrice = Convert.ToDouble(responseDictionary["pc"].ToString())
            };

            return View(stock);
        }
    }
}
