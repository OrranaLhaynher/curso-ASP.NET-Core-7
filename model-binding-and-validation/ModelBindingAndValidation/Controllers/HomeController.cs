using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidation.Models;

namespace Controllers.Controllers
{
    public class HomeController : Controller
    {
        [Route("/bookstore/{bookid?}/{isloggedin?}")] //model binding with route date
        //We can set the Book book with FromQuery/FromRoute with => [FromQuery] Book book
        public IActionResult Book([FromRoute] int? bookid, [FromQuery] bool? isloggedin, Book book) //model binding with query string parameters
        {
            if (bookid == null)
            {
                return BadRequest("Book id can't be null or empty");
            }

            if (bookid <= 0)
            {
                return BadRequest("Book id is not valid! It cannot be less than or equal to 0.");
            }

            if (bookid > 1000)
            {
                return NotFound("Book id is not valid! It cannot be greater than 1000."); 
            }

            if (isloggedin == null)
            {
                return StatusCode(401, "The confirmation of logged in can't be null or empty");
            }

            if (isloggedin == false)
            {
                return Unauthorized("User must be logged in");
            }

            return Content($"<h1>O id do livro é {bookid} e o usuário está com o login {isloggedin}</h1>", "text/html");
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
