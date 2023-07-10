using Entities;
using ServiceContracts.Enums;

namespace ServiceContracts.DTO
{
    public class PersonResponse
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? PersonEmail { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryId { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }
        public double? Age { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(PersonResponse)) return false;

            PersonResponse personObj = (PersonResponse)obj;

            return PersonId == personObj.PersonId && 
                PersonName == personObj.PersonName && 
                PersonEmail == personObj.PersonEmail && 
                DateOfBirth == personObj.DateOfBirth &&
                Gender == personObj.Gender &&
                CountryId == personObj.CountryId &&
                Address == personObj.Address &&
                ReceiveNewsLetters == personObj.ReceiveNewsLetters;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Person Id - {PersonId}, Person name - {PersonName}, Person email - {PersonEmail}, Date of birth - {DateOfBirth?.ToString("dd-MM-yyyy")}, Gender - {Gender}, Country Id - {CountryId}, Address - {Address}, Receive newsletters - {ReceiveNewsLetters}";
        }

        public PersonUpdateRequest ToPersonUpdateRequest()
        {
            return new PersonUpdateRequest()
            {
                PersonId = PersonId,
                PersonName = PersonName,
                PersonEmail = PersonEmail,
                DateOfBirth = DateOfBirth,
                Gender = (GenderOptions)Enum.Parse(typeof(GenderOptions), Gender, true),
                CountryId = CountryId,
                Address = Address,
                ReceiveNewsLetters = ReceiveNewsLetters
            };
        }
    }

    public static class PersonExtensions
    { 
        public static PersonResponse ToPersonResponse(this Person person)
        {
            return new PersonResponse()
            {
                PersonId = person.PersonId,
                PersonName = person.PersonName,
                PersonEmail = person.PersonEmail,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                CountryId = person.CountryId,
                Address = person.Address,
                ReceiveNewsLetters = person.ReceiveNewsLetters,
                Age = (person.DateOfBirth != null) ? Math.Round(((TimeSpan)(DateTime.Now - person.DateOfBirth)).TotalDays / 365.25) : null
            };
        }
    }
}
