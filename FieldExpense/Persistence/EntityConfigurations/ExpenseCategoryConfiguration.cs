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
    public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
    {
        public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
        {

            builder.ToTable("ExpenseCategories").HasKey(ec => ec.Id);
            builder.Property(ec => ec.Name).IsRequired().HasMaxLength(100);
            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);


            builder.HasMany(ec => ec.ExpenseRequests)
               .WithOne(er => er.ExpenseCategory)
               .HasForeignKey(er => er.ExpenseCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

            /*bir ExpenseCategory silinmeye çalışıldığında o kategoriye bağlı ExpenseRequest kayıtları silinmez.
            Yani, kategori silinemeden önce, bu kategoriye bağlı masraf taleplerinin(expense request) başka bir 
            kategoriye taşınması veya ilişkisinin kesilmesi gerekir. */
        }
    }

}
