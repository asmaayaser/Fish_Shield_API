using CORE;
using CORE.Contracts;
using CORE.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Fish_Shield_API.ErrorHandlerMiddleWare
{
    public static class ExceptionHandlerExtensions
    {

        /// <summary>
        /// Global Middleware to handle Exceptions in our Api 
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureExceptionHandler(this WebApplication app)
            => app.HandleExceptionByLoggingAndReturnSuitableResponse(app.Services.GetRequiredService<ILoggerManager>());


       public static void HandleExceptionByLoggingAndReturnSuitableResponse(this WebApplication app,ILoggerManager logger )
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async Context =>
                {
                    Context.Response.ContentType = "application/json";

                    var ErrorOccurred=Context.Features.Get<IExceptionHandlerFeature>();

                    if (ErrorOccurred != null)
                    {
                        logger.LogError($"Error Occurred At {ErrorOccurred.Error}");
                        Context.Response.StatusCode = ErrorOccurred.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException=> StatusCodes.Status400BadRequest,
                            UnauthorizedAccessException=> StatusCodes.Status401Unauthorized,
                            _                  => StatusCodes.Status500InternalServerError
                        };

                      
                       await Context.Response.WriteAsJsonAsync(new ErrorDetails(Context.Response.StatusCode, ErrorOccurred.Error.Message));
                    }
                });
            });

        }
    }
}
