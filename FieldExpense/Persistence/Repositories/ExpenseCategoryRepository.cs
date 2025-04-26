using Application.Repositories;
using Core.Persistence;
using Domain.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class ExpenseCategoryRepository : EfRepositoryBase<ExpenseCategory, int, BaseDbContext>, IExpenseCategoryRepository
    {
        public ExpenseCategoryRepository(BaseDbContext context) : base(context)
        {
        }

    }
}
