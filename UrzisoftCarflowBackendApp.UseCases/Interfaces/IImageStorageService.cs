using Microsoft.AspNetCore.Http;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IImageStorageService
    {
        Task<string> UploadImage(string name, IFormFile file, string containerName);
        Task DeleteImage(string name, string containerName);
    }
}
