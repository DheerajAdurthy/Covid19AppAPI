using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid19ProjectAPI.Entities
{
    public class WishListDTO
    {
        public string wishListCountryName { get; set; }

        public string userId { get; set; }

        public string countryId { get; set; }

    }
}
