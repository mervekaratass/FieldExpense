using Application.Features.PaymentMethods.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Roles.Commands.Create
{
    public class CreateRoleCommand : IRequest<CreateRoleResponse>,ISecuredRequest
    {
        public string Name { get; set; }
        public string[] RequiredRoles => ["Admin"];

        public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleResponse>
        {
            private readonly IRoleRepository _roleRepository;
            private readonly IMapper _mapper;

            public CreateRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
            {
                _roleRepository = roleRepository;
                _mapper = mapper;
            }

            public async Task<CreateRoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {

                Role? roleWithSameName = await _roleRepository.GetAsync(pm => pm.Name == request.Name);
                if (roleWithSameName is not null)
                    throw new BusinessException("Bu isimde başka bir rol zaten mevcut.");

                Role role = _mapper.Map<Role>(request);
                await _roleRepository.AddAsync(role);

                CreateRoleResponse response = _mapper.Map<CreateRoleResponse>(role);
                return response;
            }
        }
    }
}
