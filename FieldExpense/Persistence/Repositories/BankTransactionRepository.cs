using Application.Repositories;
using Core.Persistence;
using Domain.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class BankTransactionRepository : EfRepositoryBase<BankTransaction, int, BaseDbContext>, IBankTransactionRepository
    {
        public BankTransactionRepository(BaseDbContext context) : base(context)
        {
        }

    }
}
