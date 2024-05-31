using IMFrameworkCore;

namespace Domain.Entities.Project;

public class Service:Entity<Guid>
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Duration { get; set; }
    public string? Description { get; set; }
    public double Rating => ServiceRatings.Any() ? ServiceRatings.Average(r => r.Score) : 0; //addedd
    public virtual ICollection<ServiceRating> ServiceRatings { get; set; } = new List<ServiceRating>(); //addedd

    public Guid? HairSalonId { get; set; }
    public virtual HairSalon? HairSalon { get; set; } //Burası Collection olabilir tartışacağız

    public Service()
    {
        Name = string.Empty;
        Price = 0;
        Duration = 0;
        Description = string.Empty;
        HairSalonId = Guid.NewGuid();
    }
    public Service(Guid id, string name, double price, int duration, string description,Guid hairSalonId):this()
    {
        Id = id; 
        Name = name; 
        Price = price;
        Duration = duration; 
        Description = description;
        HairSalonId= hairSalonId;
    }
    public void AddRating(ServiceRating serviceRating)
    {
        ServiceRatings.Add(serviceRating);
    }
}
