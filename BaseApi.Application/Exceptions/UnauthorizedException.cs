using System.Net;

namespace BaseApi.Application.Exceptions
{
    public sealed class UnauthorizedException : ApiException
    {
        public UnauthorizedException(string message) : base(message, HttpStatusCode.Unauthorized)
        {
        }
    }
}
