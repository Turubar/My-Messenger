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

        // Получние профиля пользователя по его токену
        public async Task<Result<Profile>> GetProfileByToken(string token)
        {
            var userId = _jwtProvider.GetIdFromToken(token);
            if (userId == Guid.Empty)
                return Result.Failure<Profile>("Не удалось получить Id");

            var profile = await _profileRepository.GetProfileByUserId(userId);
            if (profile.IsSuccess)
                return profile;
            else
                return Result.Failure<Profile>(profile.Error);
        }

        // Получние профиля пользователя по searchTag
        public async Task<Result<Profile>> GetProfileBySearchTag(string searchTag)
        {
            var profile = await _profileRepository.GetProfileBySearchTag(searchTag);
            if (profile.IsSuccess)
                return profile;
            else
                return Result.Failure<Profile>(profile.Error);
        }
    }
}
