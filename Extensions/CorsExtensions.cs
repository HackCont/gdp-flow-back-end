using GdpFlow.API.Models.Settings;

namespace GdpFlow.API.Extensions;

public static class CorsExtensions
{
	public static IServiceCollection AddCorsSetup(this IServiceCollection services, IConfiguration configuration)
	{
		var corsSettings = configuration.GetSection("Cors").Get<CorsSettings>() ??
			throw new ArgumentNullException(nameof(configuration), "Cors settings not found in configurations");

		services.AddCors(options =>
		{
			options.AddPolicy("default", policy =>
			{
				//policy
				//	.WithOrigins(corsSettings?.AllowedOrigins ?? Array.Empty<string>())
				//	.AllowAnyMethod()
				//	.AllowAnyHeader()
				//	.AllowCredentials();
				policy
					.SetIsOriginAllowed(_ => true)
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials();
			});
		});
		return services;
	}
}
