using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Queries.GetList
{
    public class GetListUserQuery : IRequest<List<GetListUserResponse>>
    {
        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, List<GetListUserResponse>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListUserResponse>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                List<Domain.Entities.User> users = await _userRepository.GetListAsync(include:u=>u.Include(x=>x.Role));

                var response = _mapper.Map<List<GetListUserResponse>>(users);

                return response;
            }
        }
    }
}
