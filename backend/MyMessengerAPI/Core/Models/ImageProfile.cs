using CSharpFunctionalExtensions;

namespace Core.Models
{
    public class ImageProfile
    {
        // Приватный конструктор
        public ImageProfile(Guid id, string fileName)
        {
            Id = id;
            FileName = fileName;
        }

        // Свойства модели

        public Guid Id { get; }

        public string FileName { get; }

        // ---

        // Публичный статический метод для валидации и создания модели ImageProfile
        public static Result<ImageProfile> Create(Guid id, string fileName)
        {
            // Валидация свойств

            if (string.IsNullOrEmpty(fileName))
                return Result.Failure<ImageProfile>("Имя файла не может быть пустым");

            // ---

            // Создание ImageProfile

            var imageProfile = new ImageProfile(id, fileName);

            return Result.Success(imageProfile);

            // ---
        }
    }
}