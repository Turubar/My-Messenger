using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder.ToTable("Profiles");

            builder.HasKey(p => p.Id);

            builder
                .HasOne(p => p.User)
                .WithOne(u => u.Profile);

            builder
                .HasOne(p => p.Avatar)
                .WithOne(a => a.Profile);
        }
    }
}
