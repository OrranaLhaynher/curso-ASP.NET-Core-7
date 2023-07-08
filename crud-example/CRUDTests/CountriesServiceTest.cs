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
    }
}
