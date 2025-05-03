

using Application.Features.ExpenseCategories.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ExpenseRequests.Commands.Delete
{
    public class DeleteExpenseRequestCommand : IRequest<DeleteExpenseRequestResponse>
    {
        public int Id { get; set; }

        public class DeleteExpenseRequestCommandHandler : IRequestHandler<DeleteExpenseRequestCommand, DeleteExpenseRequestResponse>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IMapper _mapper;

            public DeleteExpenseRequestCommandHandler(IExpenseRequestRepository expenseRequestRepository, IMapper mapper)
            {
                _expenseRequestRepository = expenseRequestRepository;
                _mapper = mapper;
            }

            public async Task<DeleteExpenseRequestResponse> Handle(DeleteExpenseRequestCommand request, CancellationToken cancellationToken)
            {
                ExpenseRequest? expenseRequest = await _expenseRequestRepository.GetAsync(er => er.Id == request.Id,
                                                                                            include:p=>p.Include(p=>p.User).
                                                                                            Include(p=>p.ExpenseCategory).
                                                                                            Include(p=>p.PaymentMethod).
                                                                                            Include(x=>x.BankTransaction));

                if (expenseRequest is null)
                    throw new BusinessException("Silinmek istenen masraf bulunamadı.");

                bool hasBankTransaction =
                 expenseRequest.BankTransaction != null &&
                 expenseRequest.BankTransaction.DeletedDate == null;

                if (hasBankTransaction)
                    throw new BusinessException("Bu masraf talebine ait kayıtlı bir banka işlemi bulunduğundan dolayı silinemez. Lütfen önce ilgili banka işlemini kaldırın veya iptal edin.");


                await _expenseRequestRepository.DeleteAsync(expenseRequest);

                DeleteExpenseRequestResponse response = _mapper.Map<DeleteExpenseRequestResponse>(expenseRequest);
               
                return response;
            }
        }
    }
}
