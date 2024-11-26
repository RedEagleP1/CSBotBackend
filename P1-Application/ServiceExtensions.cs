using MediatR;
using Microsoft.Extensions.DependencyInjection;
using P1_Application.Boundaries;
using P1_Core.Interfaces;
using Serilog;


namespace P1_Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MappingBehavior<,>));

            services.AddScoped<ApplicationContext>();
        }
    }

}