using System.Globalization;

namespace Covid19ProjectAPI.Entities
{
    public class AddCaseDTO
    {
        public string countryId { get; set; } 

        public string cityId { get; set; }

        public string personName { get; set; }

        public bool active { get; set; }

        public int age { get; set; }

        public bool dead { get; set; }

        public bool cured { get; set; }

        public string dateRegistered { get; set; }

    }
}
