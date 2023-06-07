﻿using Microsoft.AspNetCore.Mvc;
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
        //IActionResult é a interface pai das outras - JsonResult, ContentResult, FileResult, etc
        public IActionResult Index()
        {
            return Content("<h1>Home</h1>", "text/html");
        }

        [Route("/book")]
        //IActionResult é a interface pai das outras - JsonResult, ContentResult, FileResult, etc
        public IActionResult Book()
        {
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return Content("Book id is not supplied!");
            }

            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("Book id can't be null or empty");
            }

            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);

            if (bookId <= 0) 
            {
                Response.StatusCode = 400;
                return Content("Book id is not valid! It cannot be less than or equal to 0.");
            }

            if (bookId > 1000)
            {
                Response.StatusCode = 400;
                return Content("Book id is not valid! It cannot be greater than 1000.");
            }

            if (!Request.Query.ContainsKey("isloggedin"))
            {
                Response.StatusCode = 400;
                return Content("The confirmation of logged in is not supplied!");
            }

            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["isloggedin"])))
            {
                Response.StatusCode = 400;
                return Content("The confirmation of logged in can't be null or empty");
            }

            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                Response.StatusCode = 401;
                return Content("User must be logged in");
            }

            return File("/curriculum.pdf", "application/pdf");
        }

        [Route("/person")]
        public IActionResult Person()
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
        public IActionResult FileDownload()
        {
            //return new VirtualFileResult("/curriculum.pdf", "application/pdf"); //quando o arquivo está no wwwroot folder
            return File("/curriculum.pdf", "application/pdf"); //shortcut
        }

        [Route("/file-download2")]
        public IActionResult FileDownload2()
        {
            //não é uma boa prática
            //return new PhysicalFileResult(@"C:\Users\orran\Downloads\ap15.30.64.jpg", "image/jpeg"); //quando o arquivo não está no wwwroot folder
            return File(@"C:\Users\orran\Downloads\ap15.30.64.jpg", "image/jpeg"); //shortcut
        }

        [Route("/file-download3")]
        public IActionResult FileDownload3()
        {
            //bytearray
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\orran\Downloads\ap15.30.64.jpg");
            //return new FileContentResult(bytes, "image/jpeg"); //quando o arquivo está sendo enviado para a aplicação online na forma de bytearray
            return File(bytes, "image/jpeg"); //shortcut
        }

        [Route("/about")] 
        public IActionResult About()
        {
            ContentResult result = new ContentResult()
            {
                Content = "<h1>About page<h1><h2>Informacoes sobre o produto aqui<h2>",
                ContentType = "text/html"
        };
            return result;
        }

        [Route("/login")] 
        public IActionResult Login()
        {
            ContentResult result = new ContentResult();
            result.Content = "<h1>Login page<h1><h2>Entre com suas informacoes de login aqui<h2>";
            result.ContentType = "text/html";

            return result;
        }

        [Route("/register")] 
        public IActionResult Register()
        {

            return Content("<h1>Pagina de cadastro</h1>", "text/html");
        }

    }
}
