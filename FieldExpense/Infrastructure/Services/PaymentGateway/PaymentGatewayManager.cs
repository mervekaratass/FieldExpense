using Application.Repositories;
using Application.Services.BankTransactionService;
using Application.Services.PaymentGatewayService;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Services.PaymentGateway
{
    public class PaymentGatewayManager : IPaymentGatewayService
    {
        private readonly IBankTransactionRepository _bankTransactionRepository;

        public PaymentGatewayManager(IBankTransactionRepository bankTransactionRepository)
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
