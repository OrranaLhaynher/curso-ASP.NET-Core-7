using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidation.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 1500; //caso não seja setado um ano no atributo
        public int MaximumYear { get; set; } = (int)DateTime.Now.Year;
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0} and greater than {1}";

        //parameterless constructor
        public MinimumYearValidatorAttribute() { }

        //parameterized constructor
        public MinimumYearValidatorAttribute(int minimumYear, int maximumYear) 
        { 
            MinimumYear = minimumYear;
            MaximumYear = maximumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;

                if (date.Year > MaximumYear || date.Year < MinimumYear)
                {
                    //return new ValidationResult("Minumum year allowed is 2000");
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear, MaximumYear)); // ?? - significa nulo, ou seja, se a mensagem de erro for nula usar a defaulterrormessage
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
