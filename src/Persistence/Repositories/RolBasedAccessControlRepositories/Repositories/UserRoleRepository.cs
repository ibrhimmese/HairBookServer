using Application.Services.Repositories.RolBasedAccessControlRepositories.Repositories;
using Domain.Entities.RolBasedAccessControlEntities;
using IMFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.RolBasedAccessControlRepositories.Repositories;

public class UserRoleRepository : Repository<UserRole, Guid, BaseDbContext>, IUserRoleRepository
{
    public UserRoleRepository(BaseDbContext context) : base(context)
    {
    }
}
