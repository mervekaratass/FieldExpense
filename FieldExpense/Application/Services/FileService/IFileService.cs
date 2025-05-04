using Microsoft.AspNetCore.Http;

namespace Application.Services.FileService
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file, string folder);
        void Delete(string filePath);
    }

}
