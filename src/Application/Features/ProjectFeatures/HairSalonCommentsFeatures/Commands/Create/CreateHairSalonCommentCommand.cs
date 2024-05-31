using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Create;
using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;

namespace Application.Features.ProjectFeatures.HairSalonCommentsFeatures.Commands.Create;

public class CreateHairSalonCommentCommand:IRequest<CreatedHairSalonCommentCommandResponse>
{
    public string Message { get; set; }
    public Guid HairSalonId { get; set; }
    public CreateHairSalonCommentCommand()
    {
        Message = string.Empty;
    }
}

internal sealed class CreateHairSalonCommentCommandHandler(
    IHairSalonCommentRepository hairSalonCommentRepository,
    IHairSalonRepository hairSalonRepository,
    IMapper mapper
    ) : IRequestHandler<CreateHairSalonCommentCommand, CreatedHairSalonCommentCommandResponse>
{
    public async Task<CreatedHairSalonCommentCommandResponse> Handle(CreateHairSalonCommentCommand request, CancellationToken cancellationToken)
    {
        var hairSalon = await hairSalonRepository.GetAsync(s => s.Id == request.HairSalonId);
        if (hairSalon == null)
        {
            throw new Exception("Kuaför Bulunamadı");
        }
        HairSalonComment comment = mapper.Map<HairSalonComment>(request);
        comment.Id = Guid.NewGuid();

        await hairSalonCommentRepository.AddAsync(comment);

        CreatedHairSalonCommentCommandResponse response = mapper.Map<CreatedHairSalonCommentCommandResponse>(request);

        return response;

    }
}
