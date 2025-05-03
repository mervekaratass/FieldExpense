using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace Application.Features.PaymentMethods.Commands.Delete
{
    public class DeletePaymentMethodCommand: IRequest<DeletePaymentMethodResponse>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] RequiredRoles => ["Admin"];
        public class DeletePaymentMethodCommandHandler : IRequestHandler<DeletePaymentMethodCommand, DeletePaymentMethodResponse>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;

        public DeletePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task<DeletePaymentMethodResponse> Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
        {
           PaymentMethod? paymentMethod = await _paymentMethodRepository.GetAsync(ec => ec.Id == request.Id,include:pm=>pm.Include(x=>x.ExpenseRequests));
            if (paymentMethod is null)
                throw new BusinessException("Silinmek istenen ödeme yöntemi bulunamadı.");

            bool hasExpenseRequests = paymentMethod.ExpenseRequests != null && paymentMethod.ExpenseRequests.Any(u => u.DeletedDate == null); // sadece aktif ödeme yöntemleri
             if (hasExpenseRequests)
            throw new BusinessException("Bu ödeme yöntemine bağlı aktif masraf talepleri bulunmaktadır. Lütfen önce bu talepleri güncelleyin veya kaldırın.");

                await _paymentMethodRepository.DeleteAsync(paymentMethod);

            DeletePaymentMethodResponse response = _mapper.Map<DeletePaymentMethodResponse>(paymentMethod);
            return response;
        }
    }
   }
}

