using BaseApi.Domain.Common;

namespace BaseApi.Domain.Entities
{
    public class ClientType : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
