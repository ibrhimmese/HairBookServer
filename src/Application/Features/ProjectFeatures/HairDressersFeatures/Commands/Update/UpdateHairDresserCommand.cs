using Application.Services.Repositories.ProjectRepositories;
using Application.Services.Repositories.RolBasedAccessControlRepositories.Repositories;
using AutoMapper;
using Domain.Entities.Project;
using Domain.Entities.RolBasedAccessControlEntities;
using MediatR;
using System.Drawing.Drawing2D;

namespace Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Update;

public sealed class UpdateHairDresserCommand:IRequest<UpdatedHairDresserResponse>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public Guid HairSalonId { get; set; }
    public UpdateHairDresserCommand()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
    }
}

internal sealed class UpdateHairDresserCommandHandler(
    IHairDresserRepository hairDresserRepository,
    IMapper mapper
    ) : IRequestHandler<UpdateHairDresserCommand, UpdatedHairDresserResponse>
{
    public async Task<UpdatedHairDresserResponse> Handle(UpdateHairDresserCommand request, CancellationToken cancellationToken)
    {
        HairDresser? hairDresser = await hairDresserRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
        if (hairDresser is null) throw new Exception("Kullanıcı Bulunamadı");

        hairDresser = mapper.Map(request, hairDresser);

        var updatedHairDresser = await hairDresserRepository.UpdateAsync(hairDresser, cancellationToken: cancellationToken);

        UpdatedHairDresserResponse response = mapper.Map<UpdatedHairDresserResponse>(updatedHairDresser);

        return response;
    }
}
