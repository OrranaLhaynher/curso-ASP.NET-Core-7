using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidation.Models
{
    public class Person
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

        [Required(ErrorMessage = "O número de telefone é um campo obrigatório")]
        [Phone(ErrorMessage = "O campo {0} deve estar em um formato valido")]
        [ValidateNever] //stop the validation in this property
        public string? Phone { get; set; }

        [Required(ErrorMessage = "A senha é um campo obrigatório")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "A confirmação da senha é um campo obrigatório")]
        [Compare("Password", ErrorMessage = "{0} deve ser igual ao campo {1}")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O preço é um campo obrigatório")]
        [Range(0, 1000.00, ErrorMessage = "O {0} deve ter valores entre R${1} e R${2}")]
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person name - {Name}, Person email - {Email}, Person phone - {Phone}, Person password - {Password}, Person confirm password - {ConfirmPassword}, Person price - {Price}";
        }

    }
}

//Model State
//IsValid - specifies whether there is at least one validation error or not (true or false)
//Values - contains each model property value with corresponding "Errors" property that contains list of validation errors of that model property
//ErrorCount - returns number of errors

//[Url(ErrorMessage = "Algo")]