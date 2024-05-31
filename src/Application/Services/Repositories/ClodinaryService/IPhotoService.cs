using CloudinaryDotNet.Actions;
using Domain.Entities.Project;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Repositories.ClodinaryService;

public interface IPhotoService
{
    Task<HairSalonImage> UploadImageAsync(IFormFile file, Guid hairSalonId);
    Task<bool> DeleteImageAsync(string publicId);
}