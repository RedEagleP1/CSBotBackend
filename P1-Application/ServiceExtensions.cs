using Microsoft.Extensions.DependencyInjection;
using P1_Application.Boundaries;

namespace P1_Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ApplicationContext>();
        }
    }

}