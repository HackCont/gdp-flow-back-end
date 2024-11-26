using Microsoft.OpenApi.Models;

namespace GdpFlow.API.Extensions;

public static class SwaggerExtensions
{
	public static IServiceCollection AddSwaggerSetup(this IServiceCollection services)
	{
		services.AddSwaggerGen(config =>
		{
			config.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "GDP Flow",
				Version = "v1",
				Description = "GDP Flow API Documentation"
			});

			config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				Description = "Enter token Jwt in the Authorization header.",
				Name = "Authorization",
				In = ParameterLocation.Header,
				Type = SecuritySchemeType.Http,
				Scheme = "bearer",
				BearerFormat = "JWT"
			});

			config.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					},
					Array.Empty<string>()
				}
			});
		});

		return services;
	}
}
