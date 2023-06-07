using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Controllers.Controllers
{
    //Adicionar -Controller já transforma essa classe em um controller
    //Se não quiser adicionar o -Controller, pode colocar na linha acima da classe o atributo [Controller]
    public class HomeController : Controller
    {
        [Route("/")] //chamado de attribute routing, seta a rota do método abaixo
        //[Route("/sayhello")] //pode adicionar várias rotas para o mesmo método
        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "<h1>Home</h1>",
                ContentType = "text/html"
            };
        }

        [Route("/about")] //chamado de attribute routing, seta a rota do método abaixo
        public ContentResult About()
        {
            ContentResult result = new ContentResult()
            {
                Content = "<h1>About page<h1><h2>Informacoes sobre o produto aqui<h2>",
                ContentType = "text/html"
        };
            return result;
        }

        [Route("/login")] //chamado de attribute routing, seta a rota do método abaixo
        public ContentResult Login()
        {
            ContentResult result = new ContentResult();
            result.Content = "<h1>Login page<h1><h2>Entre com suas informacoes de login aqui<h2>";
            result.ContentType = "text/html";

            return result;
        }

        [Route("/register")] //chamado de attribute routing, seta a rota do método abaixo
        public ContentResult Register()
        {

            return Content("<h1>Pagina de cadastro</h1>", "text/html");
        }

        [Route("/contact/{mobile:regex(^\\d{{10}}$)}")] //chamado de attribute routing, seta a rota do método abaixo
        public string Contact()
        {
            return "Contact page\nalgo deixa de ser\nOrrana Lhaynher\nTelefone - (89) 99473-5087";
        }
    }
}
