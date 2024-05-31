using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using IMFrameworkCore;
using System.Drawing.Drawing2D;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Rules;

public class HairSalonBusinessRules:BaseBusinessRules
{
    private readonly IHairSalonRepository _hairSalonRepository;

    public HairSalonBusinessRules(IHairSalonRepository hairSalonRepository)
    {
        _hairSalonRepository = hairSalonRepository;
    }
    //public async Task BrandNameCannotBeDupplicatedInserted(string name)
    //{
    //    HairSalon? hairSalon = await hairSalonRepository.GetAsync(p => p.Name.ToLower() == name.ToLower());
    //    if (hairSalon is not null)
    //    {
    //        throw new BusinessException("Bu Marka Daha Önce Oluşturulmuştur");
    //    }
    //}
}
