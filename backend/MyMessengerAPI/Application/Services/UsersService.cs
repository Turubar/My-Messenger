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
        private readonly IProfileRepository _prfoileRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ISearchTagGenerator _searchTagGenerator;

        public UsersService(IUserRepository userRepository, IProfileRepository profileRepository, IPasswordHasher passwordHasher, ISearchTagGenerator searchTagGenerator)
        {
            _userRepository = userRepository;
            _prfoileRepository = profileRepository;
            _passwordHasher = passwordHasher;
            _searchTagGenerator = searchTagGenerator;
        }

        // Регистарция
        public async Task<Result> Registration(string login, string password)
        {
            // Создание нового пользователя

            // Хэшируем пароль
            var hashedPassword = _passwordHasher.Generate(password);

            // Создаем пользователя
            var newUser = User.Create(Guid.NewGuid(), login, hashedPassword, DateTime.UtcNow);
            if (newUser.IsFailure) 
                return Result.Failure<User>(newUser.Error);

            // Проверяем логин на уникальность
            var existingUser = await _userRepository.GetByLogin(newUser.Value.Login);
            if (existingUser.IsSuccess) 
                return Result.Failure<User>("Этот логин уже занят");

            // ---

            // Создние профиля для нового пользователя

            var newProfile = Profile.Create(Guid.NewGuid(), "Новый пользователь", "", "", "", null, newUser.Value);
            if (newProfile.IsFailure)
                return Result.Failure<Profile>(newProfile.Error);

            // ---

            // Добавляем пользователя и его профиль в базу данных

            var user = await _userRepository.Add(newUser.Value);
            if (user.IsFailure) 
                return Result.Failure<User>(user.Error);

            var profile = await _prfoileRepository.Add(newProfile.Value);
            if (profile.IsFailure)
                return Result.Failure<Profile>(profile.Error);

            return newUser;

            // ---
        }
    }
}
