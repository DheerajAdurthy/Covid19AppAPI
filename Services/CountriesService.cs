using Covid19ProjectAPI.Entities;

namespace Covid19ProjectAPI.Services
{
    public class CountriesService:ICountriesInterface
    {
        private readonly RegisterDBContext dBContext;

        public CountriesService(RegisterDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public void AddCountry(Countries country)
        {
            try
            {
                dBContext.countries.Add(country);
                dBContext.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
        }

       public void AddCity(Cities City)
        {
            try
            {
                this.dBContext.cities.Add(City);
                this.dBContext.SaveChanges();
                
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void AddCaseInCity(CasesInCities CaseInCities)
        {
            try
            {
                this.dBContext.casesInCities.Add(CaseInCities);
                this.dBContext.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }

        }

        public List<Countries> GetAllCountries()
        {
            try
            {
                List<Countries> countries=dBContext.countries.ToList();
                return countries;
            } 
            catch(Exception) { throw; }
        }

        public List<Cities> GetAllCities()
        {
            try
            {
                List<Cities> cities=dBContext.cities.ToList();
                return cities;
            }
            catch(Exception) { throw; }
        }

       public List<Cities> GetCasesInCitiesByCountryId(string countryId)
        {
            try
            {
                Cities city = dBContext.cities.FirstOrDefault(x => x.CountryId == countryId);
                if (city != null)
                {
                    List<Cities> cities = (from country in dBContext.countries
                                           join cit in dBContext.cities
                                           on country.countryId equals cit.CountryId
                                           where cit.CountryId == countryId
                                           select cit).ToList();
                    return cities;
                }
                return null;
            }
            catch (Exception) { throw; }
        }

        public List<CasesInCities> GetCasesInCitiesByCityId(string cityId)
        {
            try
            {
                CasesInCities caseIncity=dBContext.casesInCities.FirstOrDefault(x => x.cityId== cityId);
                if(caseIncity != null)
                {
                    List<CasesInCities> casesInCity = (from city in dBContext.cities
                                                       join cases in dBContext.casesInCities
                                                       on city.cityId equals cases.cityId
                                                       where cases.cityId == cityId
                                                       select cases).ToList();
                    return casesInCity;
                }
                return null;
               
            }
            catch(Exception) { throw; }
        }

        public void AddCaseFromUserData(AddCaseDTO addCase)
        {
            try
            {
                Countries country = dBContext.countries.Find(addCase.countryId);
                Cities city = dBContext.cities.Find(addCase.cityId);
                
                if (country != null && city!=null)
                {
                   if(addCase.active)
                    {
                        country.totalCasesReported = country.totalCasesReported+1;
                        country.totalActiveCases=country.totalActiveCases+1;
                        city.totalCasesReported=city.totalCasesReported+1;
                        city.totalActiveCases=city.totalActiveCases+1;
                    }
                   if(addCase.dead) 
                    {
                      country.totalDeaths= country.totalDeaths+1;
                      city.totalDeaths = city.totalDeaths+1;
                   }
                   if(addCase.cured)
                    {
                        country.totalCuredCases= country.totalCuredCases+1;
                        city.totalCuredCases = city.totalCuredCases+1;
                    }
                    CasesInCities caseIncity = new CasesInCities()
                    { 
                        cityId=addCase.cityId,
                        active=addCase.active,
                        inactiveOrdeath=addCase.dead,
                        cured=addCase.cured,
                        dateRegistered=addCase.dateRegistered,
                        age=addCase.age,
                        personName=addCase.personName,
                    };

                   dBContext.countries.Update(country);
                   dBContext.cities.Update(city);
                   dBContext.casesInCities.Add(caseIncity);
                   dBContext.SaveChanges();
                }                
            }
            catch(Exception) { throw; }
        }
    }
}
