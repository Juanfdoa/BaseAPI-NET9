using BaseApi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.Domain.Entities
{
    [Table("client_types", Schema = "public")]
    public class ClientTypeTable : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; } = default!;

        [Column("description")]
        public string? Description { get; set; }
    }
}
