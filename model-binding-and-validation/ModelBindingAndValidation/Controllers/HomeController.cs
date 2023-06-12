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

            if (!ModelState.IsValid)
            {
                //List<string> errorsList = new List<string>();

                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errorsList.Add(error.ErrorMessage);
                //    }
                //}

                //string errors = string.Join("\n", errorsList);

                //With LINQ
                string errors = string.Join("\n",
                    ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));
                return BadRequest(errors);
            }
            return Content($"<h1>{person}</h1>", "text/html");
        }
    }
}
