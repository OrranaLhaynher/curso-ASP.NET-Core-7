using Microsoft.AspNetCore.Mvc;

namespace RazorViews.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
