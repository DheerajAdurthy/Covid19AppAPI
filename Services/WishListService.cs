using Covid19ProjectAPI.Entities;

namespace Covid19ProjectAPI.Services
{
    public class WishListService : IwishListInterface
    {
        private readonly RegisterDBContext _dbContext;

        public WishListService(RegisterDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public WishList AddWishList(WishList wishlist)
        {
            try
            {
                Users user = _dbContext.users.Find(wishlist.userId);
                WishList wishListItem=_dbContext.usersWishlist.SingleOrDefault(x=>x.userId== wishlist.userId && x.countryId==wishlist.countryId);
                if(wishListItem!=null)
                {
                    return null;
                }
                if (user != null)
                {
                    _dbContext.usersWishlist.Add(wishlist);
                    _dbContext.SaveChanges();
                    return wishlist;
                }
                return null;
            }
            catch (Exception ex) { throw; }
        }

        public List<WishListResponseDTO> GetUserWishlists(string userId)
        {
            try
            {
                Users user = _dbContext.users.FirstOrDefault(x=>x.userId==userId);
                if (user != null)
                {
                    List<WishListResponseDTO> resDTO =(from wishes in _dbContext.usersWishlist
                               join country in _dbContext.countries
                               on wishes.countryId equals country.countryId
                               where wishes.userId == userId
                               select new WishListResponseDTO() 
                               { 
                                   wishListCountryName = wishes.wishListCountryName,
                                   userId=wishes.userId,countryId=wishes.countryId, 
                                   totalCasesReported =country.totalCasesReported,
                                   totalActiveCases=country.totalActiveCases,
                                   totalDeaths=country.totalDeaths,
                                   totalCuredCases= country.totalCuredCases
                               }).ToList();
                    return resDTO;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception) { throw; }
        }

        public WishList DeleteWishList(string countryId,string userId)
        {
            try
            {
                WishList wishList = _dbContext.usersWishlist.SingleOrDefault(x => x.countryId == countryId && x.userId== userId);
                Users user = _dbContext.users.Find(wishList.userId);
                if (wishList != null && user != null)
                {
                    _dbContext.usersWishlist.Remove(wishList);
                    _dbContext.SaveChanges();
                }
                return null;
            }
            catch (Exception) { throw; }
        }

        public bool GetWishListItemStatus(string countryId,string userId)
        {
            try
            {
                WishList item=_dbContext.usersWishlist.SingleOrDefault(x=>x.countryId == countryId && x.userId==userId);
                if(item != null)
                {
                    return true;
                }
                return false;
            }
            catch(Exception) { throw; }
        }
    }
}

