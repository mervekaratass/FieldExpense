using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Roles.Commands.Update
{
    public class UpdateRoleCommand : IRequest<UpdateRoleResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleResponse>
        {
            private readonly IRoleRepository _roleRepository;
            private readonly IMapper _mapper;

            public UpdateRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
            {
                _roleRepository = roleRepository;
                _mapper = mapper;
            }

            public async Task<UpdateRoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
            {
                Role? existingRole = await _roleRepository.GetAsync(r => r.Id == request.Id);
                if (existingRole is null)
                    throw new BusinessException("Güncellenmek istenen rol bulunamadı.");

                Role? roleWithSameName = await _roleRepository.GetAsync(r => r.Name == request.Name && r.Id != request.Id);
                if (roleWithSameName is not null)
                    throw new BusinessException("Aynı isimde başka bir rol zaten mevcut.");

                _mapper.Map(request, existingRole);
                await _roleRepository.UpdateAsync(existingRole, cancellationToken);

                UpdateRoleResponse response = _mapper.Map<UpdateRoleResponse>(existingRole);
                return response;
            }
        }
    }
}
