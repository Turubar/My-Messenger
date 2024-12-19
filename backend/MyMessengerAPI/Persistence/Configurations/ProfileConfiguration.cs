using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder
                .ToTable("Profiles")
                .HasKey(p => p.Id);

            builder.Property(p => p.DisplayName)
                .HasMaxLength(Profile.MAX_DISPLAYNAME_LENGTH);

            builder.Property(p => p.Status)
                .HasMaxLength(Profile.MAX_STATUS_LENGTH);

            builder.Property(p => p.Description)
                .HasMaxLength(Profile.MAX_DESCRIPTION_LENGTH);

            builder.Property(p => p.SearchTag)
                .HasMaxLength(Profile.MAX_SEARCHTAG_LENGTH);

            builder
                .HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<ProfileEntity>(p => p.UserId)
                .IsRequired();

            builder
                .HasOne(p => p.Avatar)
                .WithOne(a => a.Profile);
        }
    }
}
