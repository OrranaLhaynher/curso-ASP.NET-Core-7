using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService;

        public HomeController()
        {
            //create object of CitiesService class
            _citiesService = null;//new ICitiesService();
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
