using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseRequests.Queries.Employee.GetFiltered
{
    public class GetFilteredExpenseRequestQuery : IRequest<List<GetFilteredExpenseRequestResponse>>, ISecuredRequest
    {
        //tokendan gelicek
        // public int UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ExpenseCategoryId { get; set; }
        public int? PaymentMethodId { get; set; }
        public ExpenseStatus? Status { get; set; }
        public bool? IsPaid { get; set; }

        public string[] RequiredRoles => ["Personel"];


        public class GetFilteredExpenseRequestQueryHandler : IRequestHandler<GetFilteredExpenseRequestQuery, List<GetFilteredExpenseRequestResponse>>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetFilteredExpenseRequestQueryHandler(IExpenseRequestRepository expenseRequestRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _expenseRequestRepository = expenseRequestRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<List<GetFilteredExpenseRequestResponse>> Handle(GetFilteredExpenseRequestQuery request, CancellationToken cancellationToken)
            {
                int userId = int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

                Expression<Func<ExpenseRequest, bool>> filter = er =>
                    er.UserId == userId &&
                    (request.StartDate == null || er.CreatedDate >= request.StartDate) &&
                    (request.EndDate == null || er.CreatedDate <= request.EndDate) &&
                    (request.ExpenseCategoryId == null || er.ExpenseCategoryId == request.ExpenseCategoryId) &&
                    (request.PaymentMethodId == null || er.PaymentMethodId == request.PaymentMethodId) &&
                    (request.Status == null || er.Status == request.Status) &&
                    (request.IsPaid == null || er.IsPaid == request.IsPaid);

                var expenseRequests = await _expenseRequestRepository.GetListAsync(
                    predicate: filter,
                    include: x => x.Include(er => er.User)
                                   .Include(er => er.ExpenseCategory)
                                   .Include(er => er.PaymentMethod),
                    cancellationToken: cancellationToken);

                return _mapper.Map<List<GetFilteredExpenseRequestResponse>>(expenseRequests);
            }
        }

    }
}
