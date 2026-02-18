namespace GreenCareApi.Application.Interfaces
{
    public interface IFileUploaderService
    {
        Task<string> SaveImage(string folderName, IFormFile img);
        void DeleteImage(string imgPath);
        string GetNoImagePath();
    }
}
