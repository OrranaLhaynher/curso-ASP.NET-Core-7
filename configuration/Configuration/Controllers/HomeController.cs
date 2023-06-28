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

            IConfigurationSection section = _configuration.GetSection("WeatherAPI");
            ViewBag.ClientID = section["ClientID"];
            ViewBag.ClientSecretKey = section["ClientSecretKey"];


            return View();
        }
    }
}
