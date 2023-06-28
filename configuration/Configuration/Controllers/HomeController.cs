using Microsoft.AspNetCore.Mvc;

namespace Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            //ViewBag.ClientID = _configuration["WeatherAPI:ClientID"];
            //ViewBag.ClientSecretKey = _configuration.GetValue<string>("WeatherAPI:ClientSecretKey", "the default secret key");//_configuration.GetValue<string>("myName", "Orrana");

            //Get
            //WeatherAPIOptions option = _configuration.GetSection("WeatherAPI").Get<WeatherAPIOptions>();

            //Bind
            WeatherAPIOptions option = new WeatherAPIOptions();
            _configuration.GetSection("WeatherAPI").Bind(option);
            ViewBag.ClientID = option.ClientId;
            ViewBag.ClientSecretKey = option.ClientSecretKey;


            return View();
        }
    }
}
