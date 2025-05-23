﻿using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExpenseCategories.Commands.Create
{
    public class CreateExpenseCategoryCommand : IRequest<CreateExpenseCategoryResponse>,ISecuredRequest
    {
        public string[] RequiredRoles => ["Admin"];
        public string Name { get; set; }

        public class CreateExpenseCategoryCommandHandler : IRequestHandler<CreateExpenseCategoryCommand, CreateExpenseCategoryResponse>
        {
            private readonly IExpenseCategoryRepository _expenseCategoryRepository;
            private readonly IMapper _mapper;

            public CreateExpenseCategoryCommandHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
            {
                _expenseCategoryRepository = expenseCategoryRepository;
                _mapper = mapper;
            }

            public async Task<CreateExpenseCategoryResponse> Handle(CreateExpenseCategoryCommand request, CancellationToken cancellationToken)
            {

                ExpenseCategory? categoryWithSameName = await _expenseCategoryRepository.GetAsync(ec => ec.Name == request.Name);
                if (categoryWithSameName is not null)
                    throw new BusinessException("Aynı isimde ikinci bir masraf kategorisi eklenemez.");

                ExpenseCategory expenseCategory = _mapper.Map<ExpenseCategory>(request);
                await _expenseCategoryRepository.AddAsync(expenseCategory);

                CreateExpenseCategoryResponse response = _mapper.Map<CreateExpenseCategoryResponse>(expenseCategory);
                return response;
            }
        }
    }
}
