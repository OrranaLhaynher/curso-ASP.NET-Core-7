using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml;

namespace ModelBindingAndValidation.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherProperty { get; set; }

        public DateRangeValidatorAttribute(string otherProperty) { 
            OtherProperty = otherProperty;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime toDate = Convert.ToDateTime(value);
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherProperty); //pegando a referencia a outra propriedade

                if (otherProperty != null) {
                    DateTime? fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance)); //pegando a data da propriedade FromDate

                    if (fromDate > toDate)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherProperty, validationContext.MemberName });
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
            else
            {
                return null;
            }
        }
    }
}
