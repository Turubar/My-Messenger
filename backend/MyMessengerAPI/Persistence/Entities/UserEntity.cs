using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public DateTime RegisteredDate { get; set; }

        public Guid ProfileId { get; set; }

        public ProfileEntity? Profile { get; set; }
    }
}
