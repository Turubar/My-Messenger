using CSharpFunctionalExtensions;

namespace Core.Models
{
    public class ImageProfile
    {
        public ImageProfile(string fileName)
        {
            FileName = fileName;
        }

        public Guid ProfileId { get; set; }

        public string FileName { get; set; } = string.Empty;

        public static Result<ImageProfile> Create(string fileName)
        {
            // Валидация свойств

            if (string.IsNullOrEmpty(fileName))
                return Result.Failure<ImageProfile>("Имя файла не может быть пустым");

            // ---

            // Создание ImageProfile

            var imageProfile = new ImageProfile(fileName);

            return Result.Success(imageProfile);

            // ---
        }
    }
}