using FluentValidation;

using PlannerApp.Shared.Contracts.V2.Requests.Authentication;

namespace PlannerApp.Shared.Validators
{
  public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
  {
    public RegisterRequestValidator()
    {
      RuleFor(p => p.Email)
        .NotEmpty().WithMessage("Email is required")
        .EmailAddress().WithMessage("Email is not a valid email address");

      RuleFor(p => p.FirstName)
        .NotEmpty().WithMessage("First name is required")
        .MaximumLength(25).WithMessage("First name must be less than 25 characters");

      RuleFor(p => p.LastName)
        .NotEmpty().WithMessage("Last name is required")
        .MaximumLength(25).WithMessage("Last name must be less than 25 characters");

      RuleFor(p => p.Password)
        .NotEmpty().WithMessage("Password is required")
        .MinimumLength(5).WithMessage("Password must be at least 5 characters");

      RuleFor(p => p.ConfirmPassword)
        .Equal(p => p.Password)
        .WithMessage("Confirm password doesn't match with the password");
    }
  }
}
