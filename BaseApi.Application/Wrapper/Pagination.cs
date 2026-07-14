using System.Text.Json.Serialization;

namespace BaseApi.Application.Wrapper
{
    public class Pagination
    {
        [JsonPropertyName("page_number")]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("page_size")]
        public int PageSize { get; set; } = 10;
    }
}
