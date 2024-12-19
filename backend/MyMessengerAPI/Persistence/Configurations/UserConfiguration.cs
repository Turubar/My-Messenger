using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .ToTable("Users")
                .HasKey(u => u.Id);

            builder.Property(u => u.Login)
                .HasMaxLength(User.MAX_LOGIN_LENGTH);

            builder
                .HasOne(u => u.Profile)
                .WithOne(p => p.User);
        }
    }
}
