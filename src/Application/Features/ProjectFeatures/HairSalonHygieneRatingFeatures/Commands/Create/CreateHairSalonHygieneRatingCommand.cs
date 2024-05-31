using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Create;
using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;

namespace Application.Features.ProjectFeatures.HairSalonHygieneRatingFeatures.Commands.Create;

public class CreateHairSalonHygieneRatingCommand:IRequest<CreateHairSalonHygieneRatingCommandResponse>
{
    public double Score { get; set; }
    public Guid HairSalonId { get; set; }
}

internal sealed class CreateHairSalonHygieneRatingCommandHandler : IRequestHandler<CreateHairSalonHygieneRatingCommand, CreateHairSalonHygieneRatingCommandResponse>
{
    private readonly IHairSalonRepository _hairSalonRepository;
    private readonly IHairSalonHygieneRatingRepository _ratingRepository;
    private readonly IMapper _mapper;

    public CreateHairSalonHygieneRatingCommandHandler(IHairSalonRepository hairSalonRepository, IHairSalonHygieneRatingRepository ratingRepository, IMapper mapper)
    {
        _hairSalonRepository = hairSalonRepository;
        _ratingRepository = ratingRepository;
        _mapper = mapper;
    }

    public async Task<CreateHairSalonHygieneRatingCommandResponse> Handle(CreateHairSalonHygieneRatingCommand request, CancellationToken cancellationToken)
    {
        // Servisi bul
        var hairSalon = await _hairSalonRepository.GetAsync(s => s.Id == request.HairSalonId);
        if (hairSalon == null)
        {
            throw new Exception("Salon Bulunamadı");
        }

        // Yeni bir rating oluştur ve ekle
        var rating = new HairSalonHygieneRating(request.Score, request.HairSalonId);
        await _ratingRepository.AddAsync(rating);

        // Servise rating ekle

        hairSalon.AddRating(rating);
        await _hairSalonRepository.UpdateAsync(hairSalon);

        var response = _mapper.Map<CreateHairSalonHygieneRatingCommandResponse>(rating);

        return response;
    }
}
