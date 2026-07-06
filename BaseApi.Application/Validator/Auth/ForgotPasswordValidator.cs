using BaseApi.Application.DTOs.Auth;
using FluentValidation;

namespace BaseApi.Application.Validator.Auth
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordRequestDto>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
