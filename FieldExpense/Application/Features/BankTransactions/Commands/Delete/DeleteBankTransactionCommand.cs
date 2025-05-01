using Application.Features.ExpenseRequests.Commands.Delete;
using Application.Repositories;
using Application.Services.BankTransactionService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BankTransactions.Commands.Delete
{
    public class DeleteBankTransactionCommand : IRequest<DeleteBankTransactionResponse>
    {
        public int Id { get; set; }

        public class DeleteBankTransactionCommandHandler : IRequestHandler<DeleteBankTransactionCommand, DeleteBankTransactionResponse>
        {
            private readonly IBankTransactionRepository _bankTransactionRepository;
            private readonly IMapper _mapper;

            public DeleteBankTransactionCommandHandler(IBankTransactionRepository bankTransactionRepository, IMapper mapper)
            {
                _bankTransactionRepository = bankTransactionRepository;
                _mapper = mapper;
            }

            public async Task<DeleteBankTransactionResponse> Handle(DeleteBankTransactionCommand request, CancellationToken cancellationToken)
            {
                BankTransaction? bankTransaction = await _bankTransactionRepository.GetAsync(predicate: bt => bt.Id == request.Id ,include:bt=>bt.Include(x=>x.ExpenseRequest).ThenInclude(x=>x.User));
                if (bankTransaction is null)
                    throw new BusinessException("Silinmek istenen banka işlemi bulunamadı.");

           

                await _bankTransactionRepository.DeleteAsync(bankTransaction);

                DeleteBankTransactionResponse response = _mapper.Map<DeleteBankTransactionResponse>(bankTransaction);

                return response;
            }
        }
    }
}
