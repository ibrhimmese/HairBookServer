using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Create;
using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using MediatR;

namespace Application.Features.ProjectFeatures.ServiceRatingsFeatures.Commands.Create;

public class CreateServiceRatingCommand : IRequest<CreatedServiceRatingResponse>
{
    public double Score { get; set; }
    public Guid ServiceId { get; set; }
}

internal sealed class CreateServiceRatingCommandHandler : IRequestHandler<CreateServiceRatingCommand, CreatedServiceRatingResponse>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IServiceRatingRepository _serviceRatingRepository;

    public CreateServiceRatingCommandHandler(IServiceRepository serviceRepository, IServiceRatingRepository serviceRatingRepository)
    {
        _serviceRepository = serviceRepository;
        _serviceRatingRepository = serviceRatingRepository;
    }

    public async Task<CreatedServiceRatingResponse> Handle(CreateServiceRatingCommand request, CancellationToken cancellationToken)
    {
        // Servisi bul
        var service = await _serviceRepository.GetAsync(s => s.Id == request.ServiceId);
        if (service == null)
        {
            throw new Exception("Hizmet Bulunamadı");
        }

        // Yeni bir rating oluştur ve ekle
        var rating = new ServiceRating(request.Score, request.ServiceId);
        await _serviceRatingRepository.AddAsync(rating);

        // Servise rating ekle

        service.AddRating(rating);
        await _serviceRepository.UpdateAsync(service);

        // Response oluştur
        var response = new CreatedServiceRatingResponse
        {
            ServiceId = service.Id,
            AverageRating = service.Rating
        };

        return response;
    }
}
