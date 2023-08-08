using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid19ProjectAPI.Entities
{
    public class CasesInCities
    {
        [Key]
        public int caseId { get; set; }

        [Required]
        [StringLength(50)]
        public string personName { get; set; }

        [Required]
        public bool active { get; set; }

        public int age { get; set; }

        [Required]
        public bool inactiveOrdeath { get; set; }

        [Required]
        public bool cured { get; set; }

        [Required]
        public string dateRegistered { get; set; }


        [ForeignKey("Cities")]
        public string cityId { get; set; }

        public Cities? Cities { get; set; }

    }
}
