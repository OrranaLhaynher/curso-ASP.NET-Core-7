using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
using System;

namespace Controllers.Controllers
{
    public class HomeController : Controller
    {
        //[Route("/")]
        ////IActionResult é a interface pai das outras - JsonResult, ContentResult, FileResult, etc
        //public IActionResult Index()
        //{
        //    return Content("<h1>Home</h1>", "text/html");
        //}

        [Route("/bookstore")]
        //IActionResult é a interface pai das outras - JsonResult, ContentResult, FileResult, etc
        public IActionResult Book(int? bookid, bool? isloggedin)
        {
            if (bookid == null)
            {
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied!");
                return BadRequest("Book id is not supplied!"); //or BadRequestResult()
            }

            if (bookid.HasValue == false)
            {
                //Response.StatusCode = 400;
                return BadRequest("Book id can't be null or empty");
            }

            if (bookid <= 0)
            {
                //Response.StatusCode = 400;
                return BadRequest("Book id is not valid! It cannot be less than or equal to 0.");
            }

            if (bookid > 1000)
            {
                //Response.StatusCode = 400;
                return NotFound("Book id is not valid! It cannot be greater than 1000."); //Status - 404 - NotFound()
            }

            if (isloggedin == null)
            {
                //Response.StatusCode = 400;
                return BadRequest("The confirmation of logged in is not supplied!");
            }

            if (isloggedin.HasValue == false)
            {
                //Response.StatusCode = 400;
                //return BadRequest("The confirmation of logged in can't be null or empty"); 
                return StatusCode(401, "The confirmation of logged in can't be null or empty");
            }

            if (isloggedin == false)
            {
                //Response.StatusCode = 401;
                return Unauthorized("User must be logged in");
            }
            //o nome da classe controller é utilizado sem o -Controller, 302 - Found
            //return new RedirectToActionResult("Books", "Store", new { } ); // o terceiro parametro é para os valores de rota, mas como não temos nesse exemplo, usamos um dummy (new {})
            //return new RedirectToActionResult("Books", "Store", new { }, true); //301 - Moved permanently

            //return RedirectToAction("Books", "Store", new { id = bookId }); //shortcut to 302
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId }); //shortcut to 301

            //Tem que ser uma rota no projeto local
            //return LocalRedirect($"/store/books/{bookId}"); // return new LocalRedirectResult($"/store/books/{bookId}");

            return Redirect($"/store/books/{bookid}");//redirect to the same application or other
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
