using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using IMFrameworkCore;
using Infrastructure.Responses;
using MediatR;

namespace Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Delete;

public sealed class DeleteHairDresserRatingCommand:IRequest<MessageResponse>
{
    public Guid Id { get; set; }
}

internal sealed class DeleteHairDresserRatingCommandHandler(
    IHairDresserRatingRepository hairDresserRatingRepository
    ) : IRequestHandler<DeleteHairDresserRatingCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(DeleteHairDresserRatingCommand request, CancellationToken cancellationToken)
    {
        HairDresserRating? hairDresserRating = await hairDresserRatingRepository.GetAsync(p=>p.Id== request.Id);
        if (hairDresserRating is null) throw new BusinessException("Rating Bulunamadı");
        await hairDresserRatingRepository.DeleteAsync(hairDresserRating, cancellationToken: cancellationToken);
        return new("Değerlendirme puanı başarıyla silindi");

    }
}
