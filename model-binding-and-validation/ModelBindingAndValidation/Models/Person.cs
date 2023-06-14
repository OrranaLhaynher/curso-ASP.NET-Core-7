using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelBindingAndValidation.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidation.Models
{
    //IValidatableObject - atributos são criados e só podem ser utilizados dentro desse modelo
    public class Person : IValidatableObject
    {
        //custom error message
        [Required(ErrorMessage = "O {0} é um campo obrigatório")] //{0} pega o nome da propriedade 
        [Display(Name = "Nome")] //funciona pra toda a propriedade, independente da ordem de adição
        [StringLength(45, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "O campo {0} deve ter apenas caracteres alfabeticos e espaços")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O {0} é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} deve estar em um formato valido")]
        public string? Email { get; set; }

        //[Required(ErrorMessage = "O número de telefone é um campo obrigatório")]
        [Phone(ErrorMessage = "O campo {0} deve estar em um formato valido")]
        //[ValidateNever] //stop the validation in this property
        public string? Phone { get; set; }

        [Required(ErrorMessage = "A senha é um campo obrigatório")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "A confirmação da senha é um campo obrigatório")]
        [Compare("Password", ErrorMessage = "{0} deve ser igual ao campo {1}")]
        public string? ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "O preço é um campo obrigatório")]
        [Range(0, 1000.00, ErrorMessage = "O {0} deve ter valores entre R${1} e R${2}")]
        public double? Price { get; set; }

        [BindNever]
        [MinimumYearValidator(1450, 2050)] //, ErrorMessage = "Não são aceitos anos posteriores a {1} e inferiores a 1500")
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'FromDate' should be older or equal to 'ToDate'")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public List<string?> Tags { get; set; } = new List<string?>();

        public override string ToString()
        {
            return $"Person name - {Name}\nPerson email - {Email}\nPerson phone - {Phone}\nPerson password - {Password}\nPerson confirm password - {ConfirmPassword}\nPerson price - {Price}\nPerson Date Of Birth - {DateOfBirth}\nFrom Date - {FromDate}\nTo Date - {ToDate}\nAge - {Age}\nTags - {string.Join(" ", Tags)}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either DateOfBirth or Age must be supplied", new[] { nameof(Age)});
            }
        }
    }
}

//Model State
//IsValid - specifies whether there is at least one validation error or not (true or false)
//Values - contains each model property value with corresponding "Errors" property that contains list of validation errors of that model property
//ErrorCount - returns number of errors

//[Url(ErrorMessage = "Algo")]