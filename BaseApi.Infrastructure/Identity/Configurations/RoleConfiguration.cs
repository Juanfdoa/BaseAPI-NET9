using BaseApi.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseApi.Infrastructure.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("Roles", "auth");

            builder.Property(x => x.Description)
                .HasMaxLength(250);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);
        }
    }
}
