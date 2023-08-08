using System.ComponentModel.DataAnnotations;

namespace Covid19ProjectAPI.Entities
{
    public class Users
    {
        [Key]
        public string userId { get; set; }

        [Required]
        public string userName { get; set; }

        [Required]
        public string token { get; set; }

        public string role { get; set; }
        
    }
}
