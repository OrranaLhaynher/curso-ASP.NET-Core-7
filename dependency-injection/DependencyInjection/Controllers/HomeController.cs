using Autofac;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly ILifetimeScope _lifetimeScope;

        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, ILifetimeScope serviceScopeFactory) //chamado de constructor injection
        {
            //create object of CitiesService class
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _lifetimeScope = serviceScopeFactory;
        }

        [Route("/")]
        public IActionResult Index() 
        {
            List<string> cities = _citiesService1.GetCities();

            ViewBag.InstanceId_1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_3 = _citiesService3.ServiceInstanceId;

            //Forma de usar um serviço em um child scope, ou seja, esse serviço é criado e terminado assim que sair do using
            using (ILifetimeScope scope = _lifetimeScope.BeginLifetimeScope())
            {
                //Inject CitiesService
                ICitiesService citiesService = scope.Resolve<ICitiesService>();

                ViewBag.InstanceId_InScope = citiesService.ServiceInstanceId;
                //DB Work

            }//when this scope is completed it calls CitiesService.Dispose() automatically

            return View(cities);
        }
    }
}
