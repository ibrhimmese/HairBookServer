using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using IMFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.ProjectRepositories;

public class HairSalonCommentRepository : Repository<HairSalonComment, Guid, BaseDbContext>, IHairSalonCommentRepository
{
    public HairSalonCommentRepository(BaseDbContext context) : base(context)
    {
    }
}
