﻿using CSharpFunctionalExtensions;
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

        public const int MIN_SEARCHTAG_LENGTH = 2;
        public const int MAX_SEARCHTAG_LENGTH = 20;

        // ---

        // Приватный конструктор
        private UserProfile(Guid id, string displayName, string status, string description, string searchTag, ImageProfile? image, User? user)
        {
            Id = id;
            DisplayName = displayName;
            Status = status;
            Description = description;
            SearchTag = searchTag; 
            Image = image;
            User = user;
        }

        // Свойства модели

        public Guid Id { get; }

        public string DisplayName { get; }

        public string Status { get; }

        public string Description { get; }

        public string SearchTag { get; }

        public ImageProfile? Image { get; }

        public User? User { get; }

        // ---

        // Публичный статический метод для валидации и создания модели UserProfile
        public static Result<UserProfile> Create(Guid id, string displayName, string status, string description, string searchTag, ImageProfile? image, User? user)
        {
            // Валидация свойств

            if (string.IsNullOrEmpty(displayName) || displayName.Length < MIN_DISPLAYNAME_LENGTH || displayName.Length > MAX_DISPLAYNAME_LENGTH)
                return Result.Failure<UserProfile>($"Длина имени должна быть [{MIN_DISPLAYNAME_LENGTH} - {MAX_DISPLAYNAME_LENGTH}] символов");

            if (status.Length > MAX_STATUS_LENGTH)
                return Result.Failure<UserProfile>($"Длина статуса должна быть не больше [{MAX_DISPLAYNAME_LENGTH}] символов");

            if (description.Length > MAX_DESCRIPTION_LENGTH)
                return Result.Failure<UserProfile>($"Длина описания должна быть не больше [{MAX_DESCRIPTION_LENGTH}] символов");

            if (string.IsNullOrEmpty(searchTag) || searchTag.Length < MIN_SEARCHTAG_LENGTH || searchTag.Length > MAX_SEARCHTAG_LENGTH)
                return Result.Failure<UserProfile>($"Длина тега должна быть [{MIN_SEARCHTAG_LENGTH} - {MAX_SEARCHTAG_LENGTH}] символов");

            // ---

            // Создание UserProfile

            var userProfile = new UserProfile(id, displayName, status, description, searchTag, image, user);

            return Result.Success(userProfile);

            // ---
        }
    }
}
