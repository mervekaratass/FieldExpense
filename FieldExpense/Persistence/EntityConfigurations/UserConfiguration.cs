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
            //builder.HasIndex(u => u.Email).IsUnique();
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
            96, 175, 200, 232, 193, 118, 227, 65, 112, 151, 75, 103, 144, 142, 231, 63,
            27, 47, 136, 246, 11, 117, 107, 243, 181, 252, 89, 142, 251, 248, 44, 114,
            149, 123, 102, 240, 165, 29, 119, 225, 156, 88, 231, 9, 238, 227, 56, 169,
            213, 108, 172, 247, 208, 4, 150, 145, 97, 234, 237, 13, 202, 10, 87, 91,
            187, 243, 139, 204, 46, 76, 196, 43, 88, 227, 248, 17, 255, 164, 143, 80,
            131, 26, 199, 84, 247, 144, 175, 0, 164, 85, 33, 245, 99, 116, 240, 140,
            253, 179, 216, 111, 245, 196, 90, 70, 230, 196, 232, 254, 54, 195, 27, 126,
            138, 45, 30, 236, 155, 53, 82, 74, 63, 126, 194, 17, 51, 179, 185, 126
         };


        private static readonly byte[] _passwordSalt = new byte[]
            {
                94, 38, 193, 180, 158, 32, 113, 64, 80, 8, 155, 152, 202, 48, 166, 96,
                167, 187, 193, 193, 35, 141, 49, 101, 74, 68, 98, 190, 37, 223, 92, 43,
                213, 229, 144, 9, 51, 222, 156, 69, 93, 4, 42, 88, 197, 221, 85, 209,
                57, 207, 154, 139, 59, 171, 199, 99, 130, 158, 163, 117, 197, 83, 127, 135
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
