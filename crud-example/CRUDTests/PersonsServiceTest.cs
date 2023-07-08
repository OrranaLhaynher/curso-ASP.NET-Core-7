using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using ServiceContracts.Enums;

namespace CRUDTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonsService _personsService;

        public PersonsServiceTest() { 
            _personsService = new PersonsService();
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
    }
}
