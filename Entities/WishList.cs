using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid19ProjectAPI.Entities
{
    public class WishList
    {
        [Key]
        public int wishlistId { get; set; }

        public string wishListCountryName { get; set; }

        public string userId { get; set; }

        [ForeignKey("Countries")]
        public string countryId { get; set; }

        public Users? Users { get; set; }

        public Countries? Countries { get; set; }
    }
}
