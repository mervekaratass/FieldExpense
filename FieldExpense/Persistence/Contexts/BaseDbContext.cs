using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Domain.Entities;
using Core.Persistence;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ExpenseRequest> ExpenseRequests { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
       : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public override int SaveChanges()
        {
            ApplyEntityTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            ApplyEntityTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void ApplyEntityTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Entity<int> &&
                       (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

            foreach (var entry in entries)
            {
                var entity = (Entity<int>)entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entity.UpdatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entity.DeletedDate = DateTime.UtcNow;
                        entry.State = EntityState.Modified; // Soft delete
                        break;
                }
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
