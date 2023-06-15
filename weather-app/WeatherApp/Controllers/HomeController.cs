using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            if (Request.Method == "GET")
            {

                List<CityWeather> cities = new List<CityWeather>()
                {
                    new CityWeather() {
                        CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"), TemperatureFahrenheit = 33
                    },
                    new CityWeather() {
                        CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60
                    },
                    new CityWeather() {
                        CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82
                    }
                };
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
                    List<CityWeather> cities = new List<CityWeather>()
                    {
                        new CityWeather() {
                            CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"), TemperatureFahrenheit = 33
                        },
                        new CityWeather() {
                            CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60
                        },
                        new CityWeather() {
                            CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82
                        }
                    };
                    if (cities.Where(temp => temp.CityUniqueCode == cityName).Any())
                    {
                        CityWeather? city = cities.Where(temp => temp.CityUniqueCode == cityName).FirstOrDefault();
                        return View(city);
                    }
                    else
                    {
                        return Content("City not found");
                    }

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
