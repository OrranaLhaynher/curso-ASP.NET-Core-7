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
        private readonly List<Person> _persons;
        private readonly ICountriesService _countriesService;

        public PersonsService(bool initialize = true)
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();

            if (initialize)
            {
                _persons.AddRange(new List<Person>()
                {
                    new Person()
                    {
                        PersonId = Guid.Parse("35B5E327-B767-411A-BFC0-CDB6D00EAD5C"),
                        PersonName = "Raimundo",
                        PersonEmail = "rarnow0@squarespace.com",
                        Gender = "Male",
                        DateOfBirth = DateTime.Parse("1928-11-19"),
                        CountryId = Guid.Parse("E94BB413-37ED-462F-ABAC-67D52A611A0F"),
                        Address = "0420 Prairie Rose Point",
                        ReceiveNewsLetters = true
                    },
                    new Person()
                    {
                        PersonId = Guid.Parse("3AF8FE58-B51F-4336-9A79-26A4A353A3AA"),
                        PersonName = "Arvin",
                        PersonEmail = "akittley1@aol.com",
                        Gender = "Male",
                        DateOfBirth = DateTime.Parse("1982-04-30"),
                        CountryId = Guid.Parse("8F89DBBE-E372-4B88-81C1-8086268DDEDF"),
                        Address = "2 Farragut Center",
                        ReceiveNewsLetters = true
                    },
                    new Person()
                    {
                        PersonId = Guid.Parse("64EF15C8-14C1-4932-BCC5-57B46B074360"),
                        PersonName = "Gaylor",
                        PersonEmail = "gdegan3@ebay.co.uk",
                        Gender = "Male",
                        DateOfBirth = DateTime.Parse("2002-09-05"),
                        CountryId = Guid.Parse("F477EECF-2455-47E0-B659-8F17435FE836"),
                        Address = "7713 Green Ridge Alley",
                        ReceiveNewsLetters = false
                    },
                    new Person()
                    {
                        PersonId = Guid.Parse("6578A160-78D1-43EB-B74F-5113DD56AAC5"),
                        PersonName = "Betteann",
                        PersonEmail = "bianelli4@oracle.com",
                        Gender = "Female",
                        DateOfBirth = DateTime.Parse("1919-04-22"),
                        CountryId = Guid.Parse("91E48BE1-8B81-4BA9-AC22-7826CBF4DEE9"),
                        Address = "990 Carberry Junction",
                        ReceiveNewsLetters = true
                    },
                    new Person()
                    {
                        PersonId = Guid.Parse("954A3720-45C9-4EDE-9425-064C6C37FA1F"),
                        PersonName = "Gaylor",
                        PersonEmail = "ggellier5@yolasite.com",
                        Gender = "Nonbinary",
                        DateOfBirth = DateTime.Parse("2005-03-21"),
                        CountryId = Guid.Parse("DED8A45E-FFB9-44CF-90CF-5515ECE783EA"),
                        Address = "5 Goodland Place",
                        ReceiveNewsLetters = true
                    },
                    new Person()
                    {
                        PersonId = Guid.Parse("73ECC7ED-2932-4F3E-9D86-AC4429C86D15"),
                        PersonName = "Hubey",
                        PersonEmail = "hduffill6@behance.net",
                        Gender = "Male",
                        DateOfBirth = DateTime.Parse("1971-12-24"),
                        CountryId = Guid.Parse("FBF748CB-E4CB-4809-A997-011FE02373F1"),
                        Address = "77 Village Green Plaza",
                        ReceiveNewsLetters = false
                    },
                    new Person()
                    {
                        PersonId = Guid.Parse("7FCF7A9D-A693-4BD4-8124-38FF35EC1500"),
                        PersonName = "Rafaellle",
                        PersonEmail = "rcharteris7@furl.net",
                        Gender = "Nonbinary",
                        DateOfBirth = DateTime.Parse("1990-01-10"),
                        CountryId = Guid.Parse("91E48BE1-8B81-4BA9-AC22-7826CBF4DEE9"),
                        Address = "9 Grim Way",
                        ReceiveNewsLetters = true
                    },
                    new Person()
                    {
                        PersonId = Guid.Parse("1D1DC2A3-6C56-49DC-86D2-44C9FC7F858E"),
                        PersonName = "Gwendolyn",
                        PersonEmail = "gloghan2@vistaprint.com",
                        Gender = "Female",
                        DateOfBirth = DateTime.Parse("1981-04-30"),
                        CountryId = Guid.Parse("FBF748CB-E4CB-4809-A997-011FE02373F1"),
                        Address = "2 Homewood Junction",
                        ReceiveNewsLetters = false
                    },
                    new Person()
                    {
                        PersonId = Guid.Parse("AE21E706-07A7-4DE7-B73C-449284D3D2F4"),
                        PersonName = "Selestina",
                        PersonEmail = "sclemensen8@cam.ac.uk",
                        Gender = "Female",
                        DateOfBirth = DateTime.Parse("1968-02-20"),
                        CountryId = Guid.Parse("E94BB413-37ED-462F-ABAC-67D52A611A0F"),
                        Address = "10884 Bartillon Street",
                        ReceiveNewsLetters = false
                    },
                    new Person()
                    {
                        PersonId = Guid.Parse("2325F7D8-468E-4089-B43F-EB6E40CE3851"),
                        PersonName = "Bernard",
                        PersonEmail = "bglassup9@netscape.com",
                        Gender = "Male",
                        DateOfBirth = DateTime.Parse("2003-10-01"),
                        CountryId = Guid.Parse("91E48BE1-8B81-4BA9-AC22-7826CBF4DEE9"),
                        Address = "9104 Thierer Point",
                        ReceiveNewsLetters = false
                    }
                });
            }
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
            _persons.Add(person);

            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            return _persons.Select(temp => ConvertPersonToPersonResponse(temp)).ToList();
        }

        public PersonResponse? GetPerson(Guid? personId)
        {
            if (personId == null)
            {
                return null;
            }

            Person? person = _persons.FirstOrDefault(temp => temp.PersonId == personId);

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

            Person? person = _persons.FirstOrDefault(temp => temp.PersonId == personUpdateRequest.PersonId);
            
            if (person == null) throw new ArgumentException("Given person id does not exist");

            person.PersonName = personUpdateRequest.PersonName;
            person.PersonEmail = personUpdateRequest.PersonEmail;
            person.DateOfBirth = personUpdateRequest.DateOfBirth;
            person.CountryId = personUpdateRequest.CountryId;
            person.Address = personUpdateRequest.Address;
            person.Gender = personUpdateRequest.Gender.ToString();
            person.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            return ConvertPersonToPersonResponse(person);
        }

        public bool DeletePerson(Guid? personId)
        {
            if (personId == null) { throw new ArgumentNullException( nameof(personId)); }

            Person? person = _persons.FirstOrDefault(temp => temp.PersonId == personId);

            if (person == null) return false;

            _persons.RemoveAll(temp => temp.PersonId == personId);

            return true;
        }
    }
}
