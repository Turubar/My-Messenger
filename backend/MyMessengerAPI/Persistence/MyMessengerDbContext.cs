using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Configurations;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpFunctionalExtensions.Result;

namespace Persistence
{
    public class MyMessengerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MyMessengerDbContext(DbContextOptions<MyMessengerDbContext> options, IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ProfileEntity> Profiles { get; set; }

        public DbSet<AvatarEntity> Avatars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Connection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new AvatarConfiguration());
            //modelBuilder.ApplyConfiguration(new ProfileConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyMessengerDbContext).Assembly);
        }
    }
}
