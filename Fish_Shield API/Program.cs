using Fish_Shield_API.ErrorHandlerMiddleWare;
using Fish_Shield_API.ServiceExtensions;
using Microsoft.AspNetCore.Identity;
using NLog;
using Presentation;
using Presentation.ValidationFilter;
using Services;
using Services.Contracts;

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
            builder.Services.AddSignalR();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adding Custom Services
            builder.Services.ConfigureCORS();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureLogging();
            builder.Services.ConfigureDBContext(builder.Configuration);
            builder.Services.AddAuthentication().AddGoogle(options=>
            {
                options.ClientId = builder.Configuration["External_Login_Providers:Google:Client_Id"];
                options.ClientSecret = builder.Configuration["External_Login_Providers:Google:Client_Secret"];
            });
            
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.AddScoped<ValidationFilterAttribute>();
            builder.Services.AddScoped<IIOService, IOService>();
            builder.Services.ConfigureEmailSendingToResetPassword(builder.Configuration);
           builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(1); // Set the desired expiration time
            });
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
            app.MapHub<ChatHub>("/chatHub");
            app.Run();
        }
    }
}
