using System.ComponentModel.DataAnnotations;

namespace ECommerceOrdersApp.Models
{
    public class Product
    {
        [Required(ErrorMessage = "O {0} é um campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} deve ser um valor valido")]
        public int? ProductCode { get; set; }

        [Required(ErrorMessage = "O {0} é um campo obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} deve ser um valor valido")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "O {0} é um campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} deve ser um valor valido")]
        public int? Quantity { get; set; }
    }
}
