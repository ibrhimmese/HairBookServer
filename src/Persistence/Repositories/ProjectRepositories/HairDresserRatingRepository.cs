using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using IMFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.ProjectRepositories;

public class HairDresserRatingRepository : Repository<HairDresserRating, Guid, BaseDbContext>, IHairDresserRatingRepository
{
    public HairDresserRatingRepository(BaseDbContext context) : base(context)
    {
    }
}
