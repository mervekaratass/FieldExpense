using Core.Persistence;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod, int>, IAsyncRepository<PaymentMethod, int>
    {

    }
}
