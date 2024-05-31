using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using IMFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.ProjectRepositories;

public class HairSalonHygieneRatingRepository : Repository<HairSalonHygieneRating, Guid, BaseDbContext>, IHairSalonHygieneRatingRepository
{
    public HairSalonHygieneRatingRepository(BaseDbContext context) : base(context)
    {
    }
}
