using System.ComponentModel.DataAnnotations;

namespace ECommerceOrdersApp.CustomValidators
{
    public class MinimumDateValidator : ValidationAttribute
    {
        public DateTime MinimumDate { get; set; }
        public string DefaultErrorMessage { get; set; } = "Order Date deve ser maior ou igual a {0}";

        public MinimumDateValidator(string minimumDate) 
        { 
            MinimumDate = Convert.ToDateTime(minimumDate);
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime datetime = (DateTime)value;

                if (datetime <  MinimumDate)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumDate.ToString("yyyy-MM-dd"), new string[] { nameof(validationContext.MemberName) }));
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
