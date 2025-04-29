using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Services.PaymentMethodService
{
    public class PaymentMethodManager : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodManager(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<PaymentMethod?> GetByIdAsync(int id)
        {
           PaymentMethod? paymentMethod=await _paymentMethodRepository.GetAsync(pm=>pm.Id == id);
            if(paymentMethod is null)
               throw new BusinessException("Ödeme yöntemi bulunamadı.");

            return paymentMethod;
        }
    }
}
