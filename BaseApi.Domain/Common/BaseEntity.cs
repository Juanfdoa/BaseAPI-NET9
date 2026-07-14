using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.Domain.Common
{
    public class BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        public virtual void SoftDelete()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
            DeletedAt = DateTime.UtcNow;
        }
    }
}
