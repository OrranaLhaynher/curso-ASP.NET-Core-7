using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherAPIOptions _options;

        public HomeController(IOptions<WeatherAPIOptions> configuration)
        {
            _options = configuration.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.ClientID = _options.ClientId;
            ViewBag.ClientSecretKey = _options.ClientSecretKey;


            return View();
        }
    }
}
