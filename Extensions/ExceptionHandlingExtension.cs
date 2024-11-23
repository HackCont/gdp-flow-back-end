using GdpFlow.API.Middlewares;

namespace GdpFlow.API.Extensions;

public static class ExceptionHandlingExtension
{
	public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder) => builder.UseMiddleware<ExceptionHandlingMiddleware>();
}
