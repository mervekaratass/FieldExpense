
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExpenseCategories.Queries.GetById
{
    public class GetByIdExpenseCategoryQuery : IRequest<GetByIdExpenseCategoryResponse>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] RequiredRoles => ["Admin"];
        public class GetByIdExpenseCategoryQueryHandler : IRequestHandler<GetByIdExpenseCategoryQuery, GetByIdExpenseCategoryResponse>
        {
            private readonly IExpenseCategoryRepository _expenseCategoryRepository;
            private readonly IMapper _mapper;

            public GetByIdExpenseCategoryQueryHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
            {
                _expenseCategoryRepository = expenseCategoryRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdExpenseCategoryResponse> Handle(GetByIdExpenseCategoryQuery request, CancellationToken cancellationToken)
            {
                ExpenseCategory? expenseCategory = await _expenseCategoryRepository.GetAsync(ec => ec.Id == request.Id);
                if (expenseCategory is null)
                    throw new BusinessException("Böyle bir masraf kategorisi bulunamadı.");

                GetByIdExpenseCategoryResponse response = _mapper.Map<GetByIdExpenseCategoryResponse>(expenseCategory);
                return response;
            }
        }
    }
}
