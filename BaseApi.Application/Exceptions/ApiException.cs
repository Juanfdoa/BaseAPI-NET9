using System.Net;

namespace BaseApi.Application.Exceptions
{
    public abstract class ApiException : Exception
    {
        protected ApiException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }

        public virtual object? Errors => null;
    }
}
