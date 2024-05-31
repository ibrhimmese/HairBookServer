using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;

namespace Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Delete;

public sealed record DeleteHairDresserCommand(Guid Id):IRequest<DeletedHairDresserResponse>;


internal sealed class DeleteHairDresserCommandHandler(
    IHairDresserRepository hairDresserRepository,
    IMapper mapper
    ) : IRequestHandler<DeleteHairDresserCommand, DeletedHairDresserResponse>
{
    public async Task<DeletedHairDresserResponse> Handle(DeleteHairDresserCommand request, CancellationToken cancellationToken)
    {
        HairDresser? hairDresser = await hairDresserRepository.GetAsync(p=>p.Id==request.Id);
        if (hairDresser is null) throw new Exception("Kuaför bulunamadı");

        await hairDresserRepository.DeleteAsync(hairDresser, cancellationToken:cancellationToken);
        DeletedHairDresserResponse response = mapper.Map<DeletedHairDresserResponse>(hairDresser);

        return response;
    }
}
