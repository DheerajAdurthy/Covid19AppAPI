using Covid19ProjectAPI.Entities;
using Covid19ProjectAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid19ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishController : ControllerBase
    {
        private readonly IwishListInterface wishList;

        public WishController(IwishListInterface wishList)
        {
            this.wishList = wishList;
        }

        [HttpPost, Route("AddWishList")]
        public IActionResult AddWishList(List<WishListDTO> wishlists)
        {
            try
            {
                if (wishlists.Count == 0)
                {
                    return StatusCode(400, "Empty Lists Given");
                }
                foreach (var wish in wishlists)
                {
                    WishList userWishlist = new WishList()
                    {
                        wishListCountryName = wish.wishListCountryName,
                        userId = wish.userId,
                        countryId = wish.countryId,
                    };
                    wishList.AddWishList(userWishlist);
                }
                return StatusCode(200, new JsonResult("WishList Item added Successfully"));
            }
            catch (Exception) { throw; }
        }

        [HttpGet, Route("GetUserWishLists/{Id}")]

        public IActionResult GetUserWishLists(string Id)
        {
            try
            {
                if (Id == null)
                {
                    return BadRequest();
                }
                else
                {
                    List<WishListResponseDTO> userwishlist = wishList.GetUserWishlists(Id);
                    return StatusCode(200, userwishlist);
                }
            }
            catch (Exception) { throw; }
        }

        [HttpDelete, Route("DeleteWishListById/{countryId}/{userId}")]

        public IActionResult DeleteWishListById(string countryId,string userId)
        {
            try
            {
                if (countryId == null)
                {
                    return BadRequest();
                }
                else
                {
                    WishList wishlist = wishList.DeleteWishList(countryId,userId);
                    return StatusCode(200, new JsonResult("WishList Item got removed Successfully"));
                }
            }
            catch (Exception) { throw; }
        }

        [HttpGet,Route("GetWishListItemStatus/{countryId}/{userId}")]

        public IActionResult GetWishListItemStatus(string countryId,string userId)
        {
            try
            {
                if (countryId != null && userId !=null)
                {
                    bool status= wishList.GetWishListItemStatus(countryId, userId);
                    if(status)
                    {
                        return StatusCode(200, new JsonResult(countryId));
                    }
                    else
                    {
                        return StatusCode(200, null);
                    }
                }
                return StatusCode(400, "Invalid WishList Item");
            }
            catch(Exception ex) { throw; }
        }
        
    }
}
