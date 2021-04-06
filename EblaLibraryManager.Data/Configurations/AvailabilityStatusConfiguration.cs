using EblaLibraryManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EblaLibraryManager.Data.Configurations
{
    public class AvailabilityStatusConfiguration : IEntityTypeConfiguration<AvailabilityStatus>
    {
        public void Configure(EntityTypeBuilder<AvailabilityStatus> builder)
        {
            builder.ToTable("AvailabilityStatus");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
