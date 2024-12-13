using Application.Interfaces.Authentication;
using Application.Interfaces.Repositories;
using Core.Models;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UsersService(IUserRepository userRepository ,IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        // Регистарция
        public async Task<Result<User>> Registration(string login, string password)
        {
            // Хэшируем пароль
            var hashedPassword = _passwordHasher.Generate(password);

            // Создаем нового пользователя
            var newUser = User.Create(Guid.NewGuid(), login, hashedPassword, DateTime.UtcNow);
            if (newUser.IsFailure) 
                return Result.Failure<User>(newUser.Error);

            // Проверяем логин на уникальность
            var existingUser = await _userRepository.GetByLogin(newUser.Value.Login);
            if (existingUser.IsSuccess) 
                return Result.Failure<User>("Этот логин уже занят");


            // Добавляем пользователя в базу данных
            var user = await _userRepository.Add(newUser.Value);
            if (user.IsFailure) 
                return Result.Failure<User>(user.Error);

            return newUser;
        }
    }
}
