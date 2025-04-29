using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ExpenseRequests.Queries.GetList
{
    public class GetListExpenseRequestQuery : IRequest<List<GetListExpenseRequestResponse>>
    {
        public class GetListExpenseRequestQueryHandler : IRequestHandler<GetListExpenseRequestQuery, List<GetListExpenseRequestResponse>>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IMapper _mapper;

            public GetListExpenseRequestQueryHandler(IExpenseRequestRepository expenseRequestRepository, IMapper mapper)
            {
                _expenseRequestRepository = expenseRequestRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListExpenseRequestResponse>> Handle(GetListExpenseRequestQuery request, CancellationToken cancellationToken)
            {
                List<ExpenseRequest> expenseRequests = await _expenseRequestRepository
                    .GetListAsync(
                      include: er => er.Include(x => x.User).Include(x => x.ExpenseCategory).Include(x => x.PaymentMethod)

                    );

                List<GetListExpenseRequestResponse> response = _mapper.Map<List<GetListExpenseRequestResponse>>(expenseRequests);
                return response;
            }
        }
    }
}
