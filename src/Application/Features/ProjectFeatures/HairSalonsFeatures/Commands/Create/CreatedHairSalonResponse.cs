using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Create;

public class CreatedHairSalonResponse
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string? Description { get; set; }
    

    public DateTime CreatedDate { get; set; }

    public CreatedHairSalonResponse()
    {
        Name = string.Empty;
        PhoneNumber = string.Empty;
        Address = string.Empty;
        Email = string.Empty;
        Description = string.Empty;
    }
}
