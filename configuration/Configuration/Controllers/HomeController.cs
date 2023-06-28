using Microsoft.AspNetCore.Mvc;

namespace Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.MyKey = _configuration["myKey"]; //_configuration.GetValue<string>("myName", "Orrana");
            return View();
        }
    }
}
