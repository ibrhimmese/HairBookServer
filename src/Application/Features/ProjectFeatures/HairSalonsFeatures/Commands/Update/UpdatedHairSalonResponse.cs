using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Update
{
    public class UpdatedHairSalonResponse
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public UpdatedHairSalonResponse()
        {
            Name=string.Empty;
            PhoneNumber=string.Empty;
            Address=string.Empty;
            Email=string.Empty;
            Description=string.Empty;
        }
    }
}
