using Core.Models;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Result> AddUser(User user);

        Task<Result<User>> GetUserByLogin(string login);
    }
}
