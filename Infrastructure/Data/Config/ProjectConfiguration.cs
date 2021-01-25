using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(69);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(t => t.ProjectType).WithMany()
                .HasForeignKey(p => p.ProjectTypeId);
            builder.HasOne(y => y.ProjectYear).WithMany()
                .HasForeignKey(p => p.ProjectYearId);
        }
    }
}