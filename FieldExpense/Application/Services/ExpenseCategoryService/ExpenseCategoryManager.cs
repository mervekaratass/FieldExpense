
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Services.ExpenseCategoryService
{
    public class ExpenseCategoryManager : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;

        public ExpenseCategoryManager(IExpenseCategoryRepository expenseCategoryRepository)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
        }

        public async Task<ExpenseCategory?> GetByIdAsync(int id)
        {
           ExpenseCategory? expenseCategory = await _expenseCategoryRepository.GetAsync(ec=>ec.Id==id);
            if(expenseCategory is null)
                throw new BusinessException("Masraf kategorisi bulunamadı.");

            return expenseCategory;
        }
    }
}
