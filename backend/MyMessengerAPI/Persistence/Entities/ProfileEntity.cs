using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class ProfileEntity
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string SearchTag { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        public UserEntity User { get; set; } = null!;

        public AvatarEntity? Avatar { get; set; }
    }
}
