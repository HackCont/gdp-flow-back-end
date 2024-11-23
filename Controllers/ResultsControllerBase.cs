using FluentResults;
using GdpFlow.API.Models.Results;
using Microsoft.AspNetCore.Mvc;

namespace GdpFlow.API.Controllers;
public class ResultsControllerBase : ControllerBase
{
	protected ActionResult CustomResult(Result result)
	{
		if (result.IsSuccess)
		{
			var success = result.Successes.OfType<CustomSuccess>().FirstOrDefault();
			if (success != null)
			{
				return StatusCode(success.StatusCode, new { message = success.Message });
			}
			return Ok();
		}

		var error = result.Errors.OfType<CustomError>().FirstOrDefault();
		if (error != null)
		{
			return Problem(detail: error.Message, statusCode: error.StatusCode);
		}

		throw new Exception("Internal server Error.");
	}

	protected ActionResult CustomResult<T>(IResult<T> result)
	{
		if (result.IsSuccess)
		{
			var success = result.Successes.OfType<CustomSuccess>().FirstOrDefault();
			if (success != null)
			{
				return StatusCode(success.StatusCode, result.Value);
			}
			return Ok(result.Value);
		}

		var error = result.Errors.OfType<CustomError>().FirstOrDefault();
		if (error != null)
		{
			return Problem(detail: error.Message, statusCode: error.StatusCode);
		}

		throw new Exception("Internal server Error.");
	}
}
