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
        

        
    }
}
