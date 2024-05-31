using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using IMFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.ProjectRepositories;

public class HairSalonRepository : Repository<HairSalon, Guid, BaseDbContext>, IHairSalonRepository
{
    public HairSalonRepository(BaseDbContext context) : base(context)
    {
    }
}
