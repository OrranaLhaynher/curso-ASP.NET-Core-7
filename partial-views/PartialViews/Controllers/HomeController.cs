using Microsoft.AspNetCore.Mvc;

namespace PartialViews.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            ViewData["title"] = "About";
            return View();
        }
    }
}
