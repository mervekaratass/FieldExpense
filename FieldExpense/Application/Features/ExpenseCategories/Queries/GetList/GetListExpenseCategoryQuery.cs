

using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExpenseCategories.Queries.GetList
{
    public class GetListExpenseCategoryQuery : IRequest<List<GetListExpenseCategoryResponse>>
    {
        public class GetListExpenseCategoryQueryHandler : IRequestHandler<GetListExpenseCategoryQuery, List<GetListExpenseCategoryResponse>>
        {
            private readonly IExpenseCategoryRepository _expenseCategoryRepository;
            private readonly IMapper _mapper;

            public GetListExpenseCategoryQueryHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
            {
                _expenseCategoryRepository = expenseCategoryRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListExpenseCategoryResponse>> Handle(GetListExpenseCategoryQuery request, CancellationToken cancellationToken)
            {
                List<ExpenseCategory> expenseCategories = await _expenseCategoryRepository.GetListAsync();

                List<GetListExpenseCategoryResponse> response = _mapper.Map<List<GetListExpenseCategoryResponse>>(expenseCategories);
                return response;
            }
        }
    }
}
