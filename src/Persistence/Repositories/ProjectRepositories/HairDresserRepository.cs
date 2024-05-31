using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using IMFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.ProjectRepositories;

public class HairDresserRepository : Repository<HairDresser, Guid, BaseDbContext>, IHairDresserRepository
{
    public HairDresserRepository(BaseDbContext context) : base(context)
    {
    }
}
