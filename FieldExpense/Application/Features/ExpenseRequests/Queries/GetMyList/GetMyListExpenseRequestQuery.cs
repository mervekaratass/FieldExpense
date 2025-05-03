using Application.Features.ExpenseRequests.Queries.GetMyList;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Application.Features.ExpenseRequests.Queries.GetList
{
    public class GetMyListExpenseRequestQuery : IRequest<List<GetMyListExpenseRequestResponse>>,ISecuredRequest
    {
        public string[] RequiredRoles => ["Personel"];
        public class GetMyListExpenseRequestQueryHandler : IRequestHandler<GetMyListExpenseRequestQuery, List<GetMyListExpenseRequestResponse>>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetMyListExpenseRequestQueryHandler(IExpenseRequestRepository expenseRequestRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _expenseRequestRepository = expenseRequestRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<List<GetMyListExpenseRequestResponse>> Handle(GetMyListExpenseRequestQuery request, CancellationToken cancellationToken)
            {
                int userId = int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

                List<ExpenseRequest> expenseRequests = await _expenseRequestRepository
                    .GetListAsync(
                        predicate: er => er.UserId == userId,
                        include: er => er
                            .Include(x => x.User)
                            .Include(x => x.ExpenseCategory)
                            .Include(x => x.PaymentMethod)
                    );


                List<GetMyListExpenseRequestResponse> response = _mapper.Map<List<GetMyListExpenseRequestResponse>>(expenseRequests);
             
                return response;
            }



        }
    }
}
