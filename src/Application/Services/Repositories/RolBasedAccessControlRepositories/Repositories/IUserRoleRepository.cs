using Domain.Entities.RolBasedAccessControlEntities;
using IMFrameworkCore;

namespace Application.Services.Repositories.RolBasedAccessControlRepositories.Repositories;

public interface IUserRoleRepository : IRepository<UserRole,Guid>
{
}
