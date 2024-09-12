using P1_Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

RegisterServices(services);

services.AddInfrastructureServices(builder.Configuration);
services.RunMigrations();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "P1_Api v1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});
app.MapControllers();

app.Run();


static void RegisterServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = "P1_Api", Version = "v1" });
    });
}