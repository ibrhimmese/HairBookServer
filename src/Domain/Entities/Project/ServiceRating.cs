using IMFrameworkCore;

namespace Domain.Entities.Project;

public class ServiceRating:Entity<Guid>
{
    public double Score { get; set; }
    public Guid ServiceId { get; set; }

    public ServiceRating()
    {
        Id = Guid.NewGuid();
    }
    public ServiceRating(double score, Guid hairDresserId) : this()
    {
        if (score < 1 || score > 5)
            throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 1 and 5");

        Score = score;
        ServiceId = hairDresserId;

    }
}
