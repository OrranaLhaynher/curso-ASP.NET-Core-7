using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using ServiceContracts.Enums;

namespace CRUDTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;

        public PersonsServiceTest() { 
            _personsService = new PersonsService();
            _countriesService = new CountriesService();
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
    }
}
