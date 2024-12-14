using CSharpFunctionalExtensions;

namespace Core.Models
{
    public class Avatar
    {
        // Приватный конструктор
        public Avatar(Guid id, string fileName)
        {
            Id = id;
            FileName = fileName;
        }

        // Свойства модели

        public Guid Id { get; }

        public string FileName { get; }

        // ---

        // Публичный статический метод для валидации и создания модели ImageProfile
        public static Result<Avatar> Create(Guid id, string fileName)
        {
            // Валидация свойств

            if (string.IsNullOrEmpty(fileName))
                return Result.Failure<Avatar>("Имя файла не может быть пустым");

            // ---

            // Создание ImageProfile

            var imageProfile = new Avatar(id, fileName);

            return Result.Success(imageProfile);

            // ---
        }
    }
}