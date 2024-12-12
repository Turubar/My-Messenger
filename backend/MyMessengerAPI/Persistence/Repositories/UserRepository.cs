using Application.Interfaces.Repositories;
using Core.Models;
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

        public Task Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
