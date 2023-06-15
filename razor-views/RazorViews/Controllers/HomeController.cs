using Microsoft.AspNetCore.Mvc;
using RazorViews.Models;
using static RazorViews.Models.Person;

namespace RazorViews.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            //ViewData["appTitle"] = "ASP.NET Core Demo APP - Usando ViewData";

            List<Person> people = new List<Person>()
            {
                new Person() { Name = "John", DateOfBirth = DateTime.Parse("1988-07-09"), PersonGender = Gender.Male },
                new Person() { Name = "Samantha", PersonGender = Gender.Male },
                new Person() { Name = "Chris", DateOfBirth = DateTime.Parse("2001-04-02"), PersonGender = Gender.Other },
                new Person() { Name = "Michelle", DateOfBirth = DateTime.Parse("1970-01-14"), PersonGender = Gender.Female },
                new Person() { Name = "Mickayla", DateOfBirth = DateTime.Parse("2004-12-05"), PersonGender = Gender.Other }
            };

            //ViewData["people"] = people;

            return View("Index", people);
        }

        [Route("/details/{name?}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
            {
                return Content("Person name can't be null");
            }
            else
            {
                List<Person> people = new List<Person>()
                {
                    new Person() { Name = "John", DateOfBirth = DateTime.Parse("1988-07-09"), PersonGender = Gender.Male },
                    new Person() { Name = "Samantha", PersonGender = Gender.Male },
                    new Person() { Name = "Chris", DateOfBirth = DateTime.Parse("2001-04-02"), PersonGender = Gender.Other },
                    new Person() { Name = "Michelle", DateOfBirth = DateTime.Parse("1970-01-14"), PersonGender = Gender.Female },
                    new Person() { Name = "Mickayla", DateOfBirth = DateTime.Parse("2004-12-05"), PersonGender = Gender.Other }
                };

                Person? matchingPerson = people.Where(temp => temp.Name?.ToLower() == name.ToLower()).FirstOrDefault();

                return View("../Details/Index", matchingPerson);
            }
        }

        [Route("/products")]
        public IActionResult Products()
        {
            Person person = new Person()
            {
                Name = "Orrana",
                DateOfBirth = DateTime.Parse("1998-06-02"),
                PersonGender = Gender.Female,
            };

            Product product = new Product()
            {
                Id = 1,
                Name = "Base",
                Price = 67.50
            };

            PersonAndProductWrapperModel model = new PersonAndProductWrapperModel()
            {
                PersonData = person,
                ProductData = product
            };

            return View("../Products/Index", model);
        }
    }
}
