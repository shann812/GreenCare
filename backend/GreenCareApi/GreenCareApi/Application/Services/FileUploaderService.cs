using GreenCareApi.Application.Interfaces;
using GreenCareApi.Application.Validators;

namespace GreenCareApi.Application.Services
{
    public class FileUploaderService : IFileUploaderService
    {
        private readonly IWebHostEnvironment _wedHostEnvironment;
        public FileUploaderService(IWebHostEnvironment webHostEnvironment)
        {
            _wedHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveImage(string folderName, IFormFile image)
        {
            ImageValidator.Validate(image);

            var uniqueFileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var folderPath = Path.Combine(_wedHostEnvironment.WebRootPath, "images", folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return $"/images/{folderName}/{uniqueFileName}";
        }

        public void DeleteImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                return;

            var physicalPath = Path.Combine(_wedHostEnvironment.WebRootPath, imagePath.TrimStart('/', '\\'));
            if (File.Exists(physicalPath))
                File.Delete(physicalPath);
        }

        public string GetNoImagePath()
            => "/images/no-image.png";
    }
}
