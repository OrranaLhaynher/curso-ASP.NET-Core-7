using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ICitiesService _citiesService;

        //mais comumente usando do que o method injection
        //public HomeController(ICitiesService citiesService) //chamado de constructor injection
        //{
        //    //create object of CitiesService class
        //    _citiesService = citiesService;
        //}

        [Route("/")]
        public IActionResult Index([FromServices] ICitiesService _citiesService) //chamado de method injection - quando não é necessário fazer a injection de todo o modelo para todos os métodos do controller e apenas a injection de um método único, como no Index aqui
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
