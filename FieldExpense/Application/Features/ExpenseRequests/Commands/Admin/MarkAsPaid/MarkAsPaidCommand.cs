using Application.Features.Auth.Commands.UpdatePassword;
using Application.Repositories;
using Application.Services.BankTransactionService;
using Application.Services.PaymentGatewayService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;


namespace Application.Features.ExpenseRequests.Commands.Admin.MarkAsPaid
{   //admin onayladıktan sonra ödme yapılıcağı zman çalışıcak komut.
    //Bunu ayrı yaptım çünkü admin onayladı diyelim fkat ödme işte bir kaç gün sonra gerçekleşti yada muhasebeci onaylananları ödüyor mantığı var.Bu daha doğru bir yaklaşım.
    public class MarkAsPaidCommand : IRequest<MarkAsPaidResponse>, ISecuredRequest
    {
        public int ExpenseRequestId { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class MarkAsPaidCommandHandler : IRequestHandler<MarkAsPaidCommand, MarkAsPaidResponse>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IPaymentGatewayService _paymentGatewayService;
            private readonly IMapper _mapper;

            public MarkAsPaidCommandHandler(
                IExpenseRequestRepository expenseRequestRepository,
                IPaymentGatewayService paymentGatewayService,
                IMapper mapper)
            {
                _expenseRequestRepository = expenseRequestRepository;
                _paymentGatewayService = paymentGatewayService;
                _mapper = mapper;
            }

            public async Task<MarkAsPaidResponse> Handle(MarkAsPaidCommand request, CancellationToken cancellationToken)
            {
                var expenseRequest = await _expenseRequestRepository.GetAsync(er => er.Id == request.ExpenseRequestId);

                if (expenseRequest is null)
                    throw new BusinessException("Masraf talebi bulunamadı.");

                if (expenseRequest.Status != Domain.Enums.ExpenseStatus.Onaylandı)
                    throw new BusinessException("Yalnızca onaylanmış talepler ödenebilir.");

                if (expenseRequest.IsPaid)
                    throw new BusinessException("Bu talep zaten ödenmiş.");

                var transaction = await _paymentGatewayService.CreateTransactionAsync(new()
                {
                    ExpenseRequestId = expenseRequest.Id,
                    Amount = expenseRequest.Amount
                });

                expenseRequest.IsPaid = true;
                await _expenseRequestRepository.UpdateAsync(expenseRequest);

                var response = _mapper.Map<MarkAsPaidResponse>(transaction);
                response.Message = "Ödeme işlemi gerçekleştirildi";
                return response;
            }
        }
    }
}
