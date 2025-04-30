
using Domain.Entities;

namespace Application.Services.RoleService
{
    public interface IRoleService
    {
        Task<Role?> GetByIdAsync(int id);
    }
}
