using FluentValidation.Results;
using System.Net;

namespace BaseApi.Application.Exceptions
{
    public sealed class ApiValidationException : ApiException
    {
        public override object Errors { get; }

        public ApiValidationException(IEnumerable<ValidationFailure> failures)
        : base("Validation failed.", HttpStatusCode.BadRequest)
        {
            Errors = failures
                .GroupBy(x => x.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.ErrorMessage));
        }
    }
}
