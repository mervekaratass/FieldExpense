using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Phone).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.IBAN).IsRequired().HasMaxLength(34);
            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

            builder.HasOne(u => u.Role)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            /* Eğer "Admin" rolü silinirse, bu rolü taşıyan kullanıcıların rolü kaybolur ancak 
             * kullanıcılar silinmez; yani, kullanıcılar hala sistemde var olur ancak bir role atanmazlar. 
             * Böylece silme işleminde veri kaybı yaşanmaz ve sistemin genel bütünlüğü korunmuş olur.*/


            builder.HasData(_seeds);


        }


        private static readonly byte[] _passwordHash = new byte[]
        {
            125, 77, 57, 201, 162, 177, 220, 32, 208, 50, 123, 66, 137, 47, 71, 12,
            169, 3, 233, 9, 53, 89, 38, 114, 104, 121, 190, 138, 116, 253, 226, 243,
            206, 152, 98, 122, 249, 131, 135, 43, 61, 122, 222, 155, 239, 189, 173, 183,
            63, 132, 218, 29, 36, 197, 214, 89, 240, 43, 89, 27, 109, 62, 80, 117
        };

        private static readonly byte[] _passwordSalt = new byte[]
         {
            202, 177, 188, 92, 106, 56, 116, 83, 160, 44, 8, 42, 73, 57, 232, 55,
            41, 168, 189, 157, 87, 208, 21, 137, 89, 244, 12, 91, 154, 203, 110, 65,
            130, 104, 137, 120, 32, 192, 31, 132, 154, 26, 19, 95, 144, 33, 50, 97,
            109, 118, 92, 61, 149, 45, 102, 213, 232, 1, 121, 215, 137, 67, 157, 18,
            171, 105, 239, 222, 228, 243, 239, 38, 133, 228, 18, 195, 153, 98, 114, 6,
            61, 210, 163, 45, 230, 188, 38, 112, 107, 100, 55, 77, 26, 243, 88, 57,
            76, 136, 189, 47, 158, 125, 62, 191, 96, 215, 183, 200, 142, 200, 40, 76,
            178, 47, 132, 54, 52, 188, 199, 44
         };


        private IEnumerable<User> _seeds
        {
            get
            {

                User adminUser =
                    new()
                    {
                        Id = 1,
                        FirstName = "Ayşe",
                        LastName = "Karamanlı",
                        Email = "ayse@gmail.com",
                        Phone = "1234567890",
                        IBAN = "TR480010200438320021981234",
                        RoleId = 1,
                        PasswordHash = _passwordHash,
                        PasswordSalt = _passwordSalt
                    };

                User adminlUser2 = new()
                {
                    Id = 2,
                    FirstName = "Murat",
                    LastName = "Karamanlı",
                    Email = "murat@gmail.com",
                    Phone = "0987654321",
                    IBAN = "TR330006100519786457841234",
                    RoleId = 1,
                    PasswordHash = _passwordHash,
                    PasswordSalt = _passwordSalt
                };
                yield return adminUser;
                yield return adminlUser2;
            }
        }

    
    }
}
