using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using System.Linq;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly List<Country> _countries;

        public CountriesService(bool initialize = true) 
        { 
            _countries = new List<Country>();

            if (initialize)
            {
                _countries.AddRange(new List<Country>(){
                    new Country()
                    {
                        CountryId = Guid.Parse("E94BB413-37ED-462F-ABAC-67D52A611A0F"),
                        CountryName = "Brazil"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("DED8A45E-FFB9-44CF-90CF-5515ECE783EA"),
                        CountryName = "South Korea"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("8F89DBBE-E372-4B88-81C1-8086268DDEDF"),
                        CountryName = "United States"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("F477EECF-2455-47E0-B659-8F17435FE836"),
                        CountryName = "Indonesia"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("91E48BE1-8B81-4BA9-AC22-7826CBF4DEE9"),
                        CountryName = "Australia"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("FBF748CB-E4CB-4809-A997-011FE02373F1"),
                        CountryName = "India"
                    }
                });
            }
        }

        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            if (countryAddRequest.CountryName == null) 
            { 
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Given country name already exists");
            }

            Country country = countryAddRequest!.ToCountry();

            country.CountryId = Guid.NewGuid();
            _countries.Add(country);

            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountry(Guid? countryId)
        {
            if (countryId == null)
            {
                return null;
            }

            Country? country = _countries.FirstOrDefault(temp => temp.CountryId == countryId);

            if (country == null)
            {
                return null;
            }
            return country.ToCountryResponse();
        }
    }

}