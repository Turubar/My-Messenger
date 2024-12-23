﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations
{
    public class AvatarConfiguration : IEntityTypeConfiguration<AvatarEntity>
    {
        public void Configure(EntityTypeBuilder<AvatarEntity> builder)
        {
            builder
                .ToTable("Avatars")
                .HasKey(u => u.Id);

            builder
                .HasOne(a => a.Profile)
                .WithOne(p => p.Avatar)
                .HasForeignKey<AvatarEntity>(a => a.ProfileId)
                .IsRequired();
        }
    }
}
