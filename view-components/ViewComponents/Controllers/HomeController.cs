using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

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

        [Route("/load-persons-list")]
        public IActionResult LoadPersonsList()
        {
            PersonGridModel personModel = new PersonGridModel()
            {
                GridTitle = "Persons",
                Persons = new List<Person>()
                {
                    new Person() { Name="Maria", JobTitle="Teacher", JobDescription="She teaches to small kids" },
                    new Person() { Name="Osvaldo", JobTitle="Freelancer", JobDescription="He does what he wants" },
                    new Person() { Name="Mario", JobTitle="Manager", JobDescription="He manage things" },

                }
            };

            return ViewComponent("Grid", personModel);
        }
    }
}
