using Microsoft.Extensions.Configuration;

namespace P1_Application.Util
{
    public static class ServiceExtension
    {
        public static IServiceProvider AddApplicationServies(this IServiceProvider service, IConfiguration configuration)
        {
            return service;
        }
    }
    
}