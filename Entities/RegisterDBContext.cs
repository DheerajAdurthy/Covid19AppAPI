using Microsoft.EntityFrameworkCore;
namespace Covid19ProjectAPI.Entities
{
    public class RegisterDBContext:DbContext
    {
        public RegisterDBContext(DbContextOptions<RegisterDBContext> options) : base(options) { }
        public DbSet<RegisterUser> registerUsers { get; set; }

        public DbSet<Countries> countries { get; set; }

        public DbSet<Cities> cities { get; set; }

        public DbSet<CasesInCities> casesInCities { get; set;}

        public DbSet<Users> users { get; set; }

        public DbSet<WishList> usersWishlist { get; set; }

        public DbSet<LoginUserWishList> loginUsers { get; set; }

    }
}
