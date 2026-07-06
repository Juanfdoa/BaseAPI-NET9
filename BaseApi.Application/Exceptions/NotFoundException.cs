using System.Net;

namespace BaseApi.Application.Exceptions
{
    public sealed class NotFoundException : ApiException
    {
        public NotFoundException(string message): base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
