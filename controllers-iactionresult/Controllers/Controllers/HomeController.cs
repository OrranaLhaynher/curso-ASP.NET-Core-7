using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    //Adicionar -Controller já transforma essa classe em um controller
    public class HomeController
    {
        [Route("/")] //chamado de attribute routing, seta a rota do método abaixo
        //[Route("/sayhello")] //pode adicionar várias rotas para o mesmo método
        public string Index()
        {
            return "Home page";
        }

        [Route("/about")] //chamado de attribute routing, seta a rota do método abaixo
        public string About()
        {
            return "About page";
        }

        [Route("/contact/{mobile:regex(^\\d{{10}}$)}")] //chamado de attribute routing, seta a rota do método abaixo
        public string Contact()
        {
            return "Contact page\nalgo deixa de ser\nOrrana Lhaynher\nTelefone - (89) 99473-5087";
        }
    }
}
