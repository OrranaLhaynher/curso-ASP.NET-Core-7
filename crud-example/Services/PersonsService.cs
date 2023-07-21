using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;
using System.Drawing;
using System.Linq.Expressions;

namespace Services
{
    public class PersonsService : IPersonsService
    {
        private readonly PersonsDbContext _db;
        private readonly ICountriesService _countriesService;

        public PersonsService(PersonsDbContext personsDbContext, ICountriesService countriesService)
        {
            _db = personsDbContext;
            _countriesService = countriesService;
        }

        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            PersonResponse response = person.ToPersonResponse();
            response.Country = _countriesService.GetCountry(person.CountryId)?.CountryName;

            return response;
        }

        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            if (personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }

            ValidationHelper.ModelValidation(personAddRequest);

            Person person = personAddRequest!.ToPerson();

            person.PersonId = Guid.NewGuid();
            _db.Persons.Add(person);
            _db.SaveChanges();
            //_db.sp_InsertPerson(person);

            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            //return _db.Persons.ToList().Select(temp => ConvertPersonToPersonResponse(temp)).ToList();
            return _db.sp_GetAllPersons().Select(temp => ConvertPersonToPersonResponse(temp)).ToList();
        }

        public PersonResponse? GetPerson(Guid? personId)
        {
            if (personId == null)
            {
                return null;
            }

            Person? person = _db.Persons.FirstOrDefault(temp => temp.PersonId == personId);

            if ( person == null)
            {
                return null;
            }

            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString)
        {
            List<PersonResponse> allPersons = GetAllPersons();
            List<PersonResponse> matchingPersons = allPersons;

            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
            {
                return matchingPersons;
            }

            switch (searchBy)
            {
                case nameof(PersonResponse.PersonName):
                    matchingPersons = allPersons.Where(temp => !string.IsNullOrEmpty(temp.PersonName) ? temp.PersonName.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(PersonResponse.PersonEmail):
                    matchingPersons = allPersons.Where(temp => !string.IsNullOrEmpty(temp.PersonEmail) ? temp.PersonEmail.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(PersonResponse.DateOfBirth):
                    matchingPersons = allPersons.Where(temp => (temp.DateOfBirth != null) ? temp.DateOfBirth.Value.ToString("dd-MM-yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(PersonResponse.Gender):
                    matchingPersons = allPersons.Where(temp => !string.IsNullOrEmpty(temp.Gender) ? temp.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(PersonResponse.CountryId):
                    matchingPersons = allPersons.Where(temp => !string.IsNullOrEmpty(temp.Country) ? temp.Country.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(PersonResponse.Address):
                    matchingPersons = allPersons.Where(temp => !string.IsNullOrEmpty(temp.Address) ? temp.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                default:
                    matchingPersons = allPersons; break;
            }

            return matchingPersons;
        }

        public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy)) return allPersons;

            List<PersonResponse> sortedPersons = (sortBy, sortOrder) switch
            {
                //PersonName
                (nameof(PersonResponse.PersonName), SortOrderOptions.Ascending) => allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.PersonName), SortOrderOptions.Descending) => allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                //PersonEmail
                (nameof(PersonResponse.PersonEmail), SortOrderOptions.Ascending) => allPersons.OrderBy(temp => temp.PersonEmail, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.PersonEmail), SortOrderOptions.Descending) => allPersons.OrderByDescending(temp => temp.PersonEmail, StringComparer.OrdinalIgnoreCase).ToList(),

                //DateOfBirth
                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.Ascending) => allPersons.OrderBy(temp => temp.DateOfBirth).ToList(),
                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.Descending) => allPersons.OrderByDescending(temp => temp.DateOfBirth).ToList(),

                //Age
                (nameof(PersonResponse.Age), SortOrderOptions.Ascending) => allPersons.OrderBy(temp => temp.Age).ToList(),
                (nameof(PersonResponse.Age), SortOrderOptions.Descending) => allPersons.OrderByDescending(temp => temp.Age).ToList(),

                //Gender
                (nameof(PersonResponse.Gender), SortOrderOptions.Ascending) => allPersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Gender), SortOrderOptions.Descending) => allPersons.OrderByDescending(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                //Country
                (nameof(PersonResponse.Country), SortOrderOptions.Ascending) => allPersons.OrderBy(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Country), SortOrderOptions.Descending) => allPersons.OrderByDescending(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

                //Address
                (nameof(PersonResponse.Address), SortOrderOptions.Ascending) => allPersons.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Address), SortOrderOptions.Descending) => allPersons.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                //ReceiveNewsLetters
                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.Ascending) => allPersons.OrderBy(temp => temp.ReceiveNewsLetters).ToList(),
                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.Descending) => allPersons.OrderByDescending(temp => temp.ReceiveNewsLetters).ToList(),

                _ => allPersons
            };

            return sortedPersons;
        }

        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if (personUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(Person));
            }

            ValidationHelper.ModelValidation(personUpdateRequest);

            Person? person = _db.Persons.FirstOrDefault(temp => temp.PersonId == personUpdateRequest.PersonId);
            
            if (person == null) throw new ArgumentException("Given person id does not exist");

            person.PersonName = personUpdateRequest.PersonName;
            person.PersonEmail = personUpdateRequest.PersonEmail;
            person.DateOfBirth = personUpdateRequest.DateOfBirth;
            person.CountryId = personUpdateRequest.CountryId;
            person.Address = personUpdateRequest.Address;
            person.Gender = personUpdateRequest.Gender.ToString();
            person.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            //_db.SaveChanges();

            _db.sp_UpdatePerson(person); //update

            return ConvertPersonToPersonResponse(person);
        }

        public bool DeletePerson(Guid? personId)
        {
            if (personId == null) { throw new ArgumentNullException( nameof(personId)); }

            Person? person = _db.Persons.FirstOrDefault(temp => temp.PersonId == personId);

            if (person == null) return false;

            //_db.Persons.Remove(_db.Persons.First(temp => temp.PersonId == personId));
            //_db.SaveChanges();
            _db.sp_DeletePerson(_db.Persons.First(temp => temp.PersonId == personId));

            return true;
        }
    }
}
