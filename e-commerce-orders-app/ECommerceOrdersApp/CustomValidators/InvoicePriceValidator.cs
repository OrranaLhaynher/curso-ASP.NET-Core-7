using ECommerceOrdersApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerceOrdersApp.CustomValidators
{
    public class InvoicePriceValidator : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Invoice Price deve ser igual ao custo total de todos os produtos (i.e. {0}) no pedido.";

        public InvoicePriceValidator() { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var otherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));

                if (otherProperty != null)
                {
                    List<Product> products = (List<Product>)otherProperty.GetValue(validationContext.ObjectInstance)!;

                    double? totalPrice = 0;

                    foreach (var product in products)
                    {
                        totalPrice += product.Price * product.Quantity;
                    }

                    double actualPrice = (double)value;

                    if (totalPrice > 0)
                    {
                        if (totalPrice != actualPrice)
                        {
                            return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, totalPrice, new string[] {nameof(validationContext.MemberName)}));
                        }
                        else
                        {
                            return ValidationResult.Success;
                        }
                    }
                    else
                    {
                        return new ValidationResult("Nenhum produto encontrado para validar o Invoice Price", new string[] {nameof(validationContext.MemberName)});
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
