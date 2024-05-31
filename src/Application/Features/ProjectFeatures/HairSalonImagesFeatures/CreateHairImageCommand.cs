using Application.Services.Repositories.ClodinaryService;
using Application.Services.Repositories.ProjectRepositories;
using Domain.Entities.Project;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ProjectFeatures.HairSalonImagesFeatures;

public class CreateHairImageCommand : IRequest<HairSalonImage>
{
    public IFormFile? File { get; set; }
    public Guid HairSalonId { get; set; }

}

public class CreateHairImageCommandHandler : IRequestHandler<CreateHairImageCommand, HairSalonImage>
{
    private readonly IPhotoService _photoService;
    private readonly IHairSalonImageRepository _hairSalonImageRepository;

    public CreateHairImageCommandHandler(IPhotoService photoService, IHairSalonImageRepository hairSalonImageRepository)
    {
        _photoService = photoService;
        _hairSalonImageRepository = hairSalonImageRepository;
    }

    public async Task<HairSalonImage> Handle(CreateHairImageCommand request, CancellationToken cancellationToken)
    {
        var uploadResult = await _photoService.UploadImageAsync(request.File!, request.HairSalonId);
        if (uploadResult is null) throw new Exception("Fotoğraf Yüklenemedi");

        HairSalonImage hairSalonImage = new()
        {
            ImageUrl = uploadResult.ImageUrl,
            PublicId = uploadResult.PublicId,
            HairSalonId = request.HairSalonId
        };
        await _hairSalonImageRepository.AddAsync(hairSalonImage);
        return hairSalonImage;

        //var image = await _photoService.UploadImageAsync(request.File, request.HairSalonId);
        //return image;
    }
}

