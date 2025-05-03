using Application.Features.PaymentMethods.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Roles.Commands.Delete
{
    public class DeleteRoleCommand : IRequest<DeleteRoleResponse>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] RequiredRoles => ["Admin"];
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
                Role? role = await _roleRepository.GetAsync(ec => ec.Id == request.Id ,include:r=>r.Include(x=>x.Users));
                if (role is null)
                    throw new BusinessException("Silinmek istenen rol bulunamadı.");

                bool hasUsers = role.Users != null && role.Users.Any(u => u.DeletedDate == null); // sadece aktif kullanıcılar
                if (hasUsers)
                    throw new BusinessException("Bu role atanmış aktif kullanıcılar bulunmaktadır. Lütfen önce bu kullanıcıların rollerini güncelleyin veya kaldırın.");

                await _roleRepository.DeleteAsync(role);

                DeleteRoleResponse response = _mapper.Map<DeleteRoleResponse>(role);
                return response;
            }
        }
    }
}
