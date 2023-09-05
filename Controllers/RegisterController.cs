using Covid19ProjectAPI.Entities;
using Covid19ProjectAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Covid19ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService registerService;
        private readonly ILoginInterface loginService;
        public RegisterController(ILoginInterface loginService, IRegisterService registerService)
        {
            this.registerService = registerService;
            this.loginService = loginService;
        }

        [AllowAnonymous]

        [HttpPost,Route("Register")]
        public IActionResult RegisterUser([FromBody] RegisterUser user)
        {
            try
            {
                if (user == null)
                {
                    return StatusCode(401, "Empty user Credentials");
                }
                RegisterUser newuser = this.registerService.RegisterUser(user);
                if (newuser != null)
                {
                    return StatusCode(200, newuser);
                }
                else
                {
                    return StatusCode(400, "Username already Exists");
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        [HttpPost,Route("Login")]

        public IActionResult LoginUser([FromBody] LoginUser newUser)
        {
            try
            {
                if(newUser == null)
                {
                    return StatusCode(401, "Empty User Credentials");
                }
                else
                {
                    ResponseBody res=this.loginService.VerifyUser(newUser);
                    if (res != null)
                    {
                        return StatusCode(200, res);
                    }
                    else
                    {
                        return StatusCode(401, "Invalid User Credentials");
                    }
                }     
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost,Route("LogOut/{Id}")]
        public IActionResult LogOutUser(string Id)
        {
            try
            {
                loginService.VerifyLogOut(Id);
                return StatusCode(200, new JsonResult(Id));
            }
            catch (Exception) { throw; }
        }
    }
}
