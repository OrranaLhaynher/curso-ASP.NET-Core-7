using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            if (Request.Method == "GET")
            {

                List<CityWeather> cities = _weatherService.GetWeatherDetails();

                ViewData["Title"] = "Weather";
                return View(cities);
            }
            else
            {
                return StatusCode(405, "Method Not Allowed");
            }
        }

        [Route("/weather/{cityName?}")]
        public IActionResult Weather(string cityName)
        {
            if (Request.Method == "GET")
            {
                if (!string.IsNullOrEmpty(cityName))
                {
                    CityWeather? city = _weatherService.GetWeatherByCityCode(cityName); 
                    ViewData["Title"] = "Weather by City";
                    return View(city);
                }
                else
                {
                    return Content("The cityName is empty");
                }
            }
            else
            {
                return StatusCode(404, "Method Not Allowed");
            }
        }

    }
}
