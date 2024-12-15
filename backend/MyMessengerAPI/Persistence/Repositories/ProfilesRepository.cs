using Application.Interfaces.Repositories;
using Core.Models;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Persistence.Repositories
{
    public class ProfilesRepository : IProfileRepository
    {
        private readonly MyMessengerDbContext _dbContext;

        public ProfilesRepository(MyMessengerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Add(Profile profile)
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
                    UserId = profile.User.Id,
                };

                await _dbContext.Profiles.AddAsync(profileEntity);
                await _dbContext.SaveChangesAsync();

                return Result.Success();
            }
            catch
            {
                return Result.Failure("Что-то пошло не так...");
            }
        }

        public async Task<Result<Profile>> GetBySearchTag(string searchTag)
        {
            try
            {
                var profile = await _dbContext.Profiles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.SearchTag == searchTag);

                if (profile != null)
                {
                    Result<Avatar> avatar = null;
                    if (profile.Avatar != null)
                        avatar = Avatar.Create(profile.Avatar.Id, profile.Avatar.FileName);

                    Result<User> user = null;
                    if (profile.User != null)
                        user = User.Create(profile.User.Id, profile.User.Login, profile.User.PasswordHash, profile.User.RegisteredDate);

                    return Profile.Create(profile.Id, profile.DisplayName, profile.Status, profile.Description, profile.SearchTag, avatar.Value, user.Value);
                }
                else
                    return Result.Failure<Profile>("Профиль не найден");
                    
            }
            catch
            {
                return Result.Failure<Profile>("Что-то пошло не так...");
            }
        }
    }
}
