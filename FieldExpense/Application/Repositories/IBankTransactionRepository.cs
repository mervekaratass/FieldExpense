using Core.Persistence;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IBankTransactionRepository:IRepository<BankTransaction,int>,IAsyncRepository<BankTransaction, int>
    {

    }
}
