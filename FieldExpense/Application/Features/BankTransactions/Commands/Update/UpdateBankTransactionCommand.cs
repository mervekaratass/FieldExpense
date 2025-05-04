using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.BankTransactions.Commands.Update
{
    public class UpdateBankTransactionCommand : IRequest<UpdateBankTransactionResponse>,ISecuredRequest
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public string BankReferenceCode { get; set; }

        public string[] RequiredRoles => ["Admin"];
        public class UpdateBankTransactionCommandHandler : IRequestHandler<UpdateBankTransactionCommand, UpdateBankTransactionResponse>
        {
            private readonly IBankTransactionRepository _bankTransactionRepository;
            private readonly IMapper _mapper;

            public UpdateBankTransactionCommandHandler(IBankTransactionRepository bankTransactionRepository, IMapper mapper)
            {
                _bankTransactionRepository = bankTransactionRepository;
                _mapper = mapper;
            }

            public async Task<UpdateBankTransactionResponse> Handle(UpdateBankTransactionCommand request, CancellationToken cancellationToken)
            {
                BankTransaction? transaction = await _bankTransactionRepository.GetAsync(bt => bt.Id == request.Id);

                if (transaction == null)
                    throw new BusinessException("Güncellenmek istenen banka işlemi bulunamadı.");

                _mapper.Map(request, transaction);
                await _bankTransactionRepository.UpdateAsync(transaction);

                var response = _mapper.Map<UpdateBankTransactionResponse>(transaction);
                return response;
            }
        }

    }
}
