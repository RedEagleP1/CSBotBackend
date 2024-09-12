var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "P1_Api", Version = "v1" });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
