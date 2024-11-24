using GdpFlow.API.Data;
using GdpFlow.API.Extensions;
using GdpFlow.API.Models.Settings;
using GdpFlow.API.Repositories;
using GdpFlow.API.Repositories.UserRepository;
using GdpFlow.API.Services.Login;
using GdpFlow.API.Services.Register;
using GdpFlow.API.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerSetup();

builder.Services.AddAuthenticationSetup(builder.Configuration);

builder.Services.AddCorsSetup(builder.Configuration);

builder.Services.AddHttpClient();

builder.Services.Configure<KeycloakSettings>(builder.Configuration.GetSection("Keycloak"));

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();

app.UseGlobalExceptionHandler();

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors("default");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//if (app.Environment.IsProduction())
//{
//	app.UseMigrateDatabase();
//}

app.Run();
