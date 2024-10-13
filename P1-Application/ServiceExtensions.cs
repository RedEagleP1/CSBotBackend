using Microsoft.Extensions.DependencyInjection;
using P1_Application.Boundaries;
using P1_Core.Interfaces;
using P1_Core.Services;
using Serilog;


namespace P1_Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ApplicationContext>();

            services.AddScoped(typeof(IConditionService), typeof(ConditionService));
            services.AddScoped(typeof(IResultService), typeof(ResultService));
            services.AddScoped(typeof(IRuleService), typeof(RuleService));
        }
    }

}