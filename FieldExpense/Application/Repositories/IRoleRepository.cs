using Core.Persistence;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IRoleRepository : IRepository<Role, int>, IAsyncRepository<Role, int>
    {

    }
}
