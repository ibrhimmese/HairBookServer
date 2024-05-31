using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using IMFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.ProjectRepositories;

public class ServiceRatingRepository : Repository<ServiceRating, Guid, BaseDbContext>, IServiceRatingRepository
{
    public ServiceRatingRepository(BaseDbContext context) : base(context)
    {
    }
}
