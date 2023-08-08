using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid19ProjectAPI.Entities
{
    public class Cities
    {
        [Key]
        public string cityId { get; set; }

        [Required]
        [StringLength(50)]
        public string cityName { get; set; }

        public double? totalCasesReported { get; set; }

        public double? totalActiveCases { get; set; }

        public double? totalDeaths { get; set; }

        public double? totalCuredCases { get; set; }

        [ForeignKey("Countries")]
        public string? CountryId { get; set; }

        public Countries? Countries { get; set; }
    }
}
