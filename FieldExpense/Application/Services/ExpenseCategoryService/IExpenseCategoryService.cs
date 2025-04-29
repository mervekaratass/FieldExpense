using Domain.Entities;

namespace Application.Services.ExpenseCategoryService
{
    public interface IExpenseCategoryService
    {
        Task<ExpenseCategory?> GetByIdAsync(int id);
    
}
}
