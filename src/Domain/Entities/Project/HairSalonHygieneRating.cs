using IMFrameworkCore;

namespace Domain.Entities.Project;

public class HairSalonHygieneRating:Entity<Guid>
{
    public double Score { get; set; }
    public Guid HairSalonId { get; set; }

    public HairSalonHygieneRating()
    {
        Id = Guid.NewGuid();
    }
    public HairSalonHygieneRating(double score, Guid hairSalonId) : this()
    {
        if (score < 1 || score > 5)
            throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 1 and 5");

        Score = score;
        HairSalonId = hairSalonId;

    }
}
