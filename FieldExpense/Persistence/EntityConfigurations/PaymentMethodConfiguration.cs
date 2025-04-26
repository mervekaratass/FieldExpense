using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods").HasKey(pm => pm.Id);

            builder.Property(pm => pm.Name).IsRequired().HasMaxLength(100);
            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

            builder.HasMany(pm => pm.ExpenseRequests)
              .WithOne(er => er.PaymentMethod)
              .HasForeignKey(er => er.PaymentMethodId)
              .OnDelete(DeleteBehavior.Restrict);

            /* bir PaymentMethod silinmeye çalışıldığında o metoda bağlı ExpenseRequest kayıtları silinmez. 
                Yani, metod silinemeden önce, bu metoda bağlı masraf taleplerinin(expense request) başka
                bir metoda taşınması veya ilişkisinin kesilmesi gerekir. */
        }
    }

}
