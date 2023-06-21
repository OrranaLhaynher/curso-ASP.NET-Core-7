using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.ViewComponents
{
    public class WeatherViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
        {
            ViewData["TemperatureColor"] = ChooseColor(city.TemperatureFahrenheit);
            return View(city);
        }

        public string ChooseColor(int temperature)
        {
            if (temperature < 44)
            {
                return "#AFD5F0";
            }
            else if (temperature >= 44 && temperature <= 74)
            {
                return "#77dd77";
            }
            else
            {
                return "#FAC898";
            }
        }
    }
}
