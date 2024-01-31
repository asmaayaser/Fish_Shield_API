using CORE.Contracts;
using CORE.LoggerService;
using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Context;
using Repositories.Contracts;
using Services;
using Services.Contracts;

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
            => services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();

        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services)
            =>services.AddScoped<IServiceManager,ServiceManager>();
    }
}
