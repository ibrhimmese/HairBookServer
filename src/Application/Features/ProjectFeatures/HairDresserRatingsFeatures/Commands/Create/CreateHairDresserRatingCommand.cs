using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;

namespace Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Create;

public class CreateHairDresserRatingCommand:IRequest<CreatedHairDresserRatingResponse>
{
    public double Score { get; set; }
    public Guid HairDresserId { get; set; }
}

internal sealed class CreateHairDresserRatingCommandHandler : IRequestHandler<CreateHairDresserRatingCommand, CreatedHairDresserRatingResponse>
{
    private readonly IHairDresserRepository _hairDresserRepository;
    private readonly IHairDresserRatingRepository _ratingRepository;
    private readonly IMapper _mapper;

    public CreateHairDresserRatingCommandHandler(IHairDresserRepository hairDresserRepository, IHairDresserRatingRepository ratingRepository, IMapper mapper)
    {
        _hairDresserRepository = hairDresserRepository;
        _ratingRepository = ratingRepository;
        _mapper = mapper;
    }

    public async Task<CreatedHairDresserRatingResponse> Handle(CreateHairDresserRatingCommand request, CancellationToken cancellationToken)
    {
        // Servisi bul
        var hairDresser = await _hairDresserRepository.GetAsync(s => s.Id == request.HairDresserId);
        if (hairDresser == null)
        {
            throw new Exception("Kuaför Bulunamadı");
        }

        // Yeni bir rating oluştur ve ekle
        var rating = new HairDresserRating(request.Score, request.HairDresserId);
        await _ratingRepository.AddAsync(rating);

        // Servise rating ekle

        hairDresser.AddRating(rating);
        await _hairDresserRepository.UpdateAsync(hairDresser);

        var response = _mapper.Map<CreatedHairDresserRatingResponse>(rating);

        return response;
    }
}
