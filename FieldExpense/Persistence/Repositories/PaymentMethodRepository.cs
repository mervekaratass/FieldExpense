using Application.Repositories;
using Core.Persistence;
using Domain.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class PaymentMethodRepository : EfRepositoryBase<PaymentMethod, int, BaseDbContext>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(BaseDbContext context) : base(context)
        {
        }

    }
    
}
