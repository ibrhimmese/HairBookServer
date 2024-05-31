using Application.Features.ProjectFeatures.HairSalonsFeatures.Rules;
using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using CachingBehavior;
using Domain.Entities.Project;
using IMFrameworkCore;
using Infrastructure.CloudinaryService;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Create;

public sealed class CreateHairSalonCommand : IRequest<CreatedHairSalonResponse>
    ,
    ICacheRemoverRequest,
    ILoggableRequest,
    ITransactionalRequest
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string? Description { get; set; }


    public string CacheKey => "";

    public string? CacheGroupKey => "GetHairSalons";

    public bool ByPassCache => false;

    public CreateHairSalonCommand()
    {
        Name = string.Empty;
        PhoneNumber = string.Empty;
        Address = string.Empty;
        Email = string.Empty;
        Description = string.Empty;
       

    }
}

internal sealed class CreateHairSalonCommandHandler(
    IHairSalonRepository hairSalonRepository,
    IMapper mapper
   // HairSalonBusinessRules hairSalonBusinessRules
    ) : IRequestHandler<CreateHairSalonCommand, CreatedHairSalonResponse>
{
    public async Task<CreatedHairSalonResponse> Handle(CreateHairSalonCommand request, CancellationToken cancellationToken)
    {


        HairSalon hairSalon = mapper.Map<HairSalon>(request);
        hairSalon.Id = Guid.NewGuid();

        await hairSalonRepository.AddAsync(hairSalon);

        CreatedHairSalonResponse createdHairSalonResponse = mapper.Map<CreatedHairSalonResponse>(request);
        return createdHairSalonResponse;
    }
}
