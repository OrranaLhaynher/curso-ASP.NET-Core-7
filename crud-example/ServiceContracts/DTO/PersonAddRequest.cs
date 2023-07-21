using Entities;
using ServiceContracts.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ServiceContracts.DTO
{
    public class PersonAddRequest
    {
        [Required(ErrorMessage = "Person name is required")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "Person email is required")]
        [EmailAddress(ErrorMessage = "Email value should be a valid email")]
        [DataType(DataType.EmailAddress)]
        public string? PersonEmail { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select gender of the person")]
        public GenderOptions? Gender { get; set; }

        [Required(ErrorMessage = "Please, select a country")]
        public Guid? CountryId { get; set; }

        public string? Address { get; set; }

        public bool ReceiveNewsLetters { get; set; }

        public Person ToPerson()
        {
            return new Person()
            {
                PersonName = PersonName,
                PersonEmail = PersonEmail,
                DateOfBirth = DateOfBirth,
                Gender = Gender.ToString(),
                CountryId = CountryId,
                Address = Address,
                ReceiveNewsLetters = ReceiveNewsLetters
            };
        }
    }
}
