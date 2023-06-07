using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    //Adicionar -Controller já transforma essa classe em um controller
    public class HomeController
    {
        [Route("/")] //chamado de attribute routing, seta a rota do método abaixo
        public string home()
        {
            return "Hello from method 1";
        }

        [Route("/login")]
        public string login()
        {
            return "Página de login";
        }

        [Route("/blog")]
        public string blog()
        {
            return "Página do blog";
        }
    }
}
