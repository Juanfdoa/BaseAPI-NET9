using System.Net;

namespace BaseApi.Application.Exceptions
{
    public sealed class ConflictException : ApiException
    {
        public ConflictException(string message) : base(message, HttpStatusCode.Conflict)
        {
        }
    }
}
