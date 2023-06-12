using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidation.Models;

namespace Controllers.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("<h1>Pagina Home</h1>", "text/html");
        }

        [Route("/register")]
        public IActionResult Register(Person person)
        {
            return Content($"<h1>{person}</h1>", "text/html");
        }
    }
}
