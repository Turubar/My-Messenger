using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class ImageProfileEntity
    {
        public Guid Id { get; set; }

        public string FileName { get; set; } = string.Empty;

        public Guid ProfileId { get; set; }

        public UserProfileEntity? ProfileEntity { get; set; }
    }
}
