using System.ComponentModel.DataAnnotations;

namespace Covid19ProjectAPI.Entities
{
    public class Countries
    {
        [Key]
        public string countryId { get; set; }

        [Required]
        [StringLength(50)]
        public string countryName { get; set; }

        public double? totalCasesReported { get; set; }

        public double? totalActiveCases { get; set; }

        public double? totalDeaths { get; set; }

        public double? totalCuredCases { get; set; }
    }
}
