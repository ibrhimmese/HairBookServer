using IMFrameworkCore;

namespace Domain.Entities.Project;

public class HairDresserRating : Entity<Guid>
{
    public double Score { get; set; }
    public Guid HairDresserId { get; set; }

    public HairDresserRating()
    {
        Id= Guid.NewGuid();
    }
    public HairDresserRating(double score, Guid hairDresserId):this()
    {
        if (score < 1 || score > 5)
            throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 1 and 5");

        Score = score;
        HairDresserId = hairDresserId;
       
    }

}
