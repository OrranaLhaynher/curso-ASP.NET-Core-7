using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Controllers.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

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

            //return new JsonResult(person); //converte qualquer objeto com propriedades para o tipo json
            return Json(person);
        }

        [Route("/file-download")]
        public FileResult FileDownload()
        {
            //return new VirtualFileResult("/curriculum.pdf", "application/pdf"); //quando o arquivo está no wwwroot folder
            return File("/curriculum.pdf", "application/pdf"); //shortcut
        }

        [Route("/file-download2")]
        public FileResult FileDownload2()
        {
            //não é uma boa prática
            //return new PhysicalFileResult(@"C:\Users\orran\Downloads\ap15.30.64.jpg", "image/jpeg"); //quando o arquivo não está no wwwroot folder
            return File(@"C:\Users\orran\Downloads\ap15.30.64.jpg", "image/jpeg"); //shortcut
        }

        [Route("/file-download3")]
        public FileResult FileDownload3()
        {
            //bytearray
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\orran\Downloads\ap15.30.64.jpg");
            //return new FileContentResult(bytes, "image/jpeg"); //quando o arquivo está sendo enviado para a aplicação online na forma de bytearray
            return File(bytes, "image/jpeg"); //shortcut
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
