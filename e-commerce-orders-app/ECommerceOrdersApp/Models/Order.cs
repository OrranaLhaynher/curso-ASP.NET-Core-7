using ECommerceOrdersApp.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ECommerceOrdersApp.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        [MinimumDateValidator("2022-01-23")]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "O {0} é um campo obrigatório")]
        [InvoicePriceValidator]
        [Range(1, double.MaxValue, ErrorMessage = "{0} deve ser um numero valido")]
        public double? InvoicePrice { get; set; }

        [Required(ErrorMessage = "O {0} é um campo obrigatório")]
        [ProductListValidator]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
