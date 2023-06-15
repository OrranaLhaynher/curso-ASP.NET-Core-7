using Microsoft.AspNetCore.Mvc;

namespace RazorViews.Controllers
{
    public class ProductController : Controller
    {
        [Route("/products/all")]
        public IActionResult All()
        {
            return View();
        }
    }
}
