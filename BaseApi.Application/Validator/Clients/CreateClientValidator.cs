using BaseApi.Application.DTOs.Clients;
using FluentValidation;

namespace BaseApi.Application.Validator.Clients
{
    public class CreateClientValidator : AbstractValidator<ClientRequestDto>
    {
        public CreateClientValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("The code is required.")
                .MaximumLength(20);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The name is required.")
                .MaximumLength(150);

            RuleFor(x => x.LegalName)
                .NotEmpty().WithMessage("The legal name is required.")
                .MaximumLength(200);

            RuleFor(x => x.TaxId)
                .NotEmpty().WithMessage("The tax ID is required.")
                .MaximumLength(50);

            RuleFor(x => x.ClientTypeId)
                .NotEqual(Guid.Empty)
                .WithMessage("The client type is required.");

            RuleFor(x => x.ContactName)
                .NotEmpty().WithMessage("The contact name is required.")
                .MaximumLength(150);

            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("The contact email is required.")
                .EmailAddress().WithMessage("The contact email is not valid.")
                .MaximumLength(150);

            RuleFor(x => x.ContactPhone)
                .NotEmpty().WithMessage("The contact phone is required.")
                .MaximumLength(20);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("The email is required.")
                .EmailAddress().WithMessage("The email is not valid.")
                .MaximumLength(150);

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("The phone is required.")
                .MaximumLength(20);

            RuleFor(x => x.Website)
                .MaximumLength(200)
                .Must(uri => string.IsNullOrWhiteSpace(uri) ||
                             Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("The website must be a valid URL.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("The address is required.")
                .MaximumLength(250);

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("The city is required.")
                .MaximumLength(100);

            RuleFor(x => x.Region)
                .MaximumLength(100);

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("The country is required.")
                .MaximumLength(100);

            RuleFor(x => x.PostalCode)
                .MaximumLength(20);

            RuleFor(x => x.Notes)
                .MaximumLength(1000);
        }
    }
}
