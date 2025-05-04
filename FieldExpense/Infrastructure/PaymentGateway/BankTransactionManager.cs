

using Application.Repositories;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services.BankTransactionService
{
    public class BankTransactionManager:IBankTransactionService
    {
        private readonly IBankTransactionRepository _bankTransactionRepository;

        public BankTransactionManager(IBankTransactionRepository bankTransactionRepository)
        {
            _bankTransactionRepository = bankTransactionRepository;
        }

        public async Task<BankTransaction> CreateTransactionAsync(CreateBankTransactionModel model)
        {
            var transaction = new BankTransaction
            {
                ExpenseRequestId = model.ExpenseRequestId,
                Amount = model.Amount,
                TransactionDate = DateTime.UtcNow,
                TransactionStatus = TransactionStatus.Başarılı,
                BankReferenceCode = Guid.NewGuid().ToString("N")[..8].ToUpper()
            };

            await _bankTransactionRepository.AddAsync(transaction);
            return transaction;
        }
    }
}
