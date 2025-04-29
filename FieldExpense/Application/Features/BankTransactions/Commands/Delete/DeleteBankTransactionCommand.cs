using Application.Repositories;
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

            public DeleteBankTransactionCommandHandler(IBankTransactionRepository bankTransactionRepository)
            {
                _bankTransactionRepository = bankTransactionRepository;
            }

            public async Task<DeleteBankTransactionResponse> Handle(DeleteBankTransactionCommand request, CancellationToken cancellationToken)
            {
                BankTransaction? entity = await _bankTransactionRepository.GetAsync(predicate: bt => bt.Id == request.Id ,include:bt=>bt.Include(x=>x.ExpenseRequest).ThenInclude(x=>x.User));
                if (entity is null)
                    throw new BusinessException("Silinmek istenen banka işlemi bulunamadı.");

                entity.DeletedDate = DateTime.UtcNow;

                await _bankTransactionRepository.UpdateAsync(entity, cancellationToken);

                return new DeleteBankTransactionResponse { Id = entity.Id };
            }
        }
    }
}
