using IMFrameworkCore;

namespace Domain.Entities.Project;

public class HairSalon:Entity<Guid>
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string? Description { get; set; }
    public double? AverageServiceRating => CalculateAverageServiceRating();
    public double? AverageHairDresserRating => CalculateAverageHairDresserRating();
    public double? HygieneRating => HairSalonHygieneRatings.Any()? HairSalonHygieneRatings.Average(r => r.Score) : 0; //addedd
    public double? Rating => CalculateAverageRating();
    //imageurl eklenecek
    //konum

    public virtual ICollection<HairSalonImage> Images { get; set; } 

    public virtual ICollection<HairSalonHygieneRating> HairSalonHygieneRatings { get; set; } = new List<HairSalonHygieneRating>(); //addedd
    public virtual ICollection<HairDresser> HairDressers { get; set; }
    public virtual ICollection<Service> Services { get; set; }
    public virtual ICollection<HairSalonComment> HairSalonComments { get; set; }


    public HairSalon()
    {
        HairDressers = new HashSet<HairDresser>();
        Services = new HashSet<Service>();
        HairSalonComments= new HashSet<HairSalonComment>();
        Images= new HashSet<HairSalonImage>();
        Name = string.Empty;
        PhoneNumber = string.Empty;
        Address = string.Empty;
        Email = string.Empty;
        Description = string.Empty;
    }

    public HairSalon(Guid id,string name,string phoneNumber,string address,
        string email, string description,double rating):this()
    {
        Id = id;
        Name = name; 
        PhoneNumber = phoneNumber; 
        Address = address; 
        Email = email; 
        Description = description;
    }

    // Salon Genel Ortalaması
    private double CalculateAverageRating()
    {
        var hairDresserRatings = HairDressers.Any(hd => hd.Rating > 0) ? HairDressers.Where(hd => hd.Rating > 0).Average(hd => hd.Rating) : 0;
        var serviceRatings = Services.Any(s => s.Rating > 0) ? Services.Where(s => s.Rating > 0).Average(s => s.Rating) : 0;
        var hygieneRating = HygieneRating.HasValue ? HygieneRating.Value : 0;

        var totalCount = (HairDressers.Count(hd => hd.Rating > 0) + Services.Count(s => s.Rating > 0) + (HairSalonHygieneRatings.Any() ? 1 : 0));
        if (totalCount == 0)
            return 0;

        return (hairDresserRatings + serviceRatings + hygieneRating) / totalCount;
    }

    // Servislerin Genel Ortalaması
    private double CalculateAverageServiceRating()
    {
        var serviceRatings = Services.Any(s => s.Rating > 0) ? Services.Where(s => s.Rating > 0).Average(s => s.Rating) : 0;
        var totalCount = Services.Count;
        if (totalCount == 0) return 0;
        return serviceRatings;
    }

    // Kuaförlerin Genel Ortalaması
    private double CalculateAverageHairDresserRating()
    {
        var hairDresserRatings = HairDressers.Any(h => h.Rating > 0) ? HairDressers.Where(h => h.Rating > 0).Average(h => h.Rating) : 0;
        var totalCount = HairDressers.Count;
        if (totalCount == 0) return 0;
        return hairDresserRatings;
    }


    public void AddRating(HairSalonHygieneRating hairSalonHygieneRating)
    {
        HairSalonHygieneRatings.Add(hairSalonHygieneRating);
    }


    ////Salon Genel Ortalaması
    //private double CalculateAverageRating()
    //{
    //    var hairDresserRatings = HairDressers.Any() ? HairDressers.Average(hd => hd.Rating) : 0;
    //    var serviceRatings = Services.Any() ? Services.Average(s => s.Rating) : 0;

    //    var totalCount = (HairDressers.Count + Services.Count);
    //    if (totalCount == 0)
    //        return 0;

    //    return (hairDresserRatings + serviceRatings) / 2;
    //}

    ////Servislerin Genel Ortalaması
    //private double CalculateAverageServiceRating()
    //{
    //    var serviceRatings=Services.Any() ? Services.Average(s=>s.Rating) : 0;
    //    var totalCount = Services.Count;
    //    if (totalCount == 0) return 0;
    //    return serviceRatings;
    //}

    ////Kuaförlerin Genel Ortalaması

    //private double CalculateAverageHairDresserRating()
    //{
    //    var hairDresserRatings = HairDressers.Any() ? HairDressers.Average(h=>h.Rating) : 0;
    //    var totalCount = HairDressers.Count;
    //    if(totalCount == 0) return 0;
    //    return hairDresserRatings;
    //}


}
