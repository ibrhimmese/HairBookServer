using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using IMFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.ProjectRepositories;

public class HairSalonImageRepository : Repository<HairSalonImage, Guid, BaseDbContext>, IHairSalonImageRepository
{
    public HairSalonImageRepository(BaseDbContext context) : base(context)
    {
    }
}
