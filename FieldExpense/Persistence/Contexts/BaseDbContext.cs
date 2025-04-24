
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Core.Entities;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Entities.Role> Roles { get; set; }
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
            IEnumerable<EntityEntry<Entity>> entries = ChangeTracker
                .Entries<Entity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            foreach (EntityEntry<Entity> entry in entries)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.UpdatedDate = DateTime.UtcNow,
                    EntityState.Deleted => entry.Entity.DeletedDate = DateTime.UtcNow
                };
            }
            return base.SaveChanges();
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
