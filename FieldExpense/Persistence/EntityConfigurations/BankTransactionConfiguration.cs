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
    public class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
    {
        public void Configure(EntityTypeBuilder<BankTransaction> builder)
        {
            builder.ToTable("BankTransactions").HasKey(x => x.Id);

            builder.Property(bt => bt.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(bt => bt.TransactionDate).IsRequired();
            builder.Property(bt => bt.TransactionStatus).IsRequired();
            builder.Property(bt => bt.BankReferenceCode).HasMaxLength(100).IsRequired();
            builder.HasIndex(bt => bt.BankReferenceCode).IsUnique();
            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);


            builder.HasOne(bt => bt.ExpenseRequest)
                .WithOne(er => er.BankTransaction)
                .HasForeignKey<BankTransaction>(bt => bt.ExpenseRequestId)
                .OnDelete(DeleteBehavior.Restrict); // Silme kısıtlaması: ExpenseRequest silindiğinde BankTransaction silinmez


        }
    }

}
