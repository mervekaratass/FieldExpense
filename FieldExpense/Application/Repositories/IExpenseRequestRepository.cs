using Core.Persistence;
using Domain.Entities;


namespace Application.Repositories
{
    public interface IExpenseRequestRepository : IRepository<ExpenseRequest, int>, IAsyncRepository<ExpenseRequest, int>
    {

    }
}
