

using Domain.Entities;

namespace Application.Services.PaymentMethodService
{
    public interface IPaymentMethodService
    {
        Task<PaymentMethod?> GetByIdAsync(int id);
    }
}
