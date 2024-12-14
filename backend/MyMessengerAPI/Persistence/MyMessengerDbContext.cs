using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class MyMessengerDbContext(DbContextOptions<MyMessengerDbContext> options) 
        : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ProfileEntity> Profiles { get; set; }

        public DbSet<AvatarEntity> Avatars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AvatarConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        }
    }
}
