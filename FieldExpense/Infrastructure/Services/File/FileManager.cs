
using Application.Services.FileService;
using Microsoft.AspNetCore.Http;



namespace Infrastructure.Services.File
{
    public class FileManager : IFileService
    {
        private readonly string _webRootPath;

        public FileManager(string webRootPath)
        {
            _webRootPath = webRootPath;
        }

        public async Task<string> UploadAsync(IFormFile file, string folder)
        {
            string uploadsFolder = Path.Combine(_webRootPath, folder);
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Path.Combine(folder, uniqueFileName).Replace("\\", "/");
        }

        public void Delete(string filePath)
        {
            string fullPath = Path.Combine(_webRootPath, filePath);
            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);

        }

    }
}
