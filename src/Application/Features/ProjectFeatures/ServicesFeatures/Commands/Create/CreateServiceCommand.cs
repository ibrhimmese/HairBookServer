using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using CachingBehavior;
using Domain.Entities.Project;
using MediatR;

namespace Application.Features.ProjectFeatures.ServicesFeatures.Commands.Create;

public sealed class CreateServiceCommand:IRequest<CreatedServiceResponse>,ICacheRemoverRequest
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Duration { get; set; }
    public string? Description { get; set; }
    public Guid HairSalonId { get; set; }

    public string CacheKey => "";

    public string? CacheGroupKey => "GetHairSalons";

    public bool ByPassCache => false;

    public CreateServiceCommand()
    {
        Name = string.Empty;
        Price = 0;
        Duration = 0;
        Description = string.Empty;
    }
}

internal sealed class CreateServiceCommandHandler(
    IServiceRepository serviceRepository,
    IMapper mapper,
    IHairSalonRepository hairSalonRepository
    ) : IRequestHandler<CreateServiceCommand, CreatedServiceResponse>
{
    public async Task<CreatedServiceResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        HairSalon? hairSalon = await hairSalonRepository.GetAsync(p=>request.HairSalonId==p.Id);
        if(hairSalon is null)
        {
            throw new Exception("Kuaför Bulunamadı");
        }
        Service service = mapper.Map<Service>(request);
        service.Id = Guid.NewGuid();

        await serviceRepository.AddAsync(service);

        CreatedServiceResponse response = mapper.Map<CreatedServiceResponse>(request);

        return response;

    }
}
