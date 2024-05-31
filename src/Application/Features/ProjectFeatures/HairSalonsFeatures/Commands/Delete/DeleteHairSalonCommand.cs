using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using CachingBehavior;
using Domain.Entities.Project;
using IMFrameworkCore;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Delete;

public sealed record DeleteHairSalonCommand(Guid Id) : IRequest<DeletedHairSalonCommandResponse>, ILoggableRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public string CacheKey => "";

    public string? CacheGroupKey => "GetHairSalons";

    public bool ByPassCache => false;
}

internal sealed class DeleteHairSalonCommandHandler(
    IHairSalonRepository hairSalonRepository,
    IMapper mapper
    ) : IRequestHandler<DeleteHairSalonCommand, DeletedHairSalonCommandResponse>
{
    public async Task<DeletedHairSalonCommandResponse> Handle(DeleteHairSalonCommand request, CancellationToken cancellationToken)
    {
        HairSalon? hairSalon = await hairSalonRepository.GetAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
        if( hairSalon is null )
        {
            throw new BusinessException("Salon Bulunamadı");
        }

        var deletedHairSalon = await hairSalonRepository.DeleteAsync(hairSalon, cancellationToken: cancellationToken);

        DeletedHairSalonCommandResponse response = mapper.Map<DeletedHairSalonCommandResponse>(deletedHairSalon);
        return response;
    }
}
