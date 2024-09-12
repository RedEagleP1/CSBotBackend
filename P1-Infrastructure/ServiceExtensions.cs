using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P1_Infrastructure.Database;

namespace P1_Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<P1DatabaseContext>(options =>
                options.UseMySql(ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));
        }

        public static void RunMigrations(this IServiceCollection services)
        {
            using var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<P1DatabaseContext>();
            dbContext.Database.Migrate();
        }
    }

}