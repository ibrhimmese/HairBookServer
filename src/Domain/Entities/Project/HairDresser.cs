using IMFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Project;

public class HairDresser:Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => string.Join(" ", FirstName , LastName);
    public string? PhoneNumber { get; set; }
    // public double Rating { get; set; }
    public double Rating => HairDresserRatings.Any() ? HairDresserRatings.Average(r => r.Score) : 0; //addedd

    public virtual ICollection<HairDresserRating> HairDresserRatings { get; set; }= new List<HairDresserRating>(); //addedd

    public Guid HairSalonId { get; set; }
    public virtual HairSalon? HairSalon { get; set; }
    //çalışanın resimleri

    public HairDresser()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        PhoneNumber = string.Empty;
        HairSalonId = Guid.NewGuid();
        //Rating ekle
    }
    public HairDresser(Guid id , string firstName,string lastName, string phoneNumber,double rating,Guid hairSalonId):this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        HairSalonId= hairSalonId;
        //Rating Ekle
    }
    //added
    public void AddRating(HairDresserRating hairDresserRating)
    {
        HairDresserRatings.Add(hairDresserRating);
    }
}
