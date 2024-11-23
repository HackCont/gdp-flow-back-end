using FluentValidation;
using GdpFlow.API.Data;
using GdpFlow.API.Extensions;
using GdpFlow.API.Models.DTOs.User.Register;
using GdpFlow.API.Models.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerSetup();

builder.Services.AddAuthenticationSetup(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining<RegisterValidator>();

builder.Services.AddHttpClient();

builder.Services.Configure<KeycloakSettings>(builder.Configuration.GetSection("Keycloak"));

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

var app = builder.Build();

app.UseGlobalExceptionHandler();

//if (app.Environment.IsDevelopment())
//{
	app.UseSwagger();
	app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsProduction())
{
	app.UseMigrateDatabase();
}

app.Run();
