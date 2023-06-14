using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBindingAndValidation.CustomModelBinders;
using ModelBindingAndValidation.Models;
using System.ComponentModel.DataAnnotations;

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
        //[Bind(nameof(Person.Name), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword), nameof(Person.DateOfBirth))]
        //[Bind] é para setar quais atributos serão utilizados. Todos os atributos como padrão usam bind, mas se a lista de atributos é grande e para certa rota, não são necessários todos, é aí que entra o [Bind]
        //[ModelBinder(BinderType = typeof(PersonModelBinder))]
        public IActionResult Register(Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
        {

            if (!ModelState.IsValid)
            {
                //With LINQ
                string errors = string.Join("\n",
                    ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));
                return BadRequest(errors);
            }

            //ControllerContext.HttpContext.Request.Headers["key"]; //forma tradicional

            return Content($"{person}, {UserAgent}", "text/plain");
        }
    }
}
