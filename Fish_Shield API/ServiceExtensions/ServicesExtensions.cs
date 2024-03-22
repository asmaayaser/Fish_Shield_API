using CORE.Contracts;
using CORE.LoggerService;
using CORE.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Repositories.Context;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using Services.EmailService;
using System.Text;

namespace Fish_Shield_API.ServiceExtensions
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Configure CORS Policy FOR Resource Sharing
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCORS(this IServiceCollection services)
        => services.AddCors(options =>
        {
            options.AddPolicy("CORSPolicy", pol =>
            {
                pol.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                
            });
        });

        /// <summary>
        /// Configuration for IIS we are need that when hosting
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
            => services.Configure<IISOptions>(options =>
            {

            });

        /// <summary>
        /// Configure Single Object TO used for Logging
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLogging(this IServiceCollection services)
            => services.AddSingleton<ILoggerManager,LoggerManager>();


        public static void ConfigureDBContext(this IServiceCollection services,IConfiguration configuration)
            => services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"), options =>
                {
                    options.MigrationsAssembly("Fish_Shield API");
                });
               
            });



        public static void ConfigureIdentity(this IServiceCollection services)
            => services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail=true;
            }).AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();



        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();


        public static void ConfigureServiceManager(this IServiceCollection services)
            =>services.AddScoped<IServiceManager,ServiceManager>();



        public static void ConfigureJWT(this IServiceCollection services,IConfiguration configuration)
        {
            var jwtSetting = configuration.GetSection("JwtSettings");
            //var secretKey = Environment.GetEnvironmentVariable("SecretKey");
            var secretKey = jwtSetting["secretKey"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSetting["validIssuer"],
                    ValidAudience = jwtSetting["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                };
            });
        }

        public static void ConfigureEmailSendingToResetPassword(this IServiceCollection services,IConfiguration configuration)
        {
            var emailConfig=configuration.GetSection("EmailConfig").Get<EmailConfig>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();  
        }
    }
}
