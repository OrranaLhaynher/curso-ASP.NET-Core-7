using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }
    }
}
