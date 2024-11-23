using FluentResults;

namespace GdpFlow.API.Models.Results;

public class CustomSuccess : Success
{
	public CustomSuccess(string message, int statusCode) : base(message) { StatusCode = statusCode; }
	public int StatusCode { get; set; }
}
