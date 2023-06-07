using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    public class BankController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            if (Request.Method == "GET") {
                return Content("<h1>Welcome to the Best Bank<h1>", "text/html");
            }
            else
            {
                return StatusCode(405);
            }
        }

        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            var prop = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

            if (Request.Method == "GET")
            {
                return Json(prop);
            }
            else
            {
                return StatusCode(405);
            }
        }

        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {

            if (Request.Method == "GET")
            {
                return File("/curriculum.pdf", "application/pdf");
            }
            else
            {
                return StatusCode(405);
            }
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance(int? accountNumber)
        {
            var prop = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

            if (Request.Method == "GET")
            {
                if (accountNumber == null)
                {
                    return NotFound("Account Number should be supplied");
                }

                if (accountNumber == 1001)
                {
                    return Content($"<h1> The current balance is {prop.currentBalance.ToString()}</h1>", "text/html");
                }
                else
                {
                    return BadRequest("Account Number should be 1001");
                }
            }
            else
            {
                return StatusCode(405);
            }
        }
    }
}

