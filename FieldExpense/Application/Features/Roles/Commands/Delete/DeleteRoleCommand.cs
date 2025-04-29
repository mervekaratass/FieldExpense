using Application.Features.PaymentMethods.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Roles.Commands.Delete
{
    public class DeleteRoleCommand : IRequest<DeleteRoleResponse>
    {
        public int Id { get; set; }

        public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, DeleteRoleResponse>
        {
            private readonly IRoleRepository _roleRepository;
            private readonly IMapper _mapper;

            public DeleteRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
            {
                _roleRepository = roleRepository;
                _mapper = mapper;
            }

            public async Task<DeleteRoleResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
            {
                Role? role = await _roleRepository.GetAsync(ec => ec.Id == request.Id);
                if (role is null)
                    throw new BusinessException("Silinmek istenen rol bulunamadı.");

                await _roleRepository.DeleteAsync(role);

                DeleteRoleResponse response = _mapper.Map<DeleteRoleResponse>(role);
                return response;
            }
        }
    }
}
