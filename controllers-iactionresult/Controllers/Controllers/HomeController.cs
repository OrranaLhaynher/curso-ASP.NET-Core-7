using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Controllers.Models;
using Microsoft.AspNetCore.Http.Connections;

namespace Controllers.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")] 
        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "<h1>Home</h1>",
                ContentType = "text/html"
            };
        }

        [Route("/person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Orrana",
                LastName = "Sousa",
                Age = 25
            };
            Person person2 = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Taemin",
                LastName = "Lee",
                Age = 29
            };

            return new JsonResult(person, person2); //converte qualquer objeto com propriedades para o tipo json
        }

        [Route("/about")] 
        public ContentResult About()
        {
            ContentResult result = new ContentResult()
            {
                Content = "<h1>About page<h1><h2>Informacoes sobre o produto aqui<h2>",
                ContentType = "text/html"
        };
            return result;
        }

        [Route("/login")] 
        public ContentResult Login()
        {
            ContentResult result = new ContentResult();
            result.Content = "<h1>Login page<h1><h2>Entre com suas informacoes de login aqui<h2>";
            result.ContentType = "text/html";

            return result;
        }

        [Route("/register")] 
        public ContentResult Register()
        {

            return Content("<h1>Pagina de cadastro</h1>", "text/html");
        }

    }
}
