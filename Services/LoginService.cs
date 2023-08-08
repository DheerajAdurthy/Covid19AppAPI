using Covid19ProjectAPI.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Covid19ProjectAPI.Services
{
    public class LoginService : ILoginInterface
    {
        IConfiguration configuration;
        private readonly RegisterDBContext registerDBContext;

        public LoginService(IConfiguration configuration,RegisterDBContext registerDBContext)
        {
            this.configuration = configuration;
            this.registerDBContext = registerDBContext;
        }

        public ResponseBody VerifyUser(LoginUser user)
        {
            try
            {
                RegisterUser newUser=this.registerDBContext.registerUsers.SingleOrDefault(x=>x.userName==user.userName && x.password==user.password);
                if(newUser != null)
                {
                    string Jwt = getToken(newUser);
                    ResponseBody response = new ResponseBody() { userId="user"+newUser.registerId,userName = newUser.userName, token = Jwt,role = newUser.role };
                    Users loggedInUser = new Users() {  userId=response.userId,userName=response.userName,token=response.token,role=newUser.role };
                    LoginUserWishList userLogin = new LoginUserWishList() 
                    {
                      userId=loggedInUser.userId,
                      userName=loggedInUser.userName,
                    };
                    if (registerDBContext.users.Find(loggedInUser.userId) == null)
                    {
                        registerDBContext.users.Add(loggedInUser);
                        registerDBContext.loginUsers.Add(userLogin);
                        registerDBContext.SaveChanges();
                    }
                    return response;
                }
                return null;
            }
            catch (Exception) { throw; }
        }


        private string getToken(RegisterUser? user)
        {
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var signingCredentials = new SigningCredentials(        // header
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature
            );

            var subject = new ClaimsIdentity(new[]             // payload
            {
                        new Claim(ClaimTypes.Name,user.userName),
                        new Claim(ClaimTypes.Role, user.password),
                    });

            var expires = DateTime.UtcNow.AddMinutes(10);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }

        public void VerifyLogOut(string userId)
        {
            try
            {
                if (userId != null)
                {
                    Users loggedInUser =registerDBContext.users.Find(userId);
                    if (loggedInUser != null)
                    {
                        registerDBContext.users.Remove(loggedInUser);
                        registerDBContext.SaveChanges();
                    }
                }
            }
            catch(Exception) { throw; }
        }
    }
}
