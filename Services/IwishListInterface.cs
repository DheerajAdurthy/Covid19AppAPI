using Covid19ProjectAPI.Entities;

namespace Covid19ProjectAPI.Services
{
    public interface IwishListInterface
    {
       WishList AddWishList(WishList wishlist);

        List<WishListResponseDTO> GetUserWishlists(string userId);

        WishList DeleteWishList(string countryId,string userId);

        bool GetWishListItemStatus(string countryId,string userId);
    }
}
