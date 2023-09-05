using Covid19ProjectAPI.Entities;
using Covid19ProjectAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Covid19ProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionStr = builder.Configuration.GetConnectionString("sqlConnectionStr");
            
            // Add services to the container.

            builder.Services.AddControllers();
            //adding Connection String
            builder.Services.AddDbContext<RegisterDBContext>(options => options.UseSqlServer(connectionStr));
            // request Transient Service
            builder.Services.AddTransient<ICountriesInterface,CountriesService>();
            builder.Services.AddTransient<IRegisterService, RegisterService>();
            builder.Services.AddTransient<ILoginInterface, LoginService>();
            builder.Services.AddTransient<IwishListInterface, WishListService>();
            builder.Services.AddScoped<IEmailSender,EmailService>();
            //Configuring 
            builder.Services.AddCors(c =>c.AddPolicy("AllowOrigin",options=>options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
           //configuring connection String
            // Authentication Service
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Authentication pipeline

            //Configuring middleware for cors

            app.UseCors("AllowOrigin");

            app.UseAuthentication();


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}