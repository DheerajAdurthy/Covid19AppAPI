using Covid19ProjectAPI.Entities;

namespace Covid19ProjectAPI.Services
{
    public interface ILoginInterface
    {
        public ResponseBody VerifyUser(LoginUser user);

        public void VerifyLogOut(string userId);

        public string getToken(RegisterUser user);

    }
}
