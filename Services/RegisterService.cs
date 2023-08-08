using Covid19ProjectAPI.Entities;

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
                    this.registerDBContext.registerUsers.Add(user);
                    this.registerDBContext.SaveChanges();
                    return user;
                }
            }
            catch (Exception) { throw; }
        }
    }
}
