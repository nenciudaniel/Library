using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Library.Database.Models;

namespace Library.Database.Fluent
{
    public class UserRoleFluentConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("USERS_ROLES");

            builder.HasKey(x => new { x.Username, x.RoleId });

            builder.Property(x => x.Username).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
