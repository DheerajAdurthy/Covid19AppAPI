using Covid19ProjectAPI.Entities;
using Covid19ProjectAPI.Helpers;

namespace Covid19ProjectAPI.Services
{
    public class RegisterService:IRegisterService
    {

        private readonly RegisterDBContext registerDBContext;

        public RegisterService(RegisterDBContext registerDBContext)
        {
            this.registerDBContext = registerDBContext;
            
        }

        public RegisterUser RegisterUser(RegisterUser user)
        {
            try
            {
                if (registerDBContext.registerUsers.SingleOrDefault(x => x.userName == user.userName)!=null)
                {
                    return null;
                }
                else
                {
                    user.password=PasswordHasher.hashPassword(user.password);
                    this.registerDBContext.registerUsers.Add(user);
                    this.registerDBContext.SaveChanges();
                    return user;
                }
            }
            catch (Exception) { throw; }
        }

        public RegisterUser ConfirmUser(string email)
        {
            try
            {
                RegisterUser user=registerDBContext.registerUsers.FirstOrDefault(x=>x.emailId==email);
                if (user!=null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception) { throw; }
        }
    }
}
