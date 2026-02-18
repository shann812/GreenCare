namespace GreenCareApi.Application.Validators
{
    public static class ImageValidator
    {
        public static void Validate(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                //log
                throw new NullReferenceException("Image file is empty");
            }

            if (!image.ContentType.StartsWith("image/"))
                throw new ArgumentException("Wrong file type");

            if (image.Length > 5 * 1024 * 1024)
                throw new ArgumentException("File size is too big (5MB max)");
        }
    }
}
