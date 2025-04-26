using Core.Persistence;
using Domain.Entities;


namespace Application.Repositories
{
    public interface IExpenseCategoryRepository : IRepository<ExpenseCategory, int>, IAsyncRepository<ExpenseCategory, int>
    {
    }
}
