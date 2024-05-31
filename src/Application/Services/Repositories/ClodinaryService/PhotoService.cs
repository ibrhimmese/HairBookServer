using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Domain.Entities.Project;

namespace Application.Services.Repositories.ClodinaryService;

public class PhotoService : IPhotoService
{
    private readonly Cloudinary _cloudinary;

    public PhotoService(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<HairSalonImage> UploadImageAsync(IFormFile file, Guid hairSalonId)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentNullException(nameof(file), "File is empty");

        using (var stream = file.OpenReadStream())
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "hair-salon-images",
                Transformation = new Transformation().Width(500).Height(500).Crop("fill")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
                throw new Exception(uploadResult.Error.Message);

            var imageUrl = uploadResult.SecureUrl.ToString();
            var publicId = uploadResult.PublicId;

            var hairSalonImage = new HairSalonImage(imageUrl, publicId, hairSalonId);

            return hairSalonImage;
        }
    }

    public async Task<bool> DeleteImageAsync(string publicId)
    {
        if (string.IsNullOrWhiteSpace(publicId))
            return false;

        var deletionParams = new DeletionParams(publicId);

        var deletionResult = await _cloudinary.DestroyAsync(deletionParams);

        if (deletionResult.Error != null)
            throw new Exception(deletionResult.Error.Message);

        return true;
    }
}

