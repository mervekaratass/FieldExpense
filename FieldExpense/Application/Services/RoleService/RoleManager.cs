

using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Services.RoleService
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleManager(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            Role? role=await _roleRepository.GetAsync(r => r.Id == id);
            if (role is null)
                throw new BusinessException("Rol bulunamadı");

            return role;
        }
    }
}
