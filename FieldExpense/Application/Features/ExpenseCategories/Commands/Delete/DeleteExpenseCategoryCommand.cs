using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseCategories.Commands.Delete
{
    public class DeleteExpenseCategoryCommand : IRequest<DeleteExpenseCategoryResponse>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] RequiredRoles => ["Admin"];

        public class DeleteExpenseCategoryCommandHandler : IRequestHandler<DeleteExpenseCategoryCommand, DeleteExpenseCategoryResponse>
        {
            private readonly IExpenseCategoryRepository _expenseCategoryRepository;
            private readonly IMapper _mapper;

            public DeleteExpenseCategoryCommandHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
            {
                _expenseCategoryRepository = expenseCategoryRepository;
                _mapper = mapper;
            }

            public async Task<DeleteExpenseCategoryResponse> Handle(DeleteExpenseCategoryCommand request, CancellationToken cancellationToken)
            {
                ExpenseCategory? expenseCategory = await _expenseCategoryRepository.GetAsync(ec => ec.Id == request.Id,include:ec=>ec.Include(x=>x.ExpenseRequests));
                if (expenseCategory is null)
                    throw new BusinessException("Silinmek istenen masraf kategorisi bulunamadı.");

                bool hasExpenseRequests = expenseCategory.ExpenseRequests != null && expenseCategory.ExpenseRequests.Any(u => u.DeletedDate == null); // sadece aktif masraf kategorilri
                if (hasExpenseRequests)
                    throw new BusinessException("Bu masraf kategorisine bağlı aktif masraf talepleri bulunmaktadır. Lütfen önce bu talepleri güncelleyin veya kaldırın.");

                await _expenseCategoryRepository.DeleteAsync(expenseCategory);

                DeleteExpenseCategoryResponse response = _mapper.Map<DeleteExpenseCategoryResponse>(expenseCategory);
                return response;
            }
        }
    }
}
