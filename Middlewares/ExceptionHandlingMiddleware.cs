using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GdpFlow.API.Middlewares;

public class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;

	public ExceptionHandlingMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);

		}
		catch (Exception ex)
		{

			await HandleExceptionAsync(context, ex);
		}
	}

	private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		var statusCode = StatusCodes.Status500InternalServerError;
		var factory = context.RequestServices.GetRequiredService<ProblemDetailsFactory>();
		var problemDetails = factory.CreateProblemDetails(
			context,
			title: "Internal Server Error",
			detail: exception.Message,
			statusCode: statusCode
		);

		await Results.Problem(problemDetails).ExecuteAsync(context);
	}
}
