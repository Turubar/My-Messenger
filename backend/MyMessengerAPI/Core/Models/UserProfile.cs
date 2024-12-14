using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserProfile
    {
        // Публичные константы (для валидации и атрибутов dto)

        public const int MIN_DISPLAYNAME_LENGTH = 2;
        public const int MAX_DISPLAYNAME_LENGTH = 20;

        public const int MAX_STATUS_LENGTH = 50;

        public const int MAX_DESCRIPTION_LENGTH = 2000;

        // ---

        // Приватный конструктор
        private UserProfile(Guid userId, string displayName, string status, string description, ImageProfile? image)
        {
            UserId = userId;
            DisplayName = displayName;
            Status = status;
            Description = description;
            Image = image;
        }

        // Свойства модели

        public Guid UserId { get; set; }

        public string DisplayName { get; } = "Новый пользователь";

        public string Status { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public ImageProfile? Image { get; }

        // ---

        // Публичный статический метод для валидации и создания модели UserProfile
        public static Result<UserProfile> Create(Guid userId, string displayName, string status, string description, ImageProfile? image)
        {
            // Валидация свойств

            if (string.IsNullOrEmpty(displayName) || displayName.Length < MIN_DISPLAYNAME_LENGTH || displayName.Length > MAX_DISPLAYNAME_LENGTH)
                return Result.Failure<UserProfile>($"Длина имени должна быть [{MIN_DISPLAYNAME_LENGTH} - {MAX_DISPLAYNAME_LENGTH}] символов");

            if (status.Length > MAX_STATUS_LENGTH)
                return Result.Failure<UserProfile>($"Длина статуса должна быть не больше [{MAX_DISPLAYNAME_LENGTH}] символов");

            if (description.Length > MAX_DESCRIPTION_LENGTH)
                return Result.Failure<UserProfile>($"Длина описания должна быть не больше [{MAX_DESCRIPTION_LENGTH}] символов");

            // ---

            // Создание UserProfile

            var userProfile = new UserProfile(userId, displayName, status, description, image);

            return Result.Success<UserProfile>(userProfile);

            // ---
        }
    }
}
