using Application.Interfaces.Repositories;
using Core.Models;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Repositories
{
    public class ProfilesRepository : IProfileRepository
    {
        private readonly MyMessengerDbContext _dbContext;

        public ProfilesRepository(MyMessengerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> AddProfile(Profile profile)
        {
            try
            {
                var profileEntity = new ProfileEntity()
                {
                    Id = profile.Id,
                    DisplayName = profile.DisplayName,
                    Status = profile.Status,
                    Description = profile.Description,
                    SearchTag = profile.SearchTag,
                    UserId = profile.User.Id
                };

                await _dbContext.Profiles.AddAsync(profileEntity);
                await _dbContext.SaveChangesAsync();

                return Result.Success();
            }
            catch
            {
                return Result.Failure("Что-то пошло не так, попробуйте позже");
            }
        }

        public async Task<Result<Profile>> GetProfileByUserId(Guid userId)
        {
            try
            {
                var profile = await _dbContext.Profiles
                    .AsNoTracking()
                    .Include(p => p.User)
                    .Include(p => p.Avatar)
                    .FirstOrDefaultAsync(p => p.UserId == userId);

                // Маппинг и возврат результата
                if (profile != null)
                {
                    var user = User.Create(profile.User.Id, profile.User.Login, profile.User.PasswordHash, profile.User.RegisteredDate);

                    if (profile.Avatar != null)
                    {
                        Result<Avatar> avatar = Avatar.Create(profile.Avatar.Id, profile.Avatar.FileName);
                        return Profile.Create(profile.Id, profile.DisplayName, profile.Status, profile.Description, profile.SearchTag, avatar.Value, user.Value);
                    }
                    else
                        return Profile.Create(profile.Id, profile.DisplayName, profile.Status, profile.Description, profile.SearchTag, null, user.Value);
                }
                else
                    return Result.Failure<Profile>("Профиль не найден");
            }
            catch
            {
                // логирование ошибки

                return Result.Failure<Profile>("Что-то пошло не так, попробуйте позже");
            }
        }

        public async Task<Result<Profile>> GetProfileBySearchTag(string searchTag)
        {
            try
            {
                var profile = await _dbContext.Profiles
                    .AsNoTracking()
                    .Include(p => p.User)
                    .Include(p => p.Avatar)
                    .FirstOrDefaultAsync(p => p.SearchTag == searchTag);

                // Маппинг и возврат результата
                if (profile != null)
                {
                    var user = User.Create(profile.User.Id, profile.User.Login, profile.User.PasswordHash, profile.User.RegisteredDate);

                    if (profile.Avatar != null)
                    {
                        Result<Avatar> avatar = Avatar.Create(profile.Avatar.Id, profile.Avatar.FileName);
                        return Profile.Create(profile.Id, profile.DisplayName, profile.Status, profile.Description, profile.SearchTag, avatar.Value, user.Value);
                    }
                    else 
                        return Profile.Create(profile.Id, profile.DisplayName, profile.Status, profile.Description, profile.SearchTag, null, user.Value);
                }
                else
                    return Result.Failure<Profile>("Профиль не найден");
            }
            catch
            {
                // логирование ошибки

                return Result.Failure<Profile>("Что-то пошло не так, попробуйте позже");
            }
        }
    }
}
