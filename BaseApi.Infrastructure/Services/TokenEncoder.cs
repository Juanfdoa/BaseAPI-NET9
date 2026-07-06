using BaseApi.Application.Interfaces.Providers;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace BaseApi.Infrastructure.Services
{
    public class TokenEncoder : ITokenEncoder
    {
        public string Decode(string value)
        {
            return Encoding.UTF8.GetString(
                WebEncoders.Base64UrlDecode(value));
        }

        public string Encode(string value)
        {
            return WebEncoders.Base64UrlEncode(
                Encoding.UTF8.GetBytes(value));
        }
    }
}
