using Microsoft.AspNetCore.Mvc;

namespace LayoutViews.Controllers
{
    public class ProductController : Controller
    {
        [Route("/products")]
        public IActionResult Index()
        {
            ViewData["title"] = "Products";
            return View();
        }

        [Route("/products/search")]
        public IActionResult Search()
        {
            ViewData["title"] = "Search";
            return View();
        }

        [Route("/products/order")]
        public IActionResult Order()
        {
            ViewData["title"] = "Order";
            return View();
        }
    }
}
