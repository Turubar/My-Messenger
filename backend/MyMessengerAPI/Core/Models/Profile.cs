using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Profile
    {
        // Публичные константы (для валидации и атрибутов dto)

        public const int MIN_DISPLAYNAME_LENGTH = 2;
        public const int MAX_DISPLAYNAME_LENGTH = 30;

        public const int MAX_STATUS_LENGTH = 50;

        public const int MAX_DESCRIPTION_LENGTH = 2000;

        public const int MAX_SEARCHTAG_LENGTH = 20;

        // ---

        // Приватный конструктор
        private Profile(Guid id, string displayName, string status, string description, string searchTag, Avatar? image, User? user)
        {
            Id = id;
            DisplayName = displayName;
            Status = status;
            Description = description;
            SearchTag = searchTag; 
            Avatar = image;
            User = user;
        }

        // Свойства модели

        public Guid Id { get; }

        public string DisplayName { get; }

        public string Status { get; }

        public string Description { get; }

        public string SearchTag { get; }

        public Avatar? Avatar { get; }

        public User? User { get; }

        // ---

        // Публичный статический метод для валидации и создания модели UserProfile
        public static Result<Profile> Create(Guid id, string displayName, string status, string description, string searchTag, Avatar? avatar, User? user)
        {
            // Валидация свойств

            if (string.IsNullOrEmpty(displayName) || displayName.Length < MIN_DISPLAYNAME_LENGTH || displayName.Length > MAX_DISPLAYNAME_LENGTH)
                return Result.Failure<Profile>($"Длина имени должна быть [{MIN_DISPLAYNAME_LENGTH} - {MAX_DISPLAYNAME_LENGTH}] символов");

            if (status.Length > MAX_STATUS_LENGTH)
                return Result.Failure<Profile>($"Длина статуса должна быть не больше [{MAX_DISPLAYNAME_LENGTH}] символов");

            if (description.Length > MAX_DESCRIPTION_LENGTH)
                return Result.Failure<Profile>($"Длина описания должна быть не больше [{MAX_DESCRIPTION_LENGTH}] символов");

            if (searchTag.Length > MAX_SEARCHTAG_LENGTH)
                return Result.Failure<Profile>($"Длина поискового тега должна быть не больше [{MAX_SEARCHTAG_LENGTH}] символов");

            // ---

            // Создание UserProfile

            var userProfile = new Profile(id, displayName, status, description, searchTag, avatar, user);

            return Result.Success(userProfile);

            // ---
        }
    }
}
