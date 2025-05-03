
using Application.Features.ExpenseCategories.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.PaymentMethods.Queries.GetList
{
    public class GetListPaymentMethodQuery : IRequest<List<GetListPaymentMethodResponse>>,ISecuredRequest
    {
        public string[] RequiredRoles => ["Admin"];
        public class GetListPaymentMethodQueryHandler : IRequestHandler<GetListPaymentMethodQuery, List<GetListPaymentMethodResponse>>
        {
            private readonly IPaymentMethodRepository _paymentMethodRepository;
            private readonly IMapper _mapper;

            public GetListPaymentMethodQueryHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
            {
                _paymentMethodRepository = paymentMethodRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListPaymentMethodResponse>> Handle(GetListPaymentMethodQuery request, CancellationToken cancellationToken)
            {
                List<PaymentMethod> paymentMethods = await _paymentMethodRepository.GetListAsync();

                List<GetListPaymentMethodResponse> response = _mapper.Map<List<GetListPaymentMethodResponse>>(paymentMethods);
                return response;
            }
        }
    }
}
