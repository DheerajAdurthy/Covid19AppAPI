using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid19ProjectAPI.Entities
{
    public class CasesDTO
    {
        public int caseId { get; set; }

        public string personName { get; set; }

        public bool active { get; set; }

        public int age { get; set; }    

        public bool inactiveOrdeath { get; set; }

        public bool cured { get; set; }

        public string dateRegistered { get; set; }

        public string cityId { get; set; }

    }
}
