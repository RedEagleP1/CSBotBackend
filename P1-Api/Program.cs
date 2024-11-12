using System.ComponentModel;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using P1_Api.Util;
using P1_Application.UseCases;
using P1_Application;
using P1_Core.Entities;
using P1_Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options => { 
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    
}).AddJwtBearer(options => {
    builder.Configuration.Bind("JwtSettings", options);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        //todo This is a pretend key, you should use a real one
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("skldjfksldjfjklsdh8943589jdf8943rdy43298yruiewhy32498ryrfkjhasdfjlsakdjflkasjdflkjasdflkhja"))
        // ValidateIssuer = true,
        // ValidateAudience = true,
        // ValidateLifetime = true,
        // ValidateIssuerSigningKey = true,
        // ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        // ValidAudience = builder.Configuration["JwtSettings:Audience"],
        // IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
    };
});
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssemblies(typeof(UpdateEntityUseCase<>).Assembly, typeof(BaseEntity).Assembly);
    config.RegisterGenericHandlers = true;
});

builder.Services.AddAutoMapper(typeof(Profiles));

builder.Services.AddAuthorizationBuilder();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.ToString());
    c.SwaggerDoc("v1", new() { Title = "P1_Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.RunMigrations();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "P1_Api v1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});
app.MapControllers();

app.Run();
