using GdpFlow.API.Models.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GdpFlow.API.Extensions;

public static class AuthExtensions
{
	public static IServiceCollection AddAuthenticationSetup(this IServiceCollection services, IConfiguration configuration)
	{
		var keycloakSettings = configuration.GetSection("keycloak").Get<KeycloakSettings>() ??
			throw new ArgumentNullException(nameof(configuration), "Keycloak settings not found in configurations");

		ValidateKeycloakSettings(keycloakSettings);

		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(options =>
		{
			options.Authority = keycloakSettings.Authority;
			options.Audience = keycloakSettings.Audience;
			options.RequireHttpsMetadata = keycloakSettings.RequireHttpsMetadata;
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = keycloakSettings.Authority,
				ValidateAudience = true,
				ValidAudience = keycloakSettings.Audience,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero,
				ValidateIssuerSigningKey = true
			};
		});

		return services;
	}

	private static void ValidateKeycloakSettings(KeycloakSettings settings)
	{
		if (string.IsNullOrWhiteSpace(settings.Authority))
		{
			throw new ArgumentException("Authority is required", nameof(settings));
		}

		if (string.IsNullOrWhiteSpace(settings.Audience))
		{
			throw new ArgumentException("Audience is required", nameof(settings));
		}
	}
}
