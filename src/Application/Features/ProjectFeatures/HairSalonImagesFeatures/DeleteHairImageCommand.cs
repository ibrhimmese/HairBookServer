using Application.Services.Repositories.ProjectRepositories;
using MediatR;
using Infrastructure.Responses;
using Application.Services.Repositories.ClodinaryService;

namespace Application.Features.ProjectFeatures.HairSalonImagesFeatures;

public class DeleteHairImageCommand : IRequest<MessageResponse>
{
    public Guid ImageId { get; set; }
}

public class DeleteHairImageCommandHandler : IRequestHandler<DeleteHairImageCommand,MessageResponse>
{
    private readonly IPhotoService _photoService;
    private readonly IHairSalonImageRepository _hairSalonImageRepository;

    public DeleteHairImageCommandHandler(IPhotoService photoService, IHairSalonImageRepository hairSalonImageRepository)
    {
        _photoService = photoService;
        _hairSalonImageRepository = hairSalonImageRepository;
    }

    public async Task<MessageResponse> Handle(DeleteHairImageCommand request, CancellationToken cancellationToken)
    {
        var hairSalonImage = await _hairSalonImageRepository.GetAsync(p=>p.Id==request.ImageId);
        if (hairSalonImage == null) throw new Exception("Resim bulunamadı");

        var deleteResult = await _photoService.DeleteImageAsync(hairSalonImage.PublicId);
        if (!deleteResult) throw new Exception("Resim Cloudinary'den silinemedi");

        await _hairSalonImageRepository.DeleteAsync(hairSalonImage);

        return new("Silme işlemi başarılı");

    }
}
