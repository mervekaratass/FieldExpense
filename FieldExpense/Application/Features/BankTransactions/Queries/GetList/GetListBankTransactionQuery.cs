using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BankTransactions.Queries.GetList
{
    public class GetListBankTransactionQuery : IRequest<List<GetListBankTransactionResponse>>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Admin"];

        public class GetListBankTransactionQueryHandler : IRequestHandler<GetListBankTransactionQuery, List<GetListBankTransactionResponse>>
        {
            private readonly IBankTransactionRepository _bankTransactionRepository;
            private readonly IMapper _mapper;

            public GetListBankTransactionQueryHandler(IBankTransactionRepository bankTransactionRepository, IMapper mapper)
            {
                _bankTransactionRepository = bankTransactionRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListBankTransactionResponse>> Handle(GetListBankTransactionQuery request, CancellationToken cancellationToken)
            {
                List<BankTransaction> bankTransactions = await _bankTransactionRepository.GetListAsync(include: bt => bt.Include(x => x.ExpenseRequest).ThenInclude(x => x.User));

                return _mapper.Map<List<GetListBankTransactionResponse>>(bankTransactions.ToList());
            }
        }

    }
}
