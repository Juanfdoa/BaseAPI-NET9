using System.Text.Json.Serialization;

namespace BaseApi.Application.Wrapper
{
    public class PaginationResponse
    {
        [JsonPropertyName("page_number")]
        public int PageNumber { get; set; }

        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }

        [JsonPropertyName("total_records")]
        public int TotalRecords { get; set; }
    }
}
