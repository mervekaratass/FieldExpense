using Application.Features.ExpenseCategories.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PaymentMethods.Commands.Update
{
    public class UpdatePaymentMethodCommand : IRequest<UpdatePaymentMethodResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdatePaymentMethodCommandHandler : IRequestHandler<UpdatePaymentMethodCommand, UpdatePaymentMethodResponse>
        {
            private readonly IPaymentMethodRepository _paymentMethodRepository;
            private readonly IMapper _mapper;

            public UpdatePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
            {
                _paymentMethodRepository = paymentMethodRepository;
                _mapper = mapper;
            }

            public async Task<UpdatePaymentMethodResponse> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
            {
                PaymentMethod? paymentMethod = await _paymentMethodRepository.GetAsync(ec => ec.Id == request.Id);
                if (paymentMethod is null)
                    throw new BusinessException("Güncellenecek ödeme yöntemi bulunamadı.");


                PaymentMethod? withSameNameMethod = await _paymentMethodRepository.GetAsync(ec => ec.Name == request.Name && ec.Id != request.Id);
                if (withSameNameMethod is not null)
                    throw new BusinessException("Bu isimde başka bir ödeme yöntemi zaten mevcut.");

                _mapper.Map(request, paymentMethod);

                await _paymentMethodRepository.UpdateAsync(paymentMethod);

                UpdatePaymentMethodResponse response = _mapper.Map<UpdatePaymentMethodResponse>(paymentMethod);
                return response;
            }
        }
    }
}
