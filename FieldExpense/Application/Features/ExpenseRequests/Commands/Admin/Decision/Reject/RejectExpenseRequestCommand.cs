using Application.Features.ExpenseRequests.Commands.Decision.Reject.Application.Features.ExpenseRequests.Commands.Reject;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.ExpenseRequests.Commands.Admin.Decision.Reject
{
    public class RejectExpenseRequestCommand : IRequest<RejectExpenseRequestResponse>, ISecuredRequest
    {
        public int ExpenseRequestId { get; set; }
        public string RejectionReason { get; set; }
        public string[] RequiredRoles => ["Admin"];

        public class RejectExpenseRequestCommandHandler : IRequestHandler<RejectExpenseRequestCommand, RejectExpenseRequestResponse>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IMapper _mapper;

            public RejectExpenseRequestCommandHandler(IExpenseRequestRepository expenseRequestRepository, IMapper mapper)
            {
                _expenseRequestRepository = expenseRequestRepository;
                _mapper = mapper;
            }

            public async Task<RejectExpenseRequestResponse> Handle(RejectExpenseRequestCommand request, CancellationToken cancellationToken)
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
                    throw new BusinessException("Reddedilmek istenen masraf bulunamadı.");

                if (expenseRequest.Status == ExpenseStatus.Reddedildi)
                    throw new BusinessException("Bu masraf zaten reddedilmiş.");

                expenseRequest.Status = ExpenseStatus.Reddedildi;
                expenseRequest.RejectionReason = request.RejectionReason;

                await _expenseRequestRepository.UpdateAsync(expenseRequest);

                return _mapper.Map<RejectExpenseRequestResponse>(expenseRequest);
            }
        }
    }

}
