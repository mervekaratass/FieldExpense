using Application.Repositories;
using Core.Persistence;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class RoleRepository : EfRepositoryBase<Role, int, BaseDbContext>, IRoleRepository
    {
        public RoleRepository(BaseDbContext context) : base(context)
        {
        }

    }
}
