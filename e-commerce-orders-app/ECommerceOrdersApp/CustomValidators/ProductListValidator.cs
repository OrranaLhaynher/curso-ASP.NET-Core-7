using ECommerceOrdersApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerceOrdersApp.CustomValidators
{
    public class ProductListValidator : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "O pedido deve ter no mínimo um produto";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                List<Product> products = (List<Product>)value;

                if (products.Count == 0)
                {
                    return new ValidationResult(ErrorMessage ?? DefaultErrorMessage, new string[] { nameof(validationContext.MemberName)});
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
