using Application.Repositories;
using Core.Persistence;
using Domain.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class ExpenseRequestRepository : EfRepositoryBase<ExpenseRequest, int, BaseDbContext>, IExpenseRequestRepository
    {
        public ExpenseRequestRepository(BaseDbContext context) : base(context)
        {
        }

    }
}
