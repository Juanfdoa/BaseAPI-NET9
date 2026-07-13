using System.Text.Json.Serialization;

namespace BaseApi.Application.Wrapper
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; } = true;

        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; } = new List<string>();

        [JsonPropertyName("item_errors")]
        public List<BulkErrorResponse> ItemErrors { get; set; } = new List<BulkErrorResponse>();

        [JsonPropertyName("pagination")]
        public PaginationResponse? Pagination { get; set; }
    }
}
