using Covid19ProjectAPI.Entities;
using Covid19ProjectAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Covid19ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesInterface countriesInterface;

        public CountriesController(ICountriesInterface countriesInterface)
        {
            this.countriesInterface = countriesInterface;
        }

        [HttpPost, Route("AddCountry")]
        public IActionResult AddCountry(Countries country)
        {
            try
            {
                if (country == null)
                {
                    return StatusCode(401, "Invalid Country Details");
                }
                this.countriesInterface.AddCountry(country);
                return StatusCode(200, country);
            }
            catch (Exception) { throw; }
        }

        [HttpPost, Route("AddCity")]
         public IActionResult AddCity(CityDTO city)
         {
             try
             {
                 if (city == null)
                 {
                     return StatusCode(401, "invalid city details");
                 }
                 Cities newCity = new Cities() { cityId=city.cityId,cityName=city.cityName,CountryId=city.CountryId, totalCasesReported=city.totalCasesReported,totalActiveCases=city.totalActiveCases,totalCuredCases=city.totalCuredCases,totalDeaths=city.totalDeaths };
                 this.countriesInterface.AddCity(newCity);
                 return StatusCode(200, newCity);
             }
            catch(Exception) { throw; }
         }

        [HttpPost,Route("AdddCase")]

        public IActionResult AddCase(CasesDTO Case)
        {
            try
            {
                if (Case == null)
                {
                    return StatusCode(401, "invalid case details");
                }
                CasesInCities newCase = new CasesInCities()
                {
                    caseId = Case.caseId,
                    dateRegistered = Case.dateRegistered,
                    cured = Case.cured,
                    active = Case.active,
                    inactiveOrdeath = Case.inactiveOrdeath,
                    personName = Case.personName,
                    cityId=Case.cityId,
                    age=Case.age,
                };
                this.countriesInterface.AddCaseInCity(newCase);
                return StatusCode(200, Case);
            }
            catch(Exception) { throw; }
        }




        [HttpGet,Route("GetAllCountries")]

        public IActionResult GetAllCountries()
        {
            try
            {
                List<Countries> countries=countriesInterface.GetAllCountries();
                if (countries != null)
                {
                    return StatusCode(200, countries);
                }
                else
                {
                    return StatusCode(400, "No Countries have cases");
                } 
            }
            catch(Exception) { throw; }
        }

        [HttpGet,Route("GetAllCities")]

        public IActionResult GetAllCities()
        {
            try
            {
                List<Cities> cities=countriesInterface.GetAllCities();
                if (cities != null)
                {
                    return StatusCode(200, cities);
                }
                else
                {
                    return StatusCode(400, "No Countries have cases");
                }
            }
            catch (Exception) { throw; }
        }

        [HttpGet,Route("GetCasesByCountryId/{countryId}")]

        public IActionResult GetCasesByCountryId(string countryId)
        {
            try
            {
                List<Cities> cities=countriesInterface.GetCasesInCitiesByCountryId(countryId);
                if (cities != null)
                {
                    return StatusCode(200, cities);
                }
                return StatusCode(400, "No cases exists in Cities for given countryName");
            }
            catch (Exception) { throw; }
        }

        [HttpGet,Route("GetCasesByCityId/{cityId}")]

        public IActionResult GetCasesByCityId(string cityId)
        {
            try
            {
                List<CasesInCities> casesInCities = countriesInterface.GetCasesInCitiesByCityId(cityId);
                if (casesInCities != null)
                {
                    return StatusCode(200,casesInCities);
                }
                return StatusCode(400, "No cases exists in the Current City");
            }
            catch (Exception) { throw; }
        }


        [HttpPost,Route("AddCaseByAdmin")]
        public IActionResult AddCaseByAdmin(AddCaseDTO addCase)
        {
            try
            {
                if (addCase != null)
                {
                    countriesInterface.AddCaseFromUserData(addCase);
                    return StatusCode(200, new JsonResult("Case Added Succesfully"));
                }
                return StatusCode(400, new JsonResult("Invalid User Case Data")); 
            }
            catch(Exception) { throw; }

        }
    }

}
