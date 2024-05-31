using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using IMFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.ProjectRepositories;

public class ServiceRepository : Repository<Service, Guid, BaseDbContext>, IServiceRepository
{
    public ServiceRepository(BaseDbContext context) : base(context)
    {
    }
}