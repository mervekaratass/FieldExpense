using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;


namespace Application.Features.PaymentMethods.Commands.Delete
{
    public class DeletePaymentMethodCommand: IRequest<DeletePaymentMethodResponse>
    {
        public int Id { get; set; }

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
            PaymentMethod? paymentMethod = await _paymentMethodRepository.GetAsync(ec => ec.Id == request.Id);
            if (paymentMethod is null)
                throw new BusinessException("Silinmek istenen ödeme yöntemi bulunamadı.");

            await _paymentMethodRepository.DeleteAsync(paymentMethod);

            DeletePaymentMethodResponse response = _mapper.Map<DeletePaymentMethodResponse>(paymentMethod);
            return response;
        }
    }
   }
}

