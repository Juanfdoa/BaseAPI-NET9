using System.Net;

namespace BaseApi.Application.Exceptions
{
    public sealed class BadRequestException : ApiException
    {
        public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
