using BaseApi.Application.DTOs.Auth;
using FluentValidation;

namespace BaseApi.Application.Validator.Auth
{
    public class CreateUserValidator : AbstractValidator<UserRequestDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(150);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]")
                    .WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]")
                    .WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]")
                    .WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]")
                    .WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.ConfirmPassword)
               .NotEmpty()
               .Equal(x => x.Password)
               .WithMessage("Passwords do not match.");
        }
    }
}
