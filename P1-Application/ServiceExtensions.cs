using Microsoft.Extensions.DependencyInjection;
using P1_Application.Boundaries;
using Serilog;


namespace P1_Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ApplicationContext>();

            return;
            // Setup the logger.
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("../Logs/P1-Application.log").
                CreateLogger();

            // Register the logger as a service.
            services.AddSingleton<ILogger>(logger);
        }
    }

}