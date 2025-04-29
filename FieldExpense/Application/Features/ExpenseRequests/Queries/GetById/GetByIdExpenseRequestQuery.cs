using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ExpenseRequests.Queries.GetById
{
    public class GetByIdExpenseRequestQuery : IRequest<GetByIdExpenseRequestResponse>
    {
        public int Id { get; set; }

        public class GetByIdExpenseRequestQueryHandler : IRequestHandler<GetByIdExpenseRequestQuery, GetByIdExpenseRequestResponse>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IMapper _mapper;

            public GetByIdExpenseRequestQueryHandler(IExpenseRequestRepository expenseRequestRepository, IMapper mapper)
            {
                _expenseRequestRepository = expenseRequestRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdExpenseRequestResponse> Handle(GetByIdExpenseRequestQuery request, CancellationToken cancellationToken)
            {
                ExpenseRequest? entity = await _expenseRequestRepository
                    .GetAsync(
                        predicate: er => er.Id == request.Id,
                        include: er => er.Include(x=>x.User).Include(x=>x.ExpenseCategory).Include(x=>x.PaymentMethod)                        
                    );

                if (entity is null)
                    throw new BusinessException("Masraf bulunamadı.");

                GetByIdExpenseRequestResponse response = _mapper.Map<GetByIdExpenseRequestResponse>(entity);
                return response;
            }
        }
    }
}
