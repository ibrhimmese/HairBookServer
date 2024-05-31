using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Update;
using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Update;

public class UpdateHairSalonCommand:IRequest<UpdatedHairSalonResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string? Description { get; set; }
    public UpdateHairSalonCommand()
    {
        Name = string.Empty;
        PhoneNumber = string.Empty;
        Address = string.Empty;
        Email = string.Empty;
        Description = string.Empty;
    }
}

internal sealed class UpdateHairSalonCommandHandler(
    IHairSalonRepository hairSalonRepository,
    IMapper mapper
    ) : IRequestHandler<UpdateHairSalonCommand, UpdatedHairSalonResponse>
{
    public async Task<UpdatedHairSalonResponse> Handle(UpdateHairSalonCommand request, CancellationToken cancellationToken)
    {
        HairSalon? hairSalon = await hairSalonRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
        if (hairSalon is null) throw new Exception("Kullanıcı Bulunamadı");

        hairSalon = mapper.Map(request, hairSalon);

        var updatedHairDresser = await hairSalonRepository.UpdateAsync(hairSalon, cancellationToken: cancellationToken);

        UpdatedHairSalonResponse response = mapper.Map<UpdatedHairSalonResponse>(updatedHairDresser);

        return response;
    }
}
