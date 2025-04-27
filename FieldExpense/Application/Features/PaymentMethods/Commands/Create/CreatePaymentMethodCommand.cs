using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.PaymentMethods.Commands.Create
{
    public class CreatePaymentMethodCommand : IRequest<CreatePaymentMethodResponse>
    {
        public string Name { get; set; }

        public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, CreatePaymentMethodResponse>
        {
            private readonly IPaymentMethodRepository _paymentMethodRepository;
            private readonly IMapper _mapper;

            public CreatePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
            {
                _paymentMethodRepository = paymentMethodRepository;
                _mapper = mapper;
            }

            public async Task<CreatePaymentMethodResponse> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
            {

                PaymentMethod? methodWithSameName = await _paymentMethodRepository.GetAsync(pm => pm.Name == request.Name);
                if (methodWithSameName is not null)
                    throw new BusinessException("Bu isimde başka bir ödeme yöntemi zaten mevcut.");

                PaymentMethod paymentMethod = _mapper.Map<PaymentMethod>(request);
                await _paymentMethodRepository.AddAsync(paymentMethod);

                CreatePaymentMethodResponse response = _mapper.Map<CreatePaymentMethodResponse>(paymentMethod);
                return response;
            }
        }
    }
}
