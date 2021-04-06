using EblaLibraryManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EblaLibraryManager.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");

            builder.Property(e => e.Born).HasColumnType("date");

            builder.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Death).HasColumnType("date");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
