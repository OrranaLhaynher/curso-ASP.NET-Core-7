using Microsoft.AspNetCore.Mvc;

namespace PartialViews.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            ViewData["listTitle"] = "Cities";
            ViewData["listItems"] = new List<string>()
            {
                "Paris",
                "New York",
                "Buenos Aires",
                "Teresina",
                "Tokio",
                "Seul"
            };
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
