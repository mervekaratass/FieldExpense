using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.Roles.Queries.GetList
{
    public class GetListRoleQuery : IRequest<List<GetListRoleResponse>>,ISecuredRequest
    {
        public string[] RequiredRoles => ["Admin"];
        public class GetListRoleQueryHandler : IRequestHandler<GetListRoleQuery, List<GetListRoleResponse>>
        {
            private readonly IRoleRepository _roleRepository;
            private readonly IMapper _mapper;

            public GetListRoleQueryHandler(IRoleRepository roleRepository, IMapper mapper)
            {
                _roleRepository = roleRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListRoleResponse>> Handle(GetListRoleQuery request, CancellationToken cancellationToken)
            {
                List<Role> roles = await _roleRepository.GetListAsync(cancellationToken: cancellationToken);
                return _mapper.Map<List<GetListRoleResponse>>(roles);
            }
        }
    }
}
