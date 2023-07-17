using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using ServiceContracts.Enums;
using Xunit.Abstractions;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;
        private readonly ITestOutputHelper _testOutputHelper;

        public PersonsServiceTest(ITestOutputHelper testOutputHelper) {
            _countriesService = new CountriesService(new PersonsDbContext(new DbContextOptionsBuilder<PersonsDbContext>().Options)); 
            _personsService = new PersonsService(new PersonsDbContext(new DbContextOptionsBuilder<PersonsDbContext>().Options), _countriesService);
            _testOutputHelper = testOutputHelper;
        }

        public List<CountryResponse> GetCountriesList()
        {
            List<CountryAddRequest> countryRequestList = new List<CountryAddRequest>()
            {
                new CountryAddRequest()
                {
                    CountryName = "Brazil"
                },
                new CountryAddRequest()
                {
                    CountryName = "USA"
                },
                new CountryAddRequest()
                {
                    CountryName = "South Korea"
                }
            };

            List<CountryResponse> countryResponseList = new List<CountryResponse>();

            foreach (CountryAddRequest country in countryRequestList)
            {
                countryResponseList.Add(_countriesService.AddCountry(country));
            }

            return countryResponseList;
        }

        public List<PersonResponse> GetPersonsList(List<CountryResponse> countryResponseList)
        {
            
            List<PersonAddRequest> requestList = new List<PersonAddRequest>()
            {
                new PersonAddRequest()
                {
                    PersonName = "Orrana",
                    PersonEmail = "orrana@example.com",
                    DateOfBirth = DateTime.Parse("1998-06-02"),
                    Gender = GenderOptions.Female,
                    CountryId = countryResponseList[0].CountryId,
                    Address = "Jaicos, Piaui",
                    ReceiveNewsLetters = true
                },
                new PersonAddRequest()
                {
                    PersonName = "Juliana",
                    PersonEmail = "juliana@example.com",
                    DateOfBirth = DateTime.Parse("1992-02-06"),
                    Gender = GenderOptions.Female,
                    CountryId = countryResponseList[0].CountryId,
                    Address = "Jaicos, Piaui",
                    ReceiveNewsLetters = true
                },
                new PersonAddRequest()
                {
                    PersonName = "Osvaldo",
                    PersonEmail = "osvaldo@example.com",
                    DateOfBirth = DateTime.Parse("1964-06-14"),
                    Gender = GenderOptions.Male,
                    CountryId = countryResponseList[1].CountryId,
                    Address = "Jaicos, Piaui",
                    ReceiveNewsLetters = false
                },
                new PersonAddRequest()
                {
                    PersonName = "Maria",
                    PersonEmail = "maria@example.com",
                    DateOfBirth = DateTime.Parse("1965-12-15"),
                    Gender = GenderOptions.Female,
                    CountryId = countryResponseList[2].CountryId,
                    Address = "Jaicos, Piaui",
                    ReceiveNewsLetters = false
                }
            };

            List<PersonResponse> responseList = new List<PersonResponse>();

            foreach (PersonAddRequest person in requestList)
            {
                responseList.Add(_personsService.AddPerson(person));
            }

            return responseList;
        }

        #region AddPerson
        [Fact]
        public void AddPerson_IsNull()
        {
            //Arrange
            PersonAddRequest? personAddRequest = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _personsService.AddPerson(personAddRequest);
            });
        }

        [Fact]
        public void AddPerson_PersonNameIsNull() {
            PersonAddRequest? personAddRequest = new PersonAddRequest()
            {
                PersonName = null
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _personsService.AddPerson(personAddRequest);
            });
        }

        [Fact]
        public void AddPerson_ProperPersonDetails()
        {
            PersonAddRequest? personAddRequest = new PersonAddRequest()
            {
                PersonName = "Orrana",
                PersonEmail = "orrana@example.com",
                DateOfBirth = DateTime.Parse("1998-06-02"),
                Gender = GenderOptions.Female,
                CountryId = new Guid(),
                Address = "Rua Otavio Coelho Rodrigues",
                ReceiveNewsLetters = true

            };

            //Act
            PersonResponse response = _personsService.AddPerson(personAddRequest);
            List<PersonResponse> personsList = _personsService.GetAllPersons();

            //Assert
            Assert.True(response.PersonId != Guid.Empty);
            Assert.Contains(response, personsList);
        }
        #endregion

        #region GetAllPersons
        [Fact]
        public void GetAllPersons_EmptyList()
        {
            //Act
            List<PersonResponse> responseList = _personsService.GetAllPersons();

            //Assert
            Assert.Empty(responseList);
        }

        [Fact]
        public void GetAllPersons_AddFewPersons() {
            //Act
            List<CountryResponse> countriesResponseList = GetCountriesList();
            List<PersonResponse> responseList = GetPersonsList(countriesResponseList);

            _testOutputHelper.WriteLine("Expected: ");
            foreach(PersonResponse response in responseList)
            {
                _testOutputHelper.WriteLine(response.ToString());
            }

            List<PersonResponse> personsResponseList = _personsService.GetAllPersons();

            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse response in personsResponseList)
            {
                _testOutputHelper.WriteLine(response.ToString());
            }

            foreach (PersonResponse expectedPerson in responseList)
            {
                //Assert
                Assert.Contains(expectedPerson, personsResponseList);
            }
        }
        #endregion

        #region GetPerson
        [Fact]
        public void GetPerson_NullPersonId()
        {
            //Arrange
            Guid? id = null;

            //Act
            PersonResponse? response = _personsService.GetPerson(id);

            //Assert
            Assert.Null(response);
        }

        [Fact]
        public void GetPerson_ProperPersonId()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest()
            {
                CountryName = "Brazil"
            };
            CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

            //Act
            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                PersonName = "Orrana",
                PersonEmail = "orrana@example.com",
                DateOfBirth = DateTime.Parse("1998-06-02"),
                Gender = GenderOptions.Female,
                CountryId = countryResponse.CountryId,
                Address = "Jaicos, Piaui",
                ReceiveNewsLetters = true
            };
            PersonResponse personResponse = _personsService.AddPerson(personAddRequest);
            PersonResponse? personIdResponse = _personsService.GetPerson(personResponse.PersonId);

            //Assert
            Assert.Equal(personResponse, personIdResponse);
        }
        #endregion

        #region GetFilteredPersons
        [Fact]
        public void GetFilteredPersons_EmptySearchText()
        {
            //Act
            List<CountryResponse> countriesResponseList = GetCountriesList();
            List<PersonResponse> responseList = GetPersonsList(countriesResponseList);

            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse response in responseList)
            {
                _testOutputHelper.WriteLine(response.ToString());
            }

            List<PersonResponse> personsResponseList = _personsService.GetFilteredPersons(nameof(Person.PersonName), "");

            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse response in personsResponseList)
            {
                _testOutputHelper.WriteLine(response.ToString());
            }

            foreach (PersonResponse expectedPerson in responseList)
            {
                //Assert
                Assert.Contains(expectedPerson, personsResponseList);
            }
        }

        [Fact]
        public void GetFilteredPersons_SearchByPersonName()
        {
            //Act
            List<CountryResponse> countriesResponseList = GetCountriesList();
            List<PersonResponse> responseList = GetPersonsList(countriesResponseList);

            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse response in responseList)
            {
                _testOutputHelper.WriteLine(response.ToString());
            }

            List<PersonResponse> personsResponseList = _personsService.GetFilteredPersons(nameof(Person.PersonName), "ana");

            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse response in personsResponseList)
            {
                _testOutputHelper.WriteLine(response.ToString());
            }

            foreach (PersonResponse expectedPerson in responseList)
            {
                if (expectedPerson.PersonName != null)
                {
                    if (expectedPerson.PersonName.Contains("ana", StringComparison.OrdinalIgnoreCase))
                    {
                        //Assert
                        Assert.Contains(expectedPerson, personsResponseList);
                    }
                }
            }
        }
        #endregion

        #region GetSortedPersons
        [Fact]
        public void GetSortedPersons_SortByPersonName()
        {
            //Act
            List<CountryResponse> countriesResponseList = GetCountriesList();
            List<PersonResponse> responseList = GetPersonsList(countriesResponseList);

            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse response in responseList)
            {
                _testOutputHelper.WriteLine(response.ToString());
            }

            List<PersonResponse> allPersons = _personsService.GetAllPersons();
            List<PersonResponse> personsResponseList = _personsService.GetSortedPersons(allPersons, nameof(Person.PersonName), SortOrderOptions.Descending);

            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse response in personsResponseList)
            {
                _testOutputHelper.WriteLine(response.ToString());
            }

            responseList = responseList.OrderByDescending(temp => temp.PersonName).ToList();

            for (var i = 0; i < responseList.Count(); i++)
            {
                Assert.Equal(responseList[i], personsResponseList[i]);
            }
        }
        #endregion

        #region UpdatePerson
        [Fact]
        public void UpdatePerson_NullPerson()
        {
            //Arrange
            PersonUpdateRequest? personUpdateRequest = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _personsService.UpdatePerson(personUpdateRequest);
            });
        }

        [Fact]
        public void UpdatePerson_InvalidPersonId()
        {
            //Arrange
            PersonUpdateRequest? personUpdateRequest = new PersonUpdateRequest()
            {
                PersonId = Guid.NewGuid()
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _personsService.UpdatePerson(personUpdateRequest);
            });
        }

        [Fact]
        public void UpdatePerson_PersonNameIsNull()
        {
            //Arrange
            List<CountryResponse> countriesResponseList = GetCountriesList();
            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                PersonName = "Orrana",
                PersonEmail = "example@algo.com",
                CountryId = countriesResponseList[0].CountryId,
                Gender = GenderOptions.Female
            };

            PersonResponse personResponse = _personsService.AddPerson(personAddRequest);

            PersonUpdateRequest? personUpdateRequest = personResponse.ToPersonUpdateRequest();
            personUpdateRequest.PersonName = null;
        
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _personsService.UpdatePerson(personUpdateRequest);
            });
        }

        [Fact]
        public void UpdatePerson_ProperUpdate()
        {
            //Arrange
            List<CountryResponse> countriesResponseList = GetCountriesList();
            List<PersonResponse> personResponseList = GetPersonsList(countriesResponseList);

            PersonUpdateRequest? personUpdateRequest = personResponseList[0].ToPersonUpdateRequest();
            personUpdateRequest.PersonName = "Lucia";
            personUpdateRequest.PersonEmail = "lucia@example.com";
            personUpdateRequest.Address = "Piaui";

            //Act
            PersonResponse personUpdateResponse = _personsService.UpdatePerson(personUpdateRequest);
            PersonResponse? actualPerson = _personsService.GetPerson(personUpdateResponse.PersonId);

            //Assert
            Assert.Equal(actualPerson, personUpdateResponse);
        }
        #endregion

        #region DeletePerson
        [Fact]
        public void DeletePerson_ValidPersonId() {
            List<CountryResponse> countriesList = GetCountriesList();
            List<PersonResponse> personsList = GetPersonsList(countriesList);

            bool isDeleted = _personsService.DeletePerson(personsList[0].PersonId);

            Assert.True(isDeleted);
        }

        [Fact]
        public void DeletePerson_InvalidPersonId()
        {
            bool isDeleted = _personsService.DeletePerson(Guid.NewGuid());

            Assert.False(isDeleted);
        }
        #endregion
    }
}
