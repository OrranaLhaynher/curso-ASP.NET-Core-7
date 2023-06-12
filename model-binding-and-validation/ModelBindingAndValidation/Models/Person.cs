using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidation.Models
{
    public class Person
    {
        [Required] //signifa que a propriedade name é obrigatoria
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person name - {Name}, Person email - {Email}, Person password - {Password}, Person confirm password - {ConfirmPassword}, Person price - {Price}";
        }

    }
}
