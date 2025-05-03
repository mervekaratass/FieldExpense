

using Domain.Entities;

namespace Application.Services.BankTransactionService
{
    public interface IBankTransactionService
    {
        //ödeme simülasyonu
        Task<BankTransaction> CreateTransactionAsync(CreateBankTransactionModel model);
    }
}
