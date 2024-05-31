using Application.Features.ProjectFeatures.ServicesFeatures.Commands.Create;
using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using CachingBehavior;
using Domain.Entities.Project;
using IMFrameworkCore;
using MediatR;

namespace Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Create;

public sealed class CreateHairDresserCommand:IRequest<CreatedHairDresserResponse>,ICacheRemoverRequest,ILoggableRequest,ITransactionalRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public Guid HairSalonId { get; set; }
    public string CacheKey => "";

    public string? CacheGroupKey => "GetHairSalons";

    public bool ByPassCache => false;
    public CreateHairDresserCommand()
    {
        FirstName = string.Empty; LastName = string.Empty;
    }
}

internal sealed class CreatedHairDresserCommandHandler(
    IHairDresserRepository hairDresserRepository,
    IHairSalonRepository hairSalonRepository,
    IMapper mapper
    ) : IRequestHandler<CreateHairDresserCommand, CreatedHairDresserResponse>
{
    public async Task<CreatedHairDresserResponse> Handle(CreateHairDresserCommand request, CancellationToken cancellationToken)
    {
        HairSalon? hairSalon = await hairSalonRepository.GetAsync(p => request.HairSalonId == p.Id);
             if (hairSalon is null)
        {
            throw new Exception("Kuaför Bulunamadı");
        }
        HairDresser hairDresser = mapper.Map<HairDresser>(request);
        hairDresser.Id = Guid.NewGuid();

        await hairDresserRepository.AddAsync(hairDresser);

        CreatedHairDresserResponse response = mapper.Map<CreatedHairDresserResponse>(request);

        return response;
    }
}
