using System.Net;

namespace BaseApi.Application.Exceptions
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(string message) : base(message, HttpStatusCode.Forbidden)
        {
        }
    }
}
