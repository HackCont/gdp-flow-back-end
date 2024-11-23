using FluentResults;

namespace GdpFlow.API.Models.Results;

public class CustomError : Error
{
	public CustomError(string message, int statusCode) : base(message) { StatusCode = statusCode; }
	public int StatusCode { get; set; }
}