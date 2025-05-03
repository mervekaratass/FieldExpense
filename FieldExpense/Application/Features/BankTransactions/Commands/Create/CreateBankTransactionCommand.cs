using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.BankTransactions.Commands.Create
{
    public class CreateBankTransactionCommand : IRequest<CreateBankTransactionResponse>
    {
        public int ExpenseRequestId { get; set; }
        public decimal Amount { get; set; }


        public class CreateBankTransactionCommandHandler : IRequestHandler<CreateBankTransactionCommand, CreateBankTransactionResponse>
        {
            private readonly IBankTransactionRepository _bankTransactionRepository;
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IMapper _mapper;

            public CreateBankTransactionCommandHandler(
                IBankTransactionRepository bankTransactionRepository,
                IExpenseRequestRepository expenseRequestRepository,
                IMapper mapper)
            {
                _bankTransactionRepository = bankTransactionRepository;
                _expenseRequestRepository = expenseRequestRepository;
                _mapper = mapper;
            }

            public async Task<CreateBankTransactionResponse> Handle(CreateBankTransactionCommand request, CancellationToken cancellationToken)
            {
                var expenseRequest = await _expenseRequestRepository.GetAsync(er => er.Id == request.ExpenseRequestId);
                if (expenseRequest is null)
                    throw new BusinessException("İlgili masraf isteği bulunamadı.");

                var entity = _mapper.Map<BankTransaction>(request);
                entity.TransactionStatus = TransactionStatus.Başarılı;
                entity.TransactionDate = DateTime.UtcNow;
                entity.BankReferenceCode = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                await _bankTransactionRepository.AddAsync(entity);

                var response = _mapper.Map<CreateBankTransactionResponse>(entity);
                response.TransactionStatus = entity.TransactionStatus.ToString();
                return response;
            }
        }
    }


}
