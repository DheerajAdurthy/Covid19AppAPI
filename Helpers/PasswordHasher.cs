using System.Security.Cryptography;

namespace Covid19ProjectAPI.Helpers
{
    public class PasswordHasher
    {
        private static readonly RNGCryptoServiceProvider rng=new RNGCryptoServiceProvider();
        private static readonly int SaltSize = 16;
        private static readonly int HashSize = 20;
        private static readonly int Iterations = 1000;

        public static string hashPassword(string password)
        {
            if (password == null)
            {
                return "";
            }
            else
            {
                byte[] salt;
                rng.GetBytes(salt=new byte[SaltSize]);     //fills salt array with random generated cryptographic bytes of size SaltSize
                var key=new Rfc2898DeriveBytes(password,salt,Iterations);
                var hash = key.GetBytes(HashSize);          // assigning variable hash with hashSized byte array with Key
                var HashBytes=new byte[SaltSize+HashSize];
                Array.Copy(salt,0,HashBytes,0,SaltSize);
                Array.Copy(hash,0,HashBytes,SaltSize,HashSize);
                var base64Hash=Convert.ToBase64String(HashBytes);
                return base64Hash;
            }
        }

        public static bool VerifyPassword(string password,string base64hash)
        {
            var hashBytes=Convert.FromBase64String(base64hash);
            var salt=new byte[SaltSize];
            Array.Copy(hashBytes,0,salt,0,SaltSize);
            var key = new Rfc2898DeriveBytes(password,salt,Iterations);
            var hash=key.GetBytes(HashSize);
            for(int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
