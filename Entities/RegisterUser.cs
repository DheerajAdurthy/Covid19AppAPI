using System.ComponentModel.DataAnnotations;

namespace Covid19ProjectAPI.Entities
{
    public class RegisterUser
    {
        [Key]
        public int registerId { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string emailId { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string confirmPassword { get; set; }

        public string role { get; set; }
    }
}
