using Application.Features.ExpenseRequests.Commands.Decision.Approve.Application.Features.ExpenseRequests.Commands.Approve;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ExpenseRequests.Commands.Decision.Approve
{
    public class ApproveExpenseRequestCommand : IRequest<ApproveExpenseRequestResponse>,ISecuredRequest
    {
        public int ExpenseRequestId { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class ApproveExpenseRequestCommandHandler : IRequestHandler<ApproveExpenseRequestCommand, ApproveExpenseRequestResponse>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IMapper _mapper;

            public ApproveExpenseRequestCommandHandler(IExpenseRequestRepository expenseRequestRepository, IMapper mapper)
            {
                _expenseRequestRepository = expenseRequestRepository;
                _mapper = mapper;
            }

            public async Task<ApproveExpenseRequestResponse> Handle(ApproveExpenseRequestCommand request, CancellationToken cancellationToken)
            {
                var expenseRequest = await _expenseRequestRepository
                    .GetAsync(
                        predicate: er => er.Id == request.ExpenseRequestId,
                        include: er => er
                            .Include(er => er.User)
                            .Include(er => er.ExpenseCategory)
                            .Include(er => er.PaymentMethod)
                    );

                if (expenseRequest is null)
                    throw new BusinessException("Onaylanmak istenen masraf bulunamadı.");

                if (expenseRequest.Status == ExpenseStatus.Onaylandı)
                    throw new BusinessException("Bu masraf zaten onaylanmış.");

                expenseRequest.Status = ExpenseStatus.Onaylandı;
               // expenseRequest.RejectionReason = null;

                await _expenseRequestRepository.UpdateAsync(expenseRequest);

                return _mapper.Map<ApproveExpenseRequestResponse>(expenseRequest);
            }
        }
    }

}
