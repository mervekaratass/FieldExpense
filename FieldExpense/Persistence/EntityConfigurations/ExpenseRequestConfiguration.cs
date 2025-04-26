using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityConfigurations
{
    public class ExpenseRequestConfiguration : IEntityTypeConfiguration<ExpenseRequest>
    {
        public void Configure(EntityTypeBuilder<ExpenseRequest> builder)
        {
            builder.ToTable("ExpenseRequests").HasKey(er => er.Id);


            builder.Property(er => er.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(er => er.Description).HasMaxLength(500);

            builder.Property(er => er.Status).IsRequired();
            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

            builder.HasOne(er => er.User)
                   .WithMany(u => u.ExpenseRequests)
                   .HasForeignKey(er => er.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            /*Bir User silinmeye çalışıldığında, o kullanıcıya ait olan masraf talepleri silinemez.

            Yani, bir kullanıcı silinmek istenirse, bu kullanıcının hala bağlı olduğu masraf talepleri varsa, silme işlemi engellenir.*/
        }
    }

}
