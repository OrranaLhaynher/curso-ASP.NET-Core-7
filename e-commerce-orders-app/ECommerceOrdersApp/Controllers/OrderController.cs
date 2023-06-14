using ECommerceOrdersApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrdersApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("<h1>Home</h1>", "text/html");
        }

        [Route("/order")]
        public IActionResult OrderPage([Bind(nameof(Order.OrderDate), nameof(Order.InvoicePrice), nameof(Order.Products))] Order order)
        {
            if (Request.Method == "POST")
            {
                if (!ModelState.IsValid)
                {
                    //With LINQ
                    string errors = string.Join("\n",
                        ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));
                    return BadRequest(errors);
                }
                else
                {
                    Random rnd = new Random();
                    int orderNum = rnd.Next(1, 99999);

                    return Json(new { orderNumber = orderNum });
                }
            }
            else
            {
                return StatusCode(405);
            }
        }
    }
}
