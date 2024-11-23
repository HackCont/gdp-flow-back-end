using FluentValidation;

namespace GdpFlow.API.Models.DTOs.User.Register;

public class RegisterValidator : AbstractValidator<RegisterDTO>
{
	public RegisterValidator()
	{

		RuleFor(x => x.Email)
		.NotEmpty().WithMessage("Email is required.")
		.EmailAddress().WithMessage("Email is invalid");

		RuleFor(x => x.FirstName)
			.NotEmpty().WithMessage("First name is required.")
			.MaximumLength(20).WithMessage("First name must be a maximum of 20 characters.");

		RuleFor(x => x.LastName)
			.NotEmpty().WithMessage("Last name is required.")
			.MaximumLength(50).WithMessage("Last name must be a maximum of 20 characters.");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(5).WithMessage("Password must be at least 5 characters long.")
			.MaximumLength(20).WithMessage("Password must not exceed to 20 characters.");
	}
}