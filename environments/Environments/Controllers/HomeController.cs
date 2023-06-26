using Microsoft.AspNetCore.Mvc;

namespace Environments.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/some-route")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/some-route")]
        public IActionResult SomeRoute()
        {
            return View();
        }
    }
}
