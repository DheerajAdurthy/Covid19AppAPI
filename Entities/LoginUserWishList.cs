using System.ComponentModel.DataAnnotations;

namespace Covid19ProjectAPI.Entities
{
    public class LoginUserWishList
    {
       
        [Key]
        public int Id { get; set; }

        public string userId { get; set; }

        public string userName { get; set; }
    }
}
