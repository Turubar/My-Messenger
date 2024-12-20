using Application.Interfaces.Authentication;
using Application.Interfaces.Repositories;
using Core.Models;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public class ProfilesService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IJwtProvider _jwtProvider;

        public ProfilesService(IProfileRepository profileRepository, IJwtProvider jwtProvider)
        {
            _profileRepository = profileRepository;
            _jwtProvider = jwtProvider;
        }

        // Получние профиля пользователя
        public async Task<Result<Profile>> GetProfile(string token)
        {
            var userId = _jwtProvider.GetIdFromToken(token);
            if (userId == Guid.Empty)
                return Result.Failure<Profile>("Не удалось получить Id");

            var profile = await _profileRepository.GetByUserId(userId);
            if (profile.IsSuccess)
                return profile;
            else
                return Result.Failure<Profile>(profile.Error);
        }
    }
}
