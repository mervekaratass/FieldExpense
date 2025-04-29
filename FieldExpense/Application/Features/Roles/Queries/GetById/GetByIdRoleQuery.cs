using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;


namespace Application.Features.Roles.Queries.GetById
{
    public class GetByIdRoleQuery : IRequest<GetByIdRoleResponse>
    {
        public int Id { get; set; }

        public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQuery, GetByIdRoleResponse>
        {
            private readonly IRoleRepository _roleRepository;
            private readonly IMapper _mapper;

            public GetByIdRoleQueryHandler(IRoleRepository roleRepository, IMapper mapper)
            {
                _roleRepository = roleRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdRoleResponse> Handle(GetByIdRoleQuery request, CancellationToken cancellationToken)
            {
                Role? role = await _roleRepository.GetAsync(r => r.Id == request.Id);
                if (role is null)
                    throw new BusinessException("Rol bulunamadı.");

                return _mapper.Map<GetByIdRoleResponse>(role);
            }
        }
    }
}
