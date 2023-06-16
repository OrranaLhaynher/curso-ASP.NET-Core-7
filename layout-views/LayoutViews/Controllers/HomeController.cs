using Microsoft.AspNetCore.Mvc;

namespace LayoutViews.Controllers
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

        [Route("/contact")]
        public IActionResult Contact()
        {
            ViewData["title"] = "Contact";
            return View();
        }
    }
}
