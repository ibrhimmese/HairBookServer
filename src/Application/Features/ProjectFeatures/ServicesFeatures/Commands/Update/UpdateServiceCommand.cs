using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;

namespace Application.Features.ProjectFeatures.ServicesFeatures.Commands.Update;

public sealed class UpdateServiceCommand:IRequest<UpdatedServiceCommandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Duration { get; set; }
    public string? Description { get; set; }
    public Guid HairSalonId { get; set; }
}

internal sealed class UpdateServiceCommandHandler(
    IServiceRepository serviceRepository,
    IMapper mapper
    ) : IRequestHandler<UpdateServiceCommand, UpdatedServiceCommandResponse>
{
    public async Task<UpdatedServiceCommandResponse> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        Service? service = await serviceRepository.GetAsync(p=>p.Id == request.Id);

        if (service is null) throw new Exception("Servis Bulunamadı");

        service = mapper.Map(request,service);

       var updatedService = await serviceRepository.UpdateAsync(service,cancellationToken);
        UpdatedServiceCommandResponse response = mapper.Map<UpdatedServiceCommandResponse>(updatedService);
        return response;
    }
}
