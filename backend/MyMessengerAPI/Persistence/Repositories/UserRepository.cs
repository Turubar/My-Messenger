using Application.Interfaces.Repositories;
using Core.Models;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyMessengerDbContext _context;

        public UserRepository(MyMessengerDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Add(User user)
        {
            try
            {
                var userEntity = new UserEntity()
                {
                    Id = user.Id,
                    Login = user.Login,
                    PasswordHash = user.PasswordHash,
                    RegisteredDate = user.RegisteredDate,
                };

                await _context.Users.AddAsync(userEntity);
                await _context.SaveChangesAsync();

                return Result.Success();
            }
            catch
            {
                return Result.Failure("Что-то пошло не так...");
            }
        }

        public async Task<Result<User>> GetByLogin(string login)
        {
            try
            {
                var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login);

                if (userEntity != null)
                    return User.Create(userEntity.Id, userEntity.Login, userEntity.PasswordHash, userEntity.RegisteredDate);
                else
                    return Result.Failure<User>("Пользователь не найден");
            }
            catch
            {
                return Result.Failure<User>("Что-то пошло не так...");
            }
        }
    }
}
