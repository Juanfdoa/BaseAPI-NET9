using BaseApi.Application.DTOs.Auth;
using FluentValidation;

namespace BaseApi.Application.Validator.Auth
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordRequestDto>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Token)
                .NotEmpty();

            RuleFor(x => x.Password)
                .MinimumLength(8);

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password);
        }
    }
}
