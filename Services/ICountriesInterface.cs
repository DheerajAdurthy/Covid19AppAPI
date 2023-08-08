using Covid19ProjectAPI.Entities;

namespace Covid19ProjectAPI.Services
{
    public interface ICountriesInterface
    {
        void AddCountry(Countries country);

        void AddCity(Cities city);

        void AddCaseInCity(CasesInCities newCase);

        List<Countries> GetAllCountries();

        List<Cities> GetAllCities();
        List<Cities> GetCasesInCitiesByCountryId(string countryId);

        List<CasesInCities> GetCasesInCitiesByCityId(string cityId);

        public void AddCaseFromUserData(AddCaseDTO addCase);
    }
}
