
using Application.Features.ExpenseCategories.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.PaymentMethods.Queries.GetById
{
    public class GetByIdPaymentMethodQuery : IRequest<GetByIdPaymentMethodResponse>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] RequiredRoles => ["Admin"];

        public class GetByIdPaymentMethodQueryHandler : IRequestHandler<GetByIdPaymentMethodQuery, GetByIdPaymentMethodResponse>
        {
            private readonly IPaymentMethodRepository _paymentMethodRepository;
            private readonly IMapper _mapper;

            public GetByIdPaymentMethodQueryHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
            {
                _paymentMethodRepository = paymentMethodRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdPaymentMethodResponse> Handle(GetByIdPaymentMethodQuery request, CancellationToken cancellationToken)
            {
                PaymentMethod? expenseCategory = await _paymentMethodRepository.GetAsync(ec => ec.Id == request.Id);
                if (expenseCategory is null)
                    throw new BusinessException("Ödeme yöntemi bulunamadı.");

                GetByIdPaymentMethodResponse response = _mapper.Map<GetByIdPaymentMethodResponse>(expenseCategory);
                return response;
            }
        }
    }
}
