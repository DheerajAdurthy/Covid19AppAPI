using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid19ProjectAPI.Entities
{
    public class CityDTO
    {

        public string cityId { get; set; }

        public string cityName { get; set; }

        public double? totalCasesReported { get; set; }

        public double? totalActiveCases { get; set; }

        public double? totalDeaths { get; set; }

        public double? totalCuredCases { get; set; }

        public string? CountryId { get; set; }
    }
}
