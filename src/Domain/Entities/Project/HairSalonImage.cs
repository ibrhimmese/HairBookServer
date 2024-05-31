using IMFrameworkCore;

namespace Domain.Entities.Project;

public class HairSalonImage : Entity<Guid>
{
    public string ImageUrl { get; set; }
    public string PublicId { get; set; }
    public Guid HairSalonId { get; set; }
    public virtual HairSalon? HairSalon { get; set; }

    public HairSalonImage()
    {
        Id = Guid.NewGuid();
        ImageUrl = string.Empty;
        PublicId = string.Empty;
    }

    public HairSalonImage(string imageUrl, string publicId, Guid hairSalonId)
    {
        Id = Guid.NewGuid();
        ImageUrl = imageUrl;
        PublicId = publicId;
        HairSalonId = hairSalonId;
    }
}