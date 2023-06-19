using Microsoft.AspNetCore.Mvc;
using PartialViews.Models;

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

        [Route("/programming-languages")]
        public IActionResult ProgrammingLanguages() 
        { 
            ListModel listModel = new ListModel()
            {
                ListTitle = "Programming Languages List",
                ListItems = new List<string>()
                {
                    "Python",
                    "C#",
                    "Javascript",
                    "Java"
                }
            };
            return PartialView("_ListPartialView", listModel); //new PartialViewResult() { ViewName = "_ListPartialView", Model = listModel};
        }
    }
}
