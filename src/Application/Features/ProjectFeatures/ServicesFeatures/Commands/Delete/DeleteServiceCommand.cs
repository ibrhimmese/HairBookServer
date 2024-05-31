using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using IMFrameworkCore;
using MediatR;

namespace Application.Features.ProjectFeatures.ServicesFeatures.Commands.Delete;

public class DeleteServiceCommand:IRequest<DeletedServiceCommandResponse>
{
    public Guid Id { get; set; }
}

internal sealed class DeleteServiceCommandHandler(
    IServiceRepository serviceRepository,
    IMapper mapper
    ) : IRequestHandler<DeleteServiceCommand, DeletedServiceCommandResponse>
{
    public async Task<DeletedServiceCommandResponse> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        Service? service = await serviceRepository.GetAsync(p=>p.Id==request.Id);
        if (service is null) throw new Exception("Servis Bulunamadı");

        await serviceRepository.DeleteAsync(service, cancellationToken: cancellationToken);

        DeletedServiceCommandResponse response = mapper.Map<DeletedServiceCommandResponse>(service);

        return response;
    }
}
