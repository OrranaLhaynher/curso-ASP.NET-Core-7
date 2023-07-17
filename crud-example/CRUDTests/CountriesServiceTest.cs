using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using Services;
using Microsoft.EntityFrameworkCore;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;

        public CountriesServiceTest()
        {
            _countriesService = new CountriesService(new PersonsDbContext(new DbContextOptionsBuilder<PersonsDbContext>().Options));
        }

        #region AddCountry
        [Fact]
        public void AddCountry_IsNull()
        {
            //Arrange
            CountryAddRequest? countryAddRequest = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countriesService.AddCountry(countryAddRequest);
            });
        }

        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            //Arrange
            CountryAddRequest? countryAddRequest = new CountryAddRequest()
            {
                CountryName = null
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(countryAddRequest);
            });
        }

        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest? countryAddRequest = new CountryAddRequest()
            {
                CountryName = "USA"
            };
            CountryAddRequest? countryAddRequest2 = new CountryAddRequest()
            {
                CountryName = "USA"
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(countryAddRequest);
                _countriesService.AddCountry(countryAddRequest2);
            });
        }

        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            //Arrange
            CountryAddRequest? countryAddRequest = new CountryAddRequest()
            {
                CountryName = "Japan"
            };

            //Act
            CountryResponse response = _countriesService.AddCountry(countryAddRequest);
            List<CountryResponse> countriesList = _countriesService.GetAllCountries();

            //Assert
            Assert.True(response.CountryId != Guid.Empty);
            Assert.Contains(response, countriesList);
        }
        #endregion

        #region GetAllCountries
        [Fact]
        public void GetAllCountries_EmptyList()
        {
            //Act
            List<CountryResponse> responseList = _countriesService.GetAllCountries();

            //Assert
            Assert.Empty(responseList);
        }

        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            //Act
            List<CountryAddRequest> requestList = new List<CountryAddRequest>()
            {
                new CountryAddRequest()
                {
                    CountryName = "USA"
                },
                new CountryAddRequest()
                {
                    CountryName = "Japan"
                },
                new CountryAddRequest()
                {
                    CountryName = "Brazil"
                }
            };

            List<CountryResponse> responseList = new List<CountryResponse>();

            foreach (CountryAddRequest country in requestList)
            {
                responseList.Add(_countriesService.AddCountry(country));
            }

            List<CountryResponse> countriesResponseList = _countriesService.GetAllCountries();

            foreach(CountryResponse expectedCountry in  responseList)
            {
                //Assert
                Assert.Contains(expectedCountry, countriesResponseList);
            }
         
        }
        #endregion

        #region GetCountry
        [Fact]
        public void GetCountry_NullCountryId()
        {
            //Arrange
            Guid? id = null;

            //Act
            CountryResponse? response = _countriesService.GetCountry(id);

            //Assert
            Assert.Null(response);
        }

        [Fact]
        public void GetCountry_ProperCountryId() 
        {
            //Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest(){
                CountryName = "Brazil"
            };

            CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

            //Act
            CountryResponse? countryIdResponse = _countriesService.GetCountry(countryResponse.CountryId);

            //Assert
            Assert.Equal(countryResponse, countryIdResponse);
        }
        #endregion
    }
}
