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

        [Route("/products/search/{id?}")]
        public IActionResult Search(int? id)
        {
            ViewData["title"] = "Search";
            ViewData["id"] = id;
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
