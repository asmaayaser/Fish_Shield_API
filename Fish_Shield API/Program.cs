
using CORE.Models;
using Fish_Shield_API.ErrorHandlerMiddleWare;
using Fish_Shield_API.ServiceExtensions;
using Microsoft.AspNetCore.Identity;
using NLog;
using Presentation;
using Repositories.Context;

namespace Fish_Shield_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/Nlog.config"));
            builder.Services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters()
                .AddApplicationPart(typeof(AssemblyReference).Assembly);
            builder.Services.AddAutoMapper(typeof(Program));
              
               
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adding Custom Services
            builder.Services.ConfigureCORS();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureLogging();
            builder.Services.ConfigureDBContext(builder.Configuration);
            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();

           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.ConfigureExceptionHandler();
               // app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                //Glogal Middleware Can Catch All Exceptions Throwed
                app.ConfigureExceptionHandler();
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CORSPolicy");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
