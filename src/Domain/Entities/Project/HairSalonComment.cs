using IMFrameworkCore;

namespace Domain.Entities.Project;

public class HairSalonComment:Entity<Guid>
{
    public string Message { get; set; }
    public Guid HairSalonId { get; set; }
    public virtual HairSalon? HairSalon { get; set; }
    public HairSalonComment()
    {
        Id= Guid.NewGuid();
        Message= string.Empty;
    }
}

