using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles").HasKey(r => r.Id);

            builder.Property(r => r.Name).IsRequired().HasMaxLength(50);
            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
            builder.HasData(
               new Role { Id = 1, Name = "Admin" },
               new Role { Id = 2, Name = "Personel" }
           );

        }
    }
 }
