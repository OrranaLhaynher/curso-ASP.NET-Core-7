using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }

        [StringLength(40)]
        public string? PersonName { get; set; }

        [StringLength(40)]
        public string? PersonEmail { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        public Guid? CountryId { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public bool ReceiveNewsLetters { get; set; }
    }
}
