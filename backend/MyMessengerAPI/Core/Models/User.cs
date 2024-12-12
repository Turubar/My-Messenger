using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User
    {
        // Публичные константы (для валидации и атрибутов dto)

        public const int MIN_LOGIN_LENGTH = 4;
        public const int MAX_LOGIN_LENGTH = 20;

        public const int MIN_PASSWORD_LENGTH = 8;
        public const int MAX_PASSWORD_LENGTH = 30;

        // ---

        // Приватный конструктор
        private User(Guid id, string login, string passwordHash, DateTime registeredDate)
        {
            Id = id;
            Login = login;
            PasswordHash = passwordHash;
            RegisteredDate = registeredDate;
        }

        // Свойства модели

        public Guid Id { get; }

        public string Login { get; }

        public string PasswordHash { get; }

        public DateTime RegisteredDate { get; }

        // ---

        // Публичный статический метод для валидации и создания модели User
        public static Result<User> Create(Guid id, string login, string passwordHash, DateTime registeredDate)
        {
            // Валидация свойств

            if (string.IsNullOrEmpty(login) || login.Length < MIN_LOGIN_LENGTH || login.Length > MAX_LOGIN_LENGTH)
            {
                return Result.Failure<User>($"Длина логина должна быть {MIN_LOGIN_LENGTH} - {MAX_LOGIN_LENGTH} символов");
            }

            // Проверяем на null, но не проверяем длину, так как это хэш
            if (string.IsNullOrEmpty(login))
            {
                return Result.Failure<User>($"Длина пароля должна быть {MIN_PASSWORD_LENGTH} - {MAX_PASSWORD_LENGTH} символов");
            }

            // ---

            // Создание User

            var user = new User(id, login, passwordHash, registeredDate);

            return Result.Success(user);

            // ---
        }
    }
}
