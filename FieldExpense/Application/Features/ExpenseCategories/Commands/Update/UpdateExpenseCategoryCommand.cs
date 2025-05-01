using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;


namespace Application.Features.ExpenseCategories.Commands.Update
{
    public class UpdateExpenseCategoryCommand : IRequest<UpdateExpenseCategoryResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateExpenseCategoryCommandHandler : IRequestHandler<UpdateExpenseCategoryCommand, UpdateExpenseCategoryResponse>
        {
            private readonly IExpenseCategoryRepository _expenseCategoryRepository;
            private readonly IMapper _mapper;

            public UpdateExpenseCategoryCommandHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
            {
                _expenseCategoryRepository = expenseCategoryRepository;
                _mapper = mapper;
            }

            public async Task<UpdateExpenseCategoryResponse> Handle(UpdateExpenseCategoryCommand request, CancellationToken cancellationToken)
            {
                ExpenseCategory? expenseCategory = await _expenseCategoryRepository.GetAsync(ec => ec.Id == request.Id);
                if (expenseCategory is null)
                    throw new BusinessException("Güncellenmek istenen masraf kategorisi bulunamadı.");


                ExpenseCategory? withSameNameCategory = await _expenseCategoryRepository.GetAsync(ec => ec.Name == request.Name && ec.Id != request.Id);
                if (withSameNameCategory is not null)
                    throw new BusinessException("Aynı isimde başka bir gider kategorisi zaten mevcut.");

                _mapper.Map(request, expenseCategory);

                await _expenseCategoryRepository.UpdateAsync(expenseCategory);

                UpdateExpenseCategoryResponse response = _mapper.Map<UpdateExpenseCategoryResponse>(expenseCategory);
                return response;
            }
        }
    }
}
