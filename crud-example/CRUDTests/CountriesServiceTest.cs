using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using Services;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;

        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }

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

            //Assert
            Assert.True(response.CountryId != Guid.Empty);
        }
    }
}
