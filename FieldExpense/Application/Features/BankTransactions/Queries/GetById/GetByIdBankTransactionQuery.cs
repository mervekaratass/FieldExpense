
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BankTransactions.Queries.GetById
{
    public class GetByIdBankTransactionQuery : IRequest<GetByIdBankTransactionResponse>
    {
        public int Id { get; set; }

        public class GetByIdBankTransactionQueryHandler : IRequestHandler<GetByIdBankTransactionQuery, GetByIdBankTransactionResponse>
        {
            private readonly IBankTransactionRepository _bankTransactionRepository;
            private readonly IMapper _mapper;

            public GetByIdBankTransactionQueryHandler(IBankTransactionRepository bankTransactionRepository, IMapper mapper)
            {
                _bankTransactionRepository = bankTransactionRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdBankTransactionResponse> Handle(GetByIdBankTransactionQuery request, CancellationToken cancellationToken)
            {
                BankTransaction? bankTransaction = await _bankTransactionRepository.GetAsync(bt => bt.Id == request.Id, include: bt => bt.Include(x => x.ExpenseRequest).ThenInclude(x => x.User));

                if (bankTransaction is null)
                    throw new BusinessException("İlgili banka işlemi bulunamadı.");

                return _mapper.Map<GetByIdBankTransactionResponse>(bankTransaction);
            }
        }
    }

}
